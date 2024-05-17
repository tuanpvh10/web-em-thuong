using Microsoft.AspNetCore.Mvc;
using WebEmThuong.Models;

namespace WebEmThuong.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly MyDbContext myDb;

        public AdminController(MyDbContext myDb)
        {
            this.myDb = myDb;
        }

        public IActionResult Index()
        {
            var todayDateOnly = DateOnly.FromDateTime(DateTime.Today); // Chuyển đổi DateTime.Today thành DateOnly
            var reservations = myDb.Reservations
                .Where(r => r.Date >= todayDateOnly)
                .OrderBy(r => r.Date)
                .ThenBy(r => r.Time)
                .ToList();
            return View(reservations);
        }

        public IActionResult Detail(int id)
        {
            var reservation = myDb.Reservations.Where(r => r.Id == id).FirstOrDefault();
            return View(reservation);
        }
    }
}
