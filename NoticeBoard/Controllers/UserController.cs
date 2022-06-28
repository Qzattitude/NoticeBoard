using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoticeBoard.Controllers.Data;
using NoticeBoard.Models.VewModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace NoticeBoard.Controllers
{
    public class UserController : Controller
    {
        public UserController(UserManager<IdentityUser> userManager,
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

        [HttpGet]
        [Authorize(Roles ="User")]
        public IActionResult Index(UserViewModel model)
        {
            var userId = UserManager.GetUserId(HttpContext.User);
            if (userId != null)
            {
                if (ModelState.IsValid)
                {
                    model.UserNotice = Db.UserNotice.Where(p=>p.UserId.Equals(userId))
                        .OrderByDescending(p=>p.IsVisited).ToList();
                    return View(model);
                }
            }
            return RedirectToAction("Index","Home");
        }

        [Authorize(Roles = "User")]
        public PartialViewResult Refresh(UserViewModel model)
        {
            var userId = UserManager.GetUserId(HttpContext.User);
            model.UserNotice = Db.UserNotice
                        .Where(p => p.UserId.Equals(userId))
                        .OrderBy(p => !p.IsVisited).ToList();
            return PartialView("_UserNotice", model);
        }
    }
}
