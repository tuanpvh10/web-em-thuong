using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebEmThuong.Models;
using WebEmThuong.SignalR;

namespace WebEmThuong.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly MyDbContext myDbContext;
        private readonly IHubContext<MyHub> myhub;

        public ReservationController(MyDbContext myDbContext, IHubContext<MyHub> myhub)
        {
            this.myDbContext = myDbContext;
            this.myhub = myhub;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            if(ModelState.IsValid)
            {
                myDbContext.Reservations.Add(reservation);
                myDbContext.SaveChanges();
                await myhub.Clients.All.SendAsync("ReceiveReservationNotification", reservation.PhoneNumber);
                TempData["ReservationSuccess"] = "You have successfully booked your table, we will contact you soon. Thank you so much!";
                return RedirectToAction("Index", "Reservation");
            }
            return RedirectToAction("Index", "Reservation");
        }
    }
}
