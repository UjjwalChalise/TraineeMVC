using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace TraineeMVC.Controllers;

[Authorize]

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
