using Microsoft.AspNetCore.Mvc;

namespace WebEmThuong.Controllers.Admin
{
    public class ReservationManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
