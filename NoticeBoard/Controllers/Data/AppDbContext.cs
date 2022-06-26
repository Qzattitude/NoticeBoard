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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           // builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            builder.Entity<UserNotice>()
                .HasOne(u => u.User)
                .WithMany(n => n.UserNotice)
               // .HasPrincipalKey<User>(x => x.Username)
                .HasForeignKey(k => k.Username);
            builder.Entity<UserNotice>()
                .HasOne(u => u.Notice)
                .WithMany(n => n.UserNotice)
               // .HasPrincipalKey<Notice>(x => x.NoticeId)
                .HasForeignKey(k => k.NoticeId);
        }
        DbSet<User> User { get; set; }
        DbSet<Notice> Notice { get; set; }
        DbSet<UserNotice> UserNotice { get; set; }

        //public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<object>
        //{
        //    public void Configure(EntityTypeBuilder<object> builder)
        //    {
        //        throw new System.NotImplementedException();
        //    }
        //}
    }
}
