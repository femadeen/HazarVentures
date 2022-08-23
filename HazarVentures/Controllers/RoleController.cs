using Microsoft.AspNetCore.Mvc;

namespace HazarVentures.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
