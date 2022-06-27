using Microsoft.AspNetCore.Identity;
using System;

namespace NoticeBoard.Controllers.Data
{
    public class Administration
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("Admin@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "Admin"
                };

                IdentityResult result = userManager.CreateAsync(user, "Mukit@2022").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        internal static void SeedUsers()
        {
            throw new NotImplementedException();
        }
    }
}
