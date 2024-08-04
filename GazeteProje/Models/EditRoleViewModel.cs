using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GazeteProje.Models
{
    public class EditRoleViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage ="Rolü Boş Bırakamazsınız")]
        [Display(Name="Rol Adı")]
        public string Name { get; set; }

    }
}
