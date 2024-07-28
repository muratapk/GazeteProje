using GazeteProje.Data;
using GazeteProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace GazeteProje.Component
{
    public class CommentList:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CommentList(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int NewsId)
        {
            //var result=_context.CommentAndNews.Where(p=>p.NewsId==NewsId).FirstOrDefault();
            //NewsId Numarasına göre CommentAndNews tablosunda o habere ait
            //aciklama Id Numarasını al 
            //var yorumlar = _context.Comments.Where(p => p.CommentId == result.CommentId).ToList();
            //yorumlar içerisinde Id numarası çekilen yorumId Numarasına göre 
            //tüm yorumları getir

            //return View(yorumlar);
            //inner join ile birleştirme
            var query = (from c in _context.Comments
                         join cn in _context.CommentAndNews on c.CommentId equals cn.CommentId
                         where cn.NewsId == NewsId
                         select new
                         {
                             CommentName = c.CommentName,
                             CommentContent = c.CommentContent,
                         }).ToList();
            return View(query);
        }
    }
}
