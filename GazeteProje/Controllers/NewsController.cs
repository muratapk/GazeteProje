using GazeteProje.Data;
using GazeteProje.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GazeteProje.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //türetme

        // GET: NewsController
        public ActionResult Index()
        {
            //listeleme yapar Index haber listesini index
            var sorgu = _context.News.ToList();
            //ToList() tüm haberleri getir
               
            return View(sorgu);
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News gelen)
        {
            try
            {
                _context.News.Add(gelen);
                _context.SaveChanges();
                TempData["Success"] = "Success";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "Error";
                return View();
            }
        }

        // GET: NewsController/Edit/5
        public ActionResult Edit(int id)
        {
            var sorgu = _context.News.Find(id);
            return View(sorgu);
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News gelen)
        {
            try
            {
                _context.News.Update(gelen);
                _context.SaveChanges();
                TempData["Success"] = "Success";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "Error";
                return View();
            }
        }

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
