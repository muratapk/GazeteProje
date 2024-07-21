using GazeteProje.Data;
using Microsoft.AspNetCore.Mvc;

namespace GazeteProje.Component
{
    public class SliderList:ViewComponent
    {
        //constructor  class üzerine ctrl+. noktaya bas
        private readonly ApplicationDbContext _context;

        public SliderList(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            //var result = _context.News.ToList();
            //tüm haberleri al ToList();
            var result=_context.News.OrderByDescending(p=>p.NewsId).Take(4).ToList();
            //en son dört haberi al 
            return View(result);
        }
    }
}
