using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotorOil.WebUI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Admin")]
        [Authorize(Policy = "admin.dashboard.index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
