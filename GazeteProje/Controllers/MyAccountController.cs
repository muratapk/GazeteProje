using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GazeteProje.Controllers
{
    public class MyAccountController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
