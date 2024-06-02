using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEmThuong.Models;

namespace WebEmThuong.Controllers
{
    public class ShopController : Controller
    {
        private readonly MyDbContext _context;

        public ShopController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var catagories = await _context.Category.OrderBy(c=>c.Sort).ToListAsync();
            var productions = await _context.Productions.OrderBy(p => p.Sort).ToListAsync();

            var shopViewModel = new ShopViewModel
            {
                Categories = catagories,
                Productions = productions
            };

            return View(shopViewModel);
        }
    }
}
