using Microsoft.AspNetCore.Mvc;

namespace TraineeMVC.Controllers
{
    public class DashboardController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
