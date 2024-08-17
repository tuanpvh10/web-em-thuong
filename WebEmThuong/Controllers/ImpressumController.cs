using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEmThuong.Models;

namespace WebEmThuong.Controllers
{
    public class ImpressumController : Controller
    {
        private readonly MyDbContext _context;
        public ImpressumController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ig = _context.Instagram.OrderBy(b => b.Id).ToList();
            ViewBag.ig = ig;
            return View();
        }
    }
}
