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

    }
}
