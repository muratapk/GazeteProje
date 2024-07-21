using GazeteProje.Data;
using Microsoft.AspNetCore.Mvc;

namespace GazeteProje.Component
{
    public class RelatedNews:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public RelatedNews(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.News.ToList();
            return View(result);
        }

    }
}
