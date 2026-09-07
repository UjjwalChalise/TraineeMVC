using Microsoft.AspNetCore.Mvc;

namespace TraineeMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
