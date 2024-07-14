using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEmThuong.Models;

namespace WebEmThuong.Controllers
{
    public class AboutController : Controller
    {
        private readonly MyDbContext _context;

        public AboutController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ig = _context.Instagram.OrderBy(b => b.Id).ToList();
            ViewBag.ig = ig;
            return View(await _context.About.OrderBy(a => a.Id).ToListAsync());
        }
    }
}
