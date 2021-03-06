using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoticeBoard.Controllers.Data;
using NoticeBoard.Models;
using NoticeBoard.Models.VewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

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
                        .OrderByDescending(p => p.IsVisited).ThenByDescending(p =>p.UploadTime).ToList();
                    return View(model); 
                }
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public JsonResult OnClickViewCounter(NoticeIdModel model)
        {
            var listId = model.ClickedNoticeId;
            var notice = Db.Notice.FirstOrDefault();
            Db.UserNotice.Where(p => p.NoticeId.Equals(listId)).ToList().ForEach(x => x.IsVisited = true);
            Db.SaveChanges();
            notice.ViewCount++;
            Db.SaveChanges();

            return Json(true);
        }

        [HttpPost]
        public IActionResult Refresh()
        {
            return RedirectToAction("Index", "User");
        }


    }
}
