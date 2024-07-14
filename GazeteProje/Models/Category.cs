using System.ComponentModel.DataAnnotations;

namespace GazeteProje.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public virtual List<News>? News { get; set; }
        //bir çok ilişki oluşturduk
        //kategoriler birtane ama haberler bir fazla kategori 
        //eklenebilir
    }
}
