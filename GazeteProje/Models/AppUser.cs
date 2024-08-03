using Microsoft.AspNetCore.Identity;

namespace GazeteProje.Models
{

    //Appuser IdentityUser yapısından miras alacak 
    //bunun için iki nokta üstüste koyarak IdentityUser ekliyoruz.
    public class AppUser:IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ConfirmCode { get;set; } = string.Empty;

    }
}
