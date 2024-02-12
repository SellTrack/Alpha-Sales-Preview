using System;
using System.Data;
using System.Linq;
using AlphaSales.Areas.Identity.Pages.Account;
using AlphaSales.DataAccess.Data;
using AlphaSales.DataAccess.Repository.IRepository;
using AlphaSales.Models;
using AlphaSales.Models.ViewModels;
using AlphaSales.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AlphaSales.Areas.MasterMind.Controllers;

[Area("MasterMind")]
[Authorize(Roles = SD.Role_Admin)]
public class AdminController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly UserManager<ApplicationUser> _userManager2;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _environment;
    private readonly ApplicationDbContext _context;

    public AdminController(IWebHostEnvironment environment, ApplicationDbContext context,IUnitOfWork unitOfWork
        , UserManager<IdentityUser> userManager, UserManager<ApplicationUser> userManager2, RoleManager<IdentityRole> roleManager)
    {
        _environment = environment;
        _context = context;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _userManager2 = userManager2;
        _roleManager = roleManager;
    }


    public IActionResult Employee()
    {
        var user = _userManager2.GetUserAsync(User).Result;

        var userProfileViewModel = new UserProfileViewModel
        {
            UserName = user.Name,
            Email = user.Email
            // Diğer kullanıcı özelliklerini buraya ekleyebilirsiniz.
        };

        return View(userProfileViewModel); return View();
    }



    public async Task<IActionResult> DeleteUserAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if(user == null)
        {
            ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
            return View("NotFound");
        }
        else
        {
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Employee");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("Employee");
        }
    }

    public IActionResult RoleManagement(string userId)
    {
        string RoleID = _context.UserRoles.FirstOrDefault(u => u.UserId == userId).RoleId;
        var user = _userManager2.GetUserAsync(User).Result;

        RoleManagementVM RoleVM = new RoleManagementVM()
        {
            UserName = user.Name,
            Email = user.Email,

            ApplicationUser = _context.ApplicationUsers.FirstOrDefault(u => u.Id == userId),
            RoleList = _context.Roles.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Name
            })


        };

        RoleVM.ApplicationUser.Role = _context.Roles.FirstOrDefault(u => u.Id == RoleID).Name;


        return View(RoleVM);
    }


    [HttpPost]
    public IActionResult RoleManagement(RoleManagementVM roleManagementVM)
    {
        string RoleID = _context.UserRoles.FirstOrDefault(u => u.UserId == roleManagementVM.ApplicationUser.Id).RoleId;
        // Kullanıcının eski rolünü al
        string oldRole = _context.Roles.FirstOrDefault(u => u.Id == RoleID).Name;

        if (!(roleManagementVM.ApplicationUser.Role == oldRole))
        {
            ApplicationUser applicationUser = _context.ApplicationUsers.FirstOrDefault(u => u.Id == roleManagementVM.ApplicationUser.Id);



            _context.SaveChanges();
            // Eski rolden çıkar
            _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
            // Yeni role ekle
            _userManager.AddToRoleAsync(applicationUser, roleManagementVM.ApplicationUser.Role).GetAwaiter().GetResult();
        }

        // Başarılı işlem sonrası bir yönlendirme yapabilirsiniz
        return RedirectToAction("Employee"); // Yönlendirme işlemi
    }

    public IActionResult Index()
    {
        var user = _userManager2.GetUserAsync(User).Result;
        var userProfileViewModel = new UserProfileViewModel
        {
            UserName = user.Name,
            Email = user.Email
            // Diğer kullanıcı özelliklerini buraya ekleyebilirsiniz.
        };

        return View(userProfileViewModel);
    }

    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        List<ApplicationUser> objAllEmployeeList = _context.ApplicationUsers.Include(u=>u.Corporation).ToList();

        var userRoles = _context.UserRoles.ToList();
        var roles = _context.Roles.ToList();
        var employees = _context.Employees.ToList();

        foreach (var user in objAllEmployeeList)
        {  
            var roleID = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
            user.Role = roles.FirstOrDefault(u => u.Id == roleID).Name;
        }

        var result = objAllEmployeeList.Select(user => new
        {
            name = user.Name,
            role = user.Role,
            total = user.Total_Client_Number,
            successful = user.Verified_Client_Number,
            unsuccessful = user.Declined_Client_Number,
            totalqc = user.Total_QCs,
            successfulqc = user.Successful_QCs,
            lockoutEnd = user.LockoutEnd,
            unsuccessfulqc = user.Unsuccessful_QCs,
            corporation = user.Corporation != null ? user.Corporation.Name : "Bağlı Şirket Yok",
            id = user.Id

        });

        return Json(new { data = result });
    }

    [HttpPost]
    public IActionResult LockUnlock([FromBody]string id)
    {
        var objFromDb = _context.ApplicationUsers.FirstOrDefault(u => u.Id == id);
        if(objFromDb == null)
        {
            return Json(new { success = false, message = "Kilitleme işleminde sorun oluştu" });
        }
        if(objFromDb.LockoutEnd!=null && objFromDb.LockoutEnd > DateTime.Now)
        {
            objFromDb.LockoutEnd = DateTime.Now;
        }
        else
        {
            objFromDb.LockoutEnd = DateTime.Now.AddYears(33);
        }
        _context.SaveChanges();
        return Json(new { success = true, message = "İşlem Başarılı" });
    }

    #endregion
}
