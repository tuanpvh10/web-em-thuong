using Microsoft.AspNetCore.Mvc;

namespace WebEmThuong.Controllers.Admin
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
