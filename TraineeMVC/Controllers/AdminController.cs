using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace TraineeMVC.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
