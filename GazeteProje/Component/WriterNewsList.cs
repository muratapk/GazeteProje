using GazeteProje.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GazeteProje.Component
{
    public class WriterNewsList:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public WriterNewsList(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            //istenilen en yazılan yazıları ekrana dökelim.
            var result=_context.Corners.Include("Writer").OrderByDescending(p=>p.CornerPostId).Take(10).ToList();
            return View(result);
        }
    }
}
