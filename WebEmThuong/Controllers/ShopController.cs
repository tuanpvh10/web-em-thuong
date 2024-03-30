using Microsoft.AspNetCore.Mvc;

namespace WebEmThuong.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
