using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoticeBoard.Controllers.Data;
using NoticeBoard.Models;
using NoticeBoard.Models.VewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public HomeController(ILogger<HomeController> logger,
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager,
            AppDbContext db)
        {
            _logger = logger;
            UserManager = userManager;
            SignInManager = signInManager;
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult AdminDashboard()
        //{

        //    IEnumerable<Notice> notice = _db.Notice.Where()
        //    return View();
        //}
        [HttpGet]
        public IActionResult AdminDashboard()
        {
            return View();
        }

        //[Authorize("Admin")]
        [HttpPost]
        public IActionResult UploadNoticeDashboard()
        {
            return View();
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
