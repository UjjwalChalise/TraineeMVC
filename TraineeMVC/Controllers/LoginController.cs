using Microsoft.AspNetCore.Mvc;

namespace TraineeMVC.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}