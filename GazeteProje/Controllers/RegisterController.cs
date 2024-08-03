using GazeteProje.Dto;
using GazeteProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GazeteProje.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto gelen)
        {
            Random random = new Random();
            int code = 0;
            code = random.Next(10000, 1000000);
            AppUser appuser = new AppUser()
            {
                FirstName = gelen.FirstName,
                LastName = gelen.LastName,
                City = gelen.City,
                UserName = gelen.UserName,
                Email = gelen.Email,
                ConfirmCode = code.ToString(),
                EmailConfirmed = true,
            };
            var result = await _userManager.CreateAsync(appuser, gelen.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
