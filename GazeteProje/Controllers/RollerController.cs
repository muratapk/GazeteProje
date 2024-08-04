using GazeteProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace GazeteProje.Controllers
{
    public class RollerController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RollerController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<AppRole> roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel gelen)
        {
            if (ModelState.IsValid)
            {
                bool roleExists = await _roleManager.RoleExistsAsync(gelen?.RoleName);
                if (roleExists)
                {
                    ModelState.AddModelError("", "Bu Rol Zaten Mevcut");
                }
                else
                {
                    AppRole identityRole = new AppRole
                    {
                        Name = gelen?.RoleName
                    };
                    //identity Role nesnesi içine dışarıdan gelen rolümü atıyoruz
                    IdentityResult result = await _roleManager.CreateAsync(identityRole);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "MyAccount");
                    }
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(gelen);
        }

        [HttpGet]
        public async Task<IActionResult>EditRole(string Id)
        {
            var result = await _roleManager.FindByIdAsync(Id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult>EditRole(EditRoleViewModel gelen)
        {
            
                var role=await _roleManager.FindByIdAsync(gelen.Id);
                if(role==null)
                {
                    TempData["Error"] = "Böyle bir Rol Yok";
                    return NotFound();
                }
                else
                {
                    role.Name=gelen.Name;
                    var result=await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Roller");
                    }
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var result = await _roleManager.FindByIdAsync(Id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(EditRoleViewModel gelen)
        {

            var role = await _roleManager.FindByIdAsync(gelen.Id);
            if (role == null)
            {
                TempData["Error"] = "Böyle bir Rol Yok";
                return NotFound();
            }
            else
            {
                role.Name = gelen.Name;
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Roller");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }
    }
}
