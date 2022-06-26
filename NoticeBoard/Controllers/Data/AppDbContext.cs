using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoticeBoard.Models;
namespace NoticeBoard.Controllers.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserNotice>()
                .HasOne(u => u.User)
                .WithMany(n => n.UserNotice)
                .HasForeignKey(k => k.UserId);
            builder.Entity<UserNotice>()
                .HasOne(u => u.Notice)
                .WithMany(n => n.UserNotice)
                .HasForeignKey(k => k.NoticeId);
        }
        DbSet<User> User { get; set; }
        DbSet<Notice> Notice { get; set; }
        DbSet<UserNotice> UserNotice { get; set; }
    }
}
