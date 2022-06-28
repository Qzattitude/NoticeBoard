using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoticeBoard.Controllers.Data;
using NoticeBoard.Models;
using NoticeBoard.Models.VewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoard.Controllers
{
    public class AdminController : Controller
    {
        public AdminController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            AppDbContext db,
            IHostingEnvironment hostingEnvironment)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Db = db;
            HostingEnvironment = hostingEnvironment;
        }

        private UserManager<IdentityUser> UserManager { get; }
        private SignInManager<IdentityUser> SignInManager { get; }
        private AppDbContext Db { get; }
        private IHostingEnvironment HostingEnvironment { get; }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Dashboard()
        {
            // var result = await Db.Notice.FindAsync();
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload()
        {
            UploadNoticeViewModel model = new UploadNoticeViewModel();
            model.Users = await UserManager.GetUsersInRoleAsync("User");
            return View(model);
        }
        [HttpPost]
        public IActionResult Upload(UploadNoticeViewModel model, IEnumerable<string>SelecteUserListId)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.File != null)
                {
                    string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, "Notices");
                    uniqueFileName = Guid.NewGuid().ToString() +"_"+model.File.FileName;
                    string FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.File.CopyTo(new FileStream(FilePath, FileMode.Create));
                }
                Notice newNotice = new Notice()
                {
                    NoticeName = model.NoticeName,
                    NoticeLink = uniqueFileName,
                    UploadTime = DateTime.UtcNow.AddHours(6),
                    //UserNotice = (IList<UserNotice>)model.Users
                };
                Db.Notice.Add(newNotice);
                Db.SaveChanges();
            }
            return RedirectToAction("Dashboard","Admin");
        }

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Upload(UploadNoticeViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    // var result = await Db.User.FindAsync();
        //    return View(model);
        //}
    }
}
