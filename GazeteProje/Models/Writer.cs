using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GazeteProje.Models
{
    public class Writer
    {
        [Key]
       public int WriterId { get; set; }
       public string Name { get; set; }=string.Empty;
       public string Email { get; set; }= string.Empty;
       public string UserName { get; set; } = string.Empty;
       public int ? PassWord { get; set; }
        public string WriterImage { get; set; } = string.Empty;
       virtual public List<CornerPost>? CornerPosts { get; set; }
        //köşe yazılarına birden fazla yazar yazı yazabilir
        //bir çok ilişkiler
        [NotMapped]
        public IFormFile? ImageUpload { get; set; }
    }
}
