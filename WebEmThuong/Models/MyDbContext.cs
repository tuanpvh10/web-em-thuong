using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebEmThuong.Models;

namespace WebEmThuong.Models
{
    public class MyDbContext : IdentityDbContext<User>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<BackGround> BackGround { get; set; } = default!;
        public DbSet<AboutHomePageManagement> AboutHomePageManagement { get; set; } = default!;
        public DbSet<SpecialOffers> SpecialOffers { get; set; } = default!;
        public DbSet<ReservationHomePage> ReservationHomePages { get; set;} = default!;
        public DbSet<Galleries> Galleries { get; set; } = default;
        public DbSet<Comment> Comments { get; set; } = default;
        public DbSet<WebEmThuong.Models.Instagram> Instagram { get; set; } = default!;
        public DbSet<WebEmThuong.Models.About> About { get; set; } = default!;
    }
}
