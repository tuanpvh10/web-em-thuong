using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebEmThuong.Migrations;
using WebEmThuong.Models;

namespace WebEmThuong.Controllers
{
    public class InstagramsManagementController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InstagramsManagementController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: InstagramsManagement
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instagram.ToListAsync());
        }

        // GET: InstagramsManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instagram = await _context.Instagram.FindAsync(id);
            if (instagram == null)
            {
                return NotFound();
            }
            return View(instagram);
        }

        // POST: InstagramsManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,No,ImgUrl")] Instagram instagram, IFormFile? file)
        {
            if (id != instagram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (file != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"img");
                        string shopPath = Path.Combine(wwwRootPath, @"shop/img");
                        using (var filesStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(filesStream);
                        }
                        using (var filesStream = new FileStream(Path.Combine(shopPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(filesStream);
                        }
                        instagram.ImgUrl = @"img/" + fileName;
                    }
                    _context.Update(instagram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstagramExists(instagram.Id))
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
            return View(instagram);
        }
        private bool InstagramExists(int id)
        {
            return _context.Instagram.Any(e => e.Id == id);
        }
    }
}
