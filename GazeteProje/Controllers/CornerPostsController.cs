using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GazeteProje.Data;
using GazeteProje.Models;
using Microsoft.AspNetCore.Authorization;

namespace GazeteProje.Controllers
{
    public class CornerPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CornerPostsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: CornerPosts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Corners.Include(c => c.Writer);
            //include ile writer tablosu ile cornerpost birleştiriyor.
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize]
        // GET: CornerPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Corners == null)
            {
                return NotFound();
            }

            var cornerPost = await _context.Corners
                .Include(c => c.Writer)
                .FirstOrDefaultAsync(m => m.CornerPostId == id);
            if (cornerPost == null)
            {
                return NotFound();
            }

            return View(cornerPost);
        }
        [Authorize]
        // GET: CornerPosts/Create
        public IActionResult Create()
        {
            ViewData["WriterId"] = new SelectList(_context.Writers, "WriterId", "Name");
            return View();
        }

        // POST: CornerPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CornerPostId,Header,Content,CreatedCorner,UpdatedCorner,WriterId,read")] CornerPost cornerPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cornerPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WriterId"] = new SelectList(_context.Writers, "WriterId", "Name", cornerPost.WriterId);
            return View(cornerPost);
        }

        // GET: CornerPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Corners == null)
            {
                return NotFound();
            }

            var cornerPost = await _context.Corners.FindAsync(id);
            if (cornerPost == null)
            {
                return NotFound();
            }
            ViewData["WriterId"] = new SelectList(_context.Writers, "WriterId", "Name", cornerPost.WriterId);
            return View(cornerPost);
        }

        // POST: CornerPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CornerPostId,Header,Content,CreatedCorner,UpdatedCorner,WriterId,read")] CornerPost cornerPost)
        {
            if (id != cornerPost.CornerPostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cornerPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CornerPostExists(cornerPost.CornerPostId))
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
            ViewData["WriterId"] = new SelectList(_context.Writers, "WriterId", "WriterId", cornerPost.WriterId);
            return View(cornerPost);
        }

        // GET: CornerPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Corners == null)
            {
                return NotFound();
            }

            var cornerPost = await _context.Corners
                .Include(c => c.Writer)
                .FirstOrDefaultAsync(m => m.CornerPostId == id);
            if (cornerPost == null)
            {
                return NotFound();
            }

            return View(cornerPost);
        }

        // POST: CornerPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Corners == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Corners'  is null.");
            }
            var cornerPost = await _context.Corners.FindAsync(id);
            if (cornerPost != null)
            {
                _context.Corners.Remove(cornerPost);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int id)
        {
            var result = _context.Corners.Include("Writer").Where(p=>p.CornerPostId==id).FirstOrDefault();
            return View(result);
        }
        private bool CornerPostExists(int id)
        {
          return (_context.Corners?.Any(e => e.CornerPostId == id)).GetValueOrDefault();
        }
    }
}
