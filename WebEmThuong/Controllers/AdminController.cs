using Microsoft.AspNetCore.Mvc;

namespace WebEmThuong.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
