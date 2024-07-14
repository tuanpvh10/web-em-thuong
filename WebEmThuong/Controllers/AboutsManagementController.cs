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
    public class AboutsManagementController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AboutsManagementController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: AboutsManagement
        public async Task<IActionResult> Index()
        {
            return View(await _context.About.ToListAsync());
        }

        // GET: AboutsManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.About.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        // POST: AboutsManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Desciption,ImgUrl1,ImgUrl2,ImgUrl3")] About about, IFormFile? file1, IFormFile? file2, IFormFile? file3)
        {
            if (id != about.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (file1 != null)
                    {
                        string fileName1 = Guid.NewGuid().ToString() + Path.GetExtension(file1.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"img");
                        using (var filesStream = new FileStream(Path.Combine(productPath, fileName1), FileMode.Create))
                        {
                            file1.CopyTo(filesStream);
                        }
                        about.ImgUrl1 = @"img/" + fileName1;
                    }
                    if (file2 != null)
                    {
                        string fileName2 = Guid.NewGuid().ToString() + Path.GetExtension(file2.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"img");
                        using (var filesStream = new FileStream(Path.Combine(productPath, fileName2), FileMode.Create))
                        {
                            file2.CopyTo(filesStream);
                        }
                        about.ImgUrl2 = @"img/" + fileName2;
                    }
                    if (file3 != null)
                    {
                        string fileName3 = Guid.NewGuid().ToString() + Path.GetExtension(file3.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"img");
                        using (var filesStream = new FileStream(Path.Combine(productPath, fileName3), FileMode.Create))
                        {
                            file3.CopyTo(filesStream);
                        }
                        about.ImgUrl3 = @"img/" + fileName3;
                    }
                    _context.Update(about);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutExists(about.Id))
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
            return View(about);
        }


        private bool AboutExists(int id)
        {
            return _context.About.Any(e => e.Id == id);
        }
    }
}
