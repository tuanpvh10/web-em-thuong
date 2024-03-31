using Microsoft.AspNetCore.Mvc;

namespace WebEmThuong.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
