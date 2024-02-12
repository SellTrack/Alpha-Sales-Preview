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

namespace AlphaSales.Areas.ClientArea.Controllers;

[Area("ClientArea")]
[Authorize(Roles = SD.Role_Client)]
public class ClientController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly UserManager<ApplicationUser> _userManager2;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _environment;
    private readonly ApplicationDbContext _context;

    public ClientController(IWebHostEnvironment environment, ApplicationDbContext context, IUnitOfWork unitOfWork
        , UserManager<IdentityUser> userManager, UserManager<ApplicationUser> userManager2, RoleManager<IdentityRole> roleManager)
    {
        _environment = environment;
        _context = context;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _userManager2 = userManager2;
        _roleManager = roleManager;
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

    public IActionResult IndexExercise()
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



    public IActionResult Users()
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

    public IActionResult ExerciseList()
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
    public IActionResult UserExerciseList()
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
    public IActionResult Nutrition()
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
    public IActionResult Speciality()
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
    public IActionResult SpecialityList()
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
    public IActionResult UserSpecialityList()
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
    public IActionResult CoachSpecialities()
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
    public IActionResult Chat()
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

    public IActionResult CreateSpeciality()
    {
        var user = _userManager2.GetUserAsync(User).Result;

        SpecialityViewModel SpecialityVM = new()
        {
            UserName = user.Name,
            Email = user.Email,
            Speciality = new Speciality()
        };
        return View(SpecialityVM);
    }

    [HttpPost]
    public IActionResult CreateSpeciality(SpecialityViewModel obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Speciality.Add(obj.Speciality);
            _unitOfWork.Save();
            return RedirectToAction("SpecialityList");

        }
        return View();
    }

    public IActionResult CreateExercise()
    {
        var user = _userManager2.GetUserAsync(User).Result;

        ExerciseViewModel ExerciseVM = new()
        {
            UserName = user.Name,
            Email = user.Email,
            Users = _context.ApplicationUsers.ToList(), // Tüm kullanıcıları al
            ExercisePlan = new ExercisePlan()
        };
        return View(ExerciseVM);
    }

    [HttpPost]
    public IActionResult CreateExercise(ExerciseViewModel obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Exercise.Add(obj.ExercisePlan);
            _unitOfWork.Save();
            return RedirectToAction("ExerciseList");

        }
        return View();
    }




    public IActionResult CreateUserExercise()
    {
        var user = _userManager2.GetUserAsync(User).Result;

        UserExerciseViewModel userExerciseVM = new()
        {
            UserName = user.Name,
            Email = user.Email,
            UserExercisePlan = new UserExercisePlan(),
            Users = _context.ApplicationUsers.ToList(), // Tüm kullanıcıları al
            ExercisePlans = _unitOfWork.Exercise.GetAll().ToList() // Tüm uzmanlık alanlarını al
        };

        return View(userExerciseVM);
    }

    [HttpPost]
    public IActionResult CreateUserExercise(UserExerciseViewModel obj)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.UserExercise.Add(obj.UserExercisePlan);
            _unitOfWork.Save();
            return RedirectToAction("IndexExercise");
        }

        // Hata durumunda, view'e giderken Users ve Specialities listelerini tekrar eklemelisiniz.

        return View(obj);
    }

    public IActionResult CreateUserSpeciality()
    {
        var user = _userManager2.GetUserAsync(User).Result;

        UserSpecialityViewModel userSpecialityVM = new()
        {
            UserName = user.Name,
            Email = user.Email,
            UserSpeciality = new UserSpeciality(),
            Users = _context.ApplicationUsers.ToList(), // Tüm kullanıcıları al
            Specialities = _unitOfWork.Speciality.GetAll().ToList() // Tüm uzmanlık alanlarını al
        };

        return View(userSpecialityVM);
    }

    [HttpPost]
    public IActionResult CreateUserSpeciality(UserSpecialityViewModel obj)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.UserSpeciality.Add(obj.UserSpeciality);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        // Hata durumunda, view'e giderken Users ve Specialities listelerini tekrar eklemelisiniz.

        return View(obj);
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

    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        List<ApplicationUser> objAllEmployeeList = _context.ApplicationUsers.ToList();

        var userRoles = _context.UserRoles.ToList();
        var roles = _context.Roles.ToList();

        foreach (var user in objAllEmployeeList)
        {
            var roleID = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
            user.Role = roles.FirstOrDefault(u => u.Id == roleID).Name;
        }

        var result = objAllEmployeeList.Select(user => new
        {
            name = user.Name,
            role = user.Role,
            id = user.Id

        });

        return Json(new { data = result });
    }

    [HttpPost]
    public IActionResult LockUnlock([FromBody] string id)
    {
        var objFromDb = _context.ApplicationUsers.FirstOrDefault(u => u.Id == id);
        if (objFromDb == null)
        {
            return Json(new { success = false, message = "Kilitleme işleminde sorun oluştu" });
        }
        if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
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






    //speciality

    [HttpGet]
    public IActionResult GetAllSpeciality()
    {
        List<Speciality> objSpecialityList = _unitOfWork.Speciality.GetAll().ToList();

        return Json(new { data = objSpecialityList });
    }


    public IActionResult EditSpeciality(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var user = _userManager2.GetUserAsync(User).Result;

        SpecialityViewModel specialityVM = new()
        {
            UserName = user.Name,
            Email = user.Email,
            Speciality = _unitOfWork.Speciality.Get(u => u.Speciality_id == id)
        };
        return View(specialityVM);
    }

    [HttpPost]
    public IActionResult EditSpeciality(SpecialityViewModel obj)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.Speciality.Update(obj.Speciality);
            _unitOfWork.Save();
            TempData["Success"] = "Speciality updated succeessfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult DeleteSpeciality(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Speciality? specialityFromDb = _unitOfWork.Speciality.Get(u => u.Speciality_id == id);
        if (specialityFromDb == null)
        {
            return NotFound();
        }
        return View(specialityFromDb);
    }

    [HttpPost, ActionName("DeleteSpeciality")]
    public IActionResult DeleteSpecialityPOST(int? id)
    {
        Speciality? obj = _unitOfWork.Speciality.Get(u => u.Speciality_id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.Speciality.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Speciality remoced successfully";
        return RedirectToAction("SpecialityList");
    }


    // UserSpeciality

    [HttpGet]
    public IActionResult GetAllUserSpeciality()
    {
        List<UserSpeciality> objUserSpecialityList = _unitOfWork.UserSpeciality.GetAll().ToList();
        List<Speciality> objSpecialityList = _unitOfWork.Speciality.GetAll().ToList();
        List<ApplicationUser> objAllEmployeeList = _context.ApplicationUsers.ToList();

        return Json(new { data = objUserSpecialityList, objAllEmployeeList, objSpecialityList });
    }


    public IActionResult EditUserSpeciality(int? id)
    {
        List<UserSpeciality> objUserSpecialityList = _unitOfWork.UserSpeciality.GetAll().ToList();
        List<ApplicationUser> objAllEmployeeList = _context.ApplicationUsers.ToList();
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var user = _userManager2.GetUserAsync(User).Result;

        UserSpecialityViewModel userspecialityVM = new()
        {
            UserName = user.Name,
            Email = user.Email,
            Users = _context.ApplicationUsers.ToList(), // Tüm kullanıcıları al
            Specialities = _unitOfWork.Speciality.GetAll().ToList(), // Tüm uzmanlık alanlarını al
            UserSpeciality = _unitOfWork.UserSpeciality.Get(u => u.UserSpeciality_id == id)
        };
        return View(userspecialityVM);
    }

    [HttpPost]
    public IActionResult EditUserSpeciality(UserSpecialityViewModel obj)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.UserSpeciality.Update(obj.UserSpeciality);
            _unitOfWork.Save();
            TempData["Success"] = "UserSpeciality updated succeessfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult DeleteUserSpeciality(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        UserSpeciality? userspecialityFromDb = _unitOfWork.UserSpeciality
            .Get(u => u.UserSpeciality_id == id, includeProperties: "ApplicationUser,Speciality");
        if (userspecialityFromDb == null)
        {
            return NotFound();
        }
        return View(userspecialityFromDb);
    }

    [HttpPost, ActionName("DeleteUserSpeciality")]
    public IActionResult DeleteUserSpecialityPOST(int? id)
    {
        UserSpeciality? obj = _unitOfWork.UserSpeciality.Get(u => u.UserSpeciality_id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.UserSpeciality.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Speciality remoced successfully";
        return RedirectToAction("UserSpecialityList");
    }

    //Exercise


    [HttpGet]
    public IActionResult GetAllExercise()
    {
        List<ExercisePlan> objExerciseList = _unitOfWork.Exercise.GetAll().ToList();
        List<ApplicationUser> objAllEmployeeList = _context.ApplicationUsers.ToList();

        return Json(new { data = objExerciseList, objAllEmployeeList });
    }


    public IActionResult EditExercise(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var user = _userManager2.GetUserAsync(User).Result;

        ExerciseViewModel exerciseVM = new()
        {
            UserName = user.Name,
            Email = user.Email,
            Users = _context.ApplicationUsers.ToList(), // Tüm kullanıcıları al
            ExercisePlan = _unitOfWork.Exercise.Get(u => u.ExercisePlan_id == id)
        };
        return View(exerciseVM);
    }

    [HttpPost]
    public IActionResult EditExercise(ExerciseViewModel obj)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.Exercise.Update(obj.ExercisePlan);
            _unitOfWork.Save();
            TempData["Success"] = "Exercise updated succeessfully";
            return RedirectToAction("IndexExercise");
        }
        return View();
    }

    public IActionResult DeleteExercise(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        ExercisePlan? exerciseFromDb = _unitOfWork.Exercise.Get(u => u.ExercisePlan_id == id);
        if (exerciseFromDb == null)
        {
            return NotFound();
        }
        return View(exerciseFromDb);
    }

    [HttpPost, ActionName("DeleteExercise")]
    public IActionResult DeleteExercisePOST(int? id)
    {
        ExercisePlan? obj = _unitOfWork.Exercise.Get(u => u.ExercisePlan_id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.Exercise.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Exercise remoced successfully";
        return RedirectToAction("ExerciseList");
    }


    // userexercise

    [HttpGet]
    public IActionResult GetAllUserExercise()
    {
        List<UserExercisePlan> objUserExerciseList = _unitOfWork.UserExercise.GetAll().ToList();
        List<ExercisePlan> objExerciseList = _unitOfWork.Exercise.GetAll().ToList();
        List<ApplicationUser> objAllEmployeeList = _context.ApplicationUsers.ToList();

        return Json(new { data = objUserExerciseList, objAllEmployeeList, objExerciseList });
    }


    public IActionResult EditUserExercise(int? id)
    {
        List<UserExercisePlan> objUserExerciseList = _unitOfWork.UserExercise.GetAll().ToList();
        List<ApplicationUser> objAllEmployeeList = _context.ApplicationUsers.ToList();
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var user = _userManager2.GetUserAsync(User).Result;

        UserExerciseViewModel userexerciseVM = new()
        {
            UserName = user.Name,
            Email = user.Email,
            Users = _context.ApplicationUsers.ToList(), // Tüm kullanıcıları al
            ExercisePlans = _unitOfWork.Exercise.GetAll().ToList(), // Tüm uzmanlık alanlarını al
            UserExercisePlan = _unitOfWork.UserExercise.Get(u => u.UserExercisePlan_id == id)
        };
        return View(userexerciseVM);
    }

    [HttpPost]
    public IActionResult EditUserExercise(UserExerciseViewModel obj)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.UserExercise.Update(obj.UserExercisePlan);
            _unitOfWork.Save();
            TempData["Success"] = "UserExercise updated succeessfully";
            return RedirectToAction("IndexExercise");
        }
        return View();
    }

    public IActionResult DeleteUserExercise(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        UserExercisePlan? userexerciseFromDb = _unitOfWork.UserExercise
            .Get(u => u.UserExercisePlan_id == id, includeProperties: "ApplicationUser,Exercise");
        if (userexerciseFromDb == null)
        {
            return NotFound();
        }
        return View(userexerciseFromDb);
    }

    [HttpPost, ActionName("DeleteUserExercise")]
    public IActionResult DeleteUserExercisePOST(int? id)
    {
        UserExercisePlan? obj = _unitOfWork.UserExercise.Get(u => u.UserExercisePlan_id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.UserExercise.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Exercise remoced successfully";
        return RedirectToAction("UserExerciseList");
    }


    #endregion




}
