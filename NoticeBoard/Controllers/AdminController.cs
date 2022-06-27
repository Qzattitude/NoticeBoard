using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoticeBoard.Controllers.Data;
using NoticeBoard.Models.VewModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoard.Controllers
{
    public class AdminController : Controller
    {
        public AdminController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager,
            AppDbContext db)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Db = db;
        }

        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }
        public AppDbContext Db { get; }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Dashboard()
        {
           // var result = await Db.Notice.FindAsync();
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Upload(UploadNoticeViewModel model)
        {
            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Upload(UploadNoticeViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            // var result = await Db.User.FindAsync();
            return View(model);
        }
    }
}
