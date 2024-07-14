using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebEmThuong.Models;

namespace WebEmThuong.Controllers
{
    public class BackGroundsController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BackGroundsController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: BackGrounds
        public async Task<IActionResult> Index()
        {
            return View(await _context.BackGround.ToListAsync());
        }

        // GET: BackGrounds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var backGround = await _context.BackGround.FindAsync(id);
            if (backGround == null)
            {
                return NotFound();
            }
            return View(backGround);
        }

        // POST: BackGrounds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Slogan,ImgUrl")] BackGround backGround, IFormFile? file)
        {
            if (id != backGround.Id)
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
                        using (var filesStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(filesStream);
                        }
                        backGround.ImgUrl = @"img/" + fileName;
                    }
                    _context.Update(backGround);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BackGroundExists(backGround.Id))
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
            return View(backGround);
        }

        private bool BackGroundExists(int id)
        {
            return _context.BackGround.Any(e => e.Id == id);
        }
    }
}
