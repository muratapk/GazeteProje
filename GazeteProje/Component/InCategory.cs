using GazeteProje.Data;
using Microsoft.AspNetCore.Mvc;

namespace GazeteProje.Component
{
    public class InCategory:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public InCategory(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result=_context.News.ToList();
            return View(result);
        }
    }
}
