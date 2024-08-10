using GazeteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GazeteApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        //costuctor nesne bu nedemek çağır çağırmaz otomatik database bağlanacak
        //public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //dbcontextoptions ayarlarını ApplicationDbContext ata
        //base(options) varsayılan ayar olarak dbcontext ayarları baz al
        public DbSet<News> News { get; set; }   

    }
}
