using Microsoft.AspNetCore.Mvc;
using WebEmThuong.Models;

namespace WebEmThuong.Controllers
{
    public class ContactController : Controller
    {
        private readonly MyDbContext _context;
        public ContactController(MyDbContext myDbContext)
        {
            _context = myDbContext;
        }
        public IActionResult Index()
        {
            var ig = _context.Instagram.OrderBy(b => b.Id).ToList();
            ViewBag.ig = ig;
            return View();
        }
    }
}
