using System.ComponentModel.DataAnnotations;

namespace GazeteProje.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
