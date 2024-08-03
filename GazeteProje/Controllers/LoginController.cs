using GazeteProje.Dto;
using GazeteProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GazeteProje.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto gelen)
        {
            var result =await _signInManager.PasswordSignInAsync(gelen.UserName, gelen.Password, false, true);
            if(result.Succeeded)
            { 
               var user=await _userManager.FindByNameAsync(gelen.UserName);
                return RedirectToAction("Index", "MyAccount");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            
        }
    }
}
