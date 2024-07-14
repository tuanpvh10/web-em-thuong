using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebEmThuong.Models;

namespace WebEmThuong.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;

        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var backGrounds = _context.BackGround.OrderBy(b => b.Id).ToList();
            var aboutHomePageManagements = _context.AboutHomePageManagement.OrderBy(b => b.Id).ToList();
            var comments = _context.Comments.OrderBy(b => b.Id).ToList();
            var instagrams = _context.Instagram.OrderBy(b => b.Id).ToList();
            var specialOffers = _context.SpecialOffers.OrderBy(b => b.Id).ToList();
            var reservationHomePages = _context.ReservationHomePages.OrderBy(b => b.Id).ToList();

            var homeViewModel = new HomeViewModel()
            {
                BackGrounds = backGrounds,
                AboutHomePageManagements = aboutHomePageManagements,
                Comments = comments,
                Instagrams = instagrams,
                SpecialOffers = specialOffers,
                ReservationHomePages = reservationHomePages
            };

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
