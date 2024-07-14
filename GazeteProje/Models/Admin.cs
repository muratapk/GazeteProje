using System.ComponentModel.DataAnnotations;

namespace GazeteProje.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; } = string.Empty;
        public string AdminPassWord { get; set; } = string.Empty;

    }
}
