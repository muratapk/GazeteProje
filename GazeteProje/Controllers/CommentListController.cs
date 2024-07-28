using GazeteProje.Data;
using GazeteProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace GazeteProje.Controllers
{
    public class CommentListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentListController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        //Get

        public IActionResult ListComment(int NewsId)
        {
            return View();
        }
        public IActionResult CreateComment(Comments gelen,int NewsId)
        {
            try
            {
                _context.Comments.Add(gelen);
                _context.SaveChanges();
                //en son eklenen yorum Id numarasını alacağız
                int lastCommentId=gelen.CommentId;
                CommentAndNews tablo=new CommentAndNews();
                tablo.CommentId=lastCommentId;
                tablo.NewsId = NewsId;
                _context.CommentAndNews.Add(tablo);

                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Error"]=ex.ToString();
                return View();
                
            }
            
            
        }
    }
}
