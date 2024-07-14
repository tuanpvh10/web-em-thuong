using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEmThuong.Models;

namespace WebEmThuong.Controllers
{
    public class SpecialOffersController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SpecialOffersController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: SpecialOffers
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpecialOffers.ToListAsync());
        }

        // GET: SpecialOffers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialOffers = await _context.SpecialOffers.FindAsync(id);
            if (specialOffers == null)
            {
                return NotFound();
            }
            return View(specialOffers);
        }

        // POST: SpecialOffers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,ImgUrl")] SpecialOffers specialOffers, IFormFile? file)
        {
            if (id != specialOffers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if(file != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"img");
                        using (var filesStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(filesStream);
                        }
                        specialOffers.ImgUrl = @"img/" + fileName;
                    }
                    _context.Update(specialOffers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialOffersExists(specialOffers.Id))
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
            return View(specialOffers);
        }
        private bool SpecialOffersExists(int id)
        {
            return _context.SpecialOffers.Any(e => e.Id == id);
        }
    }
}
