using GazeteProje.Data;
using Microsoft.AspNetCore.Mvc;

namespace GazeteProje.Component
{
    public class SliderRight:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SliderRight(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.News.OrderByDescending(p => p.NewsId).Skip(4).Take(4).ToList();
            //ilk dört haberi at skip sonraki dört haberi al take kullandık
            return View(result);
        }
    }
}
