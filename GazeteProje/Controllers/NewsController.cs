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
