using System.ComponentModel.DataAnnotations;

namespace GazeteProje.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        public string Header1 { get; set; } = string.Empty;
        public string Header2 { get; set; }= string.Empty;
        public string Content { get;set; } = string.Empty;
        public  DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string NewsImage { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        //bir tane kategori ekleyebilirsin
    }
}
