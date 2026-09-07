using Microsoft.AspNetCore.Mvc;

namespace TraineeMVC.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
