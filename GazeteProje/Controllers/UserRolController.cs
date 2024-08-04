using GazeteProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GazeteProje.Controllers
{
    public class UserRolController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public UserRolController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
               
            return View();
        }
        public async Task<IActionResult>Create()
        {
            ViewBag.User = new SelectList(_userManager.Users, "Id", "UserName");
            ViewBag.Role = new SelectList(_roleManager.Roles, "Id", "Name");
            return View();
        }
    }
}
