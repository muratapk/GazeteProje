using GazeteProje.Data;
using GazeteProje.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var result=_context.News.Find(id);
            return View(result);
        }
        public ActionResult CategoryList(int id)
        {
            var result=_context.News.Where(p=>p.CategoryId== id).ToList(); 
            //liste olarak gönderdim
            return View(result);
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryList=new SelectList(_context.Categories,"CategoryId","CategoryName");
            return View();
        }

        // POST: NewsController/Create
        //YENİ KAYIT EKLEME ACTION 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News gelen,IFormFile ImageUpload)
        {
            try
            {
                if(ImageUpload == null)
                {
                    TempData["Error"] = "Resim Dosyası Boş";
                    return View();
                }
                else
                {
                    var uzanti = Path.GetExtension(ImageUpload.FileName);
                    var allowExtensions = new[] { ".jpg", ".gif", ".png", ".jpeg" };
                    //dizi oluşturduk
                    if(!allowExtensions.Contains(uzanti))
                    {
                        TempData["Error"] = "Dosya Tipi Hatalı";
                        return View();
                    }
                    if(ImageUpload.Length> 5242880)
                    {
                        TempData["Error"] = "Dosya Boyutu 5Mb Büyük Olamaz";
                        return View();
                    }
                    
                    //gonderilen dosyanın uzantısını al pdf png gif vb..
                    var newName = Guid.NewGuid().ToString() + uzanti;
                    //dosyaya yeniden isim verdik
                    string yol=Path.Combine(Directory.GetCurrentDirectory()+"/wwwroot/New_Image/",newName);
                    //dosya kayıt yerini ayarlıyoruz
                    using(var stream=new FileStream(yol, FileMode.Create)) 
                    { 
                     ImageUpload.CopyToAsync(stream);
                    }
                    gelen.NewsImage = newName;
                }
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
            ViewBag.CategoryList = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(sorgu);
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News gelen,IFormFile ImageUpload)
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
                    string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/New_Image/", newName);
                    //dosya kayıt yerini ayarlıyoruz
                    using (var stream = new FileStream(yol, FileMode.Create))
                    {
                        ImageUpload.CopyToAsync(stream);
                    }
                    gelen.NewsImage = newName;
                }





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
            var sorgu = _context.News.Find(id);
            return View(sorgu);
        }
      
        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                



                var sorgu = _context.News.Find(id);
                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/New_Image/", sorgu.NewsImage);
                if(System.IO.File.Exists(yol))
                {
                    System.IO.File.Delete(yol);
                }
                _context.News.Remove(sorgu);
                _context.SaveChanges();
                TempData["Success"] = "İşlem Başarılı";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
