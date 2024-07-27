using System.ComponentModel.DataAnnotations;

namespace GazeteProje.Models
{
    public class CornerPost
    {
        [Key]
        public int CornerPostId { get; set; }
        public string Header { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        
        public DateTime? CreatedCorner { get; set; }
        public DateTime? UpdatedCorner { get;set; }
        public int WriterId { get;set; }
        virtual public Writer? Writer { get; set; }
        //yazarlar tablosu ile yazı tablosu arasında bir
        //ilişki oluştur.
        public int read { get;set; }
    }
}
