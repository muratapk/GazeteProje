using System.ComponentModel.DataAnnotations;

namespace GazeteProje.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name ="Rol Seçimi")]
        public string RoleName { get; set; }    
    }
}
