using Microsoft.EntityFrameworkCore;

namespace WebEmThuong.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
