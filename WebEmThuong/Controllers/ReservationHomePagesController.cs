using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebEmThuong.Models;

namespace WebEmThuong.Controllers
{
    public class ReservationHomePagesController : Controller
    {
        private readonly MyDbContext _context;

        public ReservationHomePagesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ReservationHomePages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservationHomePages.ToListAsync());
        }

        // GET: ReservationHomePages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationHomePage = await _context.ReservationHomePages.FindAsync(id);
            if (reservationHomePage == null)
            {
                return NotFound();
            }
            return View(reservationHomePage);
        }

        // POST: ReservationHomePages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Desciption")] ReservationHomePage reservationHomePage)
        {
            if (id != reservationHomePage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationHomePage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationHomePageExists(reservationHomePage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservationHomePage);
        }
        private bool ReservationHomePageExists(int id)
        {
            return _context.ReservationHomePages.Any(e => e.Id == id);
        }
    }
}
