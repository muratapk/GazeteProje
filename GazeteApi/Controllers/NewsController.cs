using GazeteApi.Data;
using GazeteApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GazeteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
            //veritabanındaki bağlantı oluşturan kısmına 
        }
        //get veri çekmek için
        //post yeni veri eklemek için
        //update güncellemek
        //Delete silmek için
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>>GetNews()
        {
            return await _context.News.ToListAsync();
        }
        //bir id numarasına göre haber çağırmak için kullanılan method

        [HttpGet("id")]
        public async Task<ActionResult<News>>GetNews(int id)
        {
            return await _context.News.FindAsync(id);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<News>>DeleteNews(int id)
        {
            var result = await _context.News.FindAsync(id);
            if(result!=null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();

            }
            return result;
            //boş olan veri geri gönder
        }
        [HttpPost]
        public async Task<ActionResult<News>>AddNews(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<News>>UpdateNews(int id,News news)
        {
            var result = await _context.News.FindAsync(id);
            //veritabanın id 5 olanları getir result içine attım 
            //eski veriler burada duruyor
            if(result!=null)
            {
                //result kullanılan eski veriler
                result.Header1 = news.Header1;//yeni veriler
                result.Header2 = news.Header2;
                result.CreateDate = news.CreateDate;
                result.UpdateDate = news.UpdateDate;
                result.CategoryId = news.CategoryId;
                result.Content = news.Content;
                await _context.SaveChangesAsync();
            }
            return result;
        }



    }
}
