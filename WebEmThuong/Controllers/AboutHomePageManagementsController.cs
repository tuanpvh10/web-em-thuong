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
    public class AboutHomePageManagementsController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AboutHomePageManagementsController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: AboutHomePageManagements
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutHomePageManagement.ToListAsync());
        }

        // GET: AboutHomePageManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutHomePageManagement = await _context.AboutHomePageManagement.FindAsync(id);
            if (aboutHomePageManagement == null)
            {
                return NotFound();
            }
            return View(aboutHomePageManagement);
        }

        // POST: AboutHomePageManagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Desciption,ImgUrl")] AboutHomePageManagement aboutHomePageManagement, IFormFile? file)
        {
            if (id != aboutHomePageManagement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRoothPath = _webHostEnvironment.WebRootPath;
                    if(file != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string aboutPath = Path.Combine(wwwRoothPath, @"img");
                        using (var filesStream = new FileStream(Path.Combine(aboutPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(filesStream);
                        }
                        aboutHomePageManagement.ImgUrl = @"img/" + fileName;
                    }
                    _context.Update(aboutHomePageManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutHomePageManagementExists(aboutHomePageManagement.Id))
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
            return View(aboutHomePageManagement);
        }

        // POST: AboutHomePageManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutHomePageManagement = await _context.AboutHomePageManagement.FindAsync(id);
            if (aboutHomePageManagement != null)
            {
                _context.AboutHomePageManagement.Remove(aboutHomePageManagement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutHomePageManagementExists(int id)
        {
            return _context.AboutHomePageManagement.Any(e => e.Id == id);
        }
    }
}
