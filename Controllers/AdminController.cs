using Microsoft.AspNetCore.Mvc;

namespace TraineeMVC.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
