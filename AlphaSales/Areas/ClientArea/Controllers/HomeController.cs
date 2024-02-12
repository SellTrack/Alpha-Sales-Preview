using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AlphaSales.Models;
using Microsoft.AspNetCore.Authorization;
using AlphaSales.Utility;
using Microsoft.AspNetCore.Identity;
using AlphaSales.DataAccess.Data;

namespace AlphaSales.Areas.ClientArea.Controllers
{

    [Area("ClientArea")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _db;


        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }



        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin", new { area = "MasterMind" });
            }
            else if (User.IsInRole("Coach"))
            {
                return RedirectToAction("Index", "Coach", new { area = "CoachArea" });
            }
            else if (User.IsInRole("Client"))
            {
                return RedirectToAction("Index", "Client", new { area = "ClientArea" });
            }
            else if (User.IsInRole("QCEmployee"))
            {
                return RedirectToAction("Index", "QCEmployee", new { area = "EmployeeArea" });
            }
            else if (User.IsInRole("LeaderBoard"))
            {
                return RedirectToAction("Index", "LeaderBoard", new { area = "LeaderBoardArea" });
            }

                return RedirectToAction("GuestIndex", "Client", new { area = "ClientArea" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}