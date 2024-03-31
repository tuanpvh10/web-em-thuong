using Microsoft.AspNetCore.Mvc;

namespace WebEmThuong.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
