using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GazeteProje.Data;
using GazeteProje.Models;

namespace GazeteProje.Controllers
{
    public class WritersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WritersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Writers
        public async Task<IActionResult> Index()
        {
              return _context.Writers != null ? 
                          View(await _context.Writers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Writers'  is null.");
        }

        // GET: Writers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Writers == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers
                .FirstOrDefaultAsync(m => m.WriterId == id);
            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        // GET: Writers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Writers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Writer gelen,IFormFile ImageUpload)
        {
            try
            {
                if (ImageUpload == null)
                {
                    TempData["Error"] = "Resim Dosyası Boş";
                    return View();
                }
                else
                {
                    var uzanti = Path.GetExtension(ImageUpload.FileName);
                    var allowExtensions = new[] { ".jpg", ".gif", ".png", ".jpeg" };
                    //dizi oluşturduk
                    if (!allowExtensions.Contains(uzanti))
                    {
                        TempData["Error"] = "Dosya Tipi Hatalı";
                        return View();
                    }
                    if (ImageUpload.Length > 5242880)
                    {
                        TempData["Error"] = "Dosya Boyutu 5Mb Büyük Olamaz";
                        return View();
                    }

                    //gonderilen dosyanın uzantısını al pdf png gif vb..
                    var newName = Guid.NewGuid().ToString() + uzanti;
                    //dosyaya yeniden isim verdik
                    string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Writer_Image/", newName);
                    //dosya kayıt yerini ayarlıyoruz
                    using (var stream = new FileStream(yol, FileMode.Create))
                    {
                        ImageUpload.CopyToAsync(stream);
                    }
                    gelen.WriterImage = newName;
                }
                //resim yükleme işlemi tamamlandıktan sonra
                if (ModelState.IsValid)
                {
                    _context.Add(gelen);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(gelen);
            



            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
               
            }




           
        }

        // GET: Writers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Writers == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers.FindAsync(id);
            if (writer == null)
            {
                return NotFound();
            }
            return View(writer);
        }

        // POST: Writers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WriterId,Name,Email,UserName,PassWord,WriterImage")] Writer writer)
        {
            if (id != writer.WriterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(writer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WriterExists(writer.WriterId))
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
            return View(writer);
        }

        // GET: Writers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Writers == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers
                .FirstOrDefaultAsync(m => m.WriterId == id);
            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        // POST: Writers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Writers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Writers'  is null.");
            }
            var writer = await _context.Writers.FindAsync(id);
            if (writer != null)
            {
                _context.Writers.Remove(writer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WriterExists(int id)
        {
          return (_context.Writers?.Any(e => e.WriterId == id)).GetValueOrDefault();
        }
    }
}
