using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Data;
using TraineeMVC.Services;

namespace TraineeMVC.Controllers;

public class LoginController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly PasswordHasher _passwordService;

    public LoginController(ApplicationDbContext context, PasswordHasher passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    // GET: Login
    [HttpGet]
    public IActionResult Index(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    // POST: Login
    [HttpPost]
    [ValidateAntiForgeryToken] //prevent CSRF attacks
    public async Task<IActionResult> Index(string username, string password, string? returnUrl = null)
    {
        var user = await _context.UserDetails
             .Include(u => u.ApplicationUser)
             .FirstOrDefaultAsync(u => u.ApplicationUser.UserName == username);

        if (user == null || !_passwordService.Verify(password, user.PasswordHash))
        {
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.ApplicationUser.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties { IsPersistent = true });

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Home");
    }

    // POST: Login/Logout
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Login");
    }
}