using GazeteProje.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GazeteProje.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<News>? News { get; set; }
        public DbSet<Writer>? Writers { get; set; }
        public DbSet<CornerPost>? Corners { get; set; }
        public DbSet<Comments>?Comments { get; set; }
        public DbSet<CommentAndNews>? CommentAndNews { get; set; }
    }
}
