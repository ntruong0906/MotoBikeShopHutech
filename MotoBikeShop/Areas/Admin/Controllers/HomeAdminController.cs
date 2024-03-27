using Microsoft.AspNetCore.Mvc;

namespace MotoBikeShop.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
