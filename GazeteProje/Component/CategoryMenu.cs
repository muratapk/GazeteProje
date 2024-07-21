using GazeteProje.Data;
using Microsoft.AspNetCore.Mvc;

namespace GazeteProje.Component
{
    public class CategoryMenu:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CategoryMenu(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.Categories.ToList();
            return View(result);
        }
    }
}
