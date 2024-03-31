using Microsoft.AspNetCore.Mvc;

namespace WebEmThuong.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
