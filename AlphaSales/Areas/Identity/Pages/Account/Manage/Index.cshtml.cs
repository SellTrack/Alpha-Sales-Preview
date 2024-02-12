// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AlphaSales.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlphaSales.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UserManager<ApplicationUser> _userManager2;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly SignInManager<IdentityUser> _signInManager;

        public IndexModel(
            IWebHostEnvironment webHostEnvironment,
            UserManager<IdentityUser> userManager,
            UserManager<ApplicationUser> userManager2,
            SignInManager<IdentityUser> signInManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _userManager2 = userManager2;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Adress")]
            public string Adress { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Surname { get; set; }
            public DateTime Birthdate { get; set; }
            [Display(Name = "Profil Resmi")]
            public IFormFile ProfilePhoto { get; set; }
            public string ProfilePhotoPath { get; set; } // Bu özellik dosya yolunu saklayacak
            public string UserID { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var user2 = _userManager2.GetUserAsync(User).Result;
            Username = userName;

            Input = new InputModel
            {
                UserID= user2.Id,
                Adress = user2.Adress,
                Name = user2.Name,
                Surname = user2.Surname,
                Gender = user2.gender,
                Birthdate = user2.Birtdate,
                PhoneNumber = phoneNumber,
                ProfilePhotoPath = user2.profilephotopath,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager2.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager2.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.ProfilePhoto != null && Input.ProfilePhoto.Length > 0)
            {
                var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Input.ProfilePhoto.FileName;
                var filePath = Path.Combine(uploadFolder, uniqueFileName);
                var relativePath = Path.GetRelativePath(_webHostEnvironment.WebRootPath, filePath);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.ProfilePhoto.CopyToAsync(fileStream);
                }

                // Profil resmi yüklendiyse, dosya yolu gibi bilgileri istediğiniz şekilde kullanabilirsiniz.
                // Örneğin, veritabanına dosya yolunu kaydedebilirsiniz.
                var user2 = await _userManager2.FindByIdAsync(Input.UserID);
                if (user2 != null)
                {
                    user2.Adress = Input.Adress;
                user2.Name = Input.Name;
                user2.Surname= Input.Surname;
                user2.profilephotopath = relativePath;
                user2.gender= Input.Gender;
                user2.PhoneNumber = Input.PhoneNumber;
                user2.Birtdate = Input.Birthdate;
                await _userManager2.UpdateAsync(user2);

                var result = await _userManager2.UpdateAsync(user2);

                if (result.Succeeded)
                {
                    // Başarıyla güncellenmişse girişi yenile
                    await _signInManager.RefreshSignInAsync(user2);
                }
                else
                {
                    // Güncelleme başarısızsa, hata işleme kodunu ekleyebilirsiniz.
                    // result.Errors'dan hataları alabilirsiniz.
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                }
                
            }
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
