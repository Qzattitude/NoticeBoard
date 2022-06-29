﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoticeBoard.Controllers.Data;
using NoticeBoard.Models.VewModel;
using System.Linq;


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
        public IActionResult ViewCount(string NoticeIdentify)
        {
            Db.UserNotice.Where(p => p.NoticeId.Equals(NoticeIdentify)).ToList().ForEach(x => x.IsVisited = true);
            Db.SaveChanges();
            int newCount = Db.Notice.Where(p =>p.Id.Equals(NoticeIdentify))
                .Select(x=>x.ViewCount).FirstOrDefault();
            newCount++;
            Db.Notice.Where(p=>p.Id.Equals((NoticeIdentify).ToString().ToUpper())).ToList().ForEach(x=>x.ViewCount=newCount);
            Db.SaveChanges();
            return RedirectToAction("Index", "User");
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
