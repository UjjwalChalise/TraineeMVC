using Microsoft.AspNetCore.Mvc;

namespace TraineeMVC.Controllers
{
    public class Accountcontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
