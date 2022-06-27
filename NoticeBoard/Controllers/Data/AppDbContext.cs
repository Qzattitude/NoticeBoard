using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoticeBoard.Models;
namespace NoticeBoard.Controllers.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        DbSet<User> User { get; set; }
        DbSet<Notice> Notice { get; set; }
        DbSet<UserNotice> UserNotice { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            //builder.Entity<UserNotice>()
            //    .HasOne(u => u.User)
            //    .WithMany(n => n.UserNotice)
            //   //.HasPrincipalKey<User>(x => x.Username)
            //    .HasForeignKey(k => k.Username);
            //builder.Entity<UserNotice>()
            //    .HasOne(u => u.Notice)
            //    .WithMany(n => n.UserNotice)
            //   // .HasPrincipalKey<Notice>(x => x.NoticeId)
            //    .HasForeignKey(k => k.NoticeId);

            //builder.Entity<IdentityRole>()
            //    .HasData(new IdentityRole 
            //    { Name = "Admin", NormalizedName = "Admin".ToUpper() });



            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ID = ADMIN_ID;
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Admin@2022",
                NormalizedUserName = "ADMIN@2022",
                Email = "mukit@gmail.com",
                NormalizedEmail = "mukit@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Mukit@2022"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });





        }
        



        //public static void SeedUsers(UserManager<IdentityUser> userManager)
        //{
        //    if (userManager.FindByEmailAsync("Admin@gmail.com").Result == null)
        //    {
        //        IdentityUser user = new IdentityUser
        //        {
        //            UserName = "Admin"
        //        };

        //        IdentityResult result = userManager.CreateAsync(user, "Mukit@2022").Result;

        //        if (result.Succeeded)
        //        {
        //            userManager.AddToRoleAsync(user, "Admin").Wait();
        //        }
        //    }
        //}


        //public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<object>
        //{
        //    public void Configure(EntityTypeBuilder<object> builder)
        //    {
        //        throw new System.NotImplementedException();
        //    }
        //}
    }
}
