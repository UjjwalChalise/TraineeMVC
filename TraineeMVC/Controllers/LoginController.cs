using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TraineeMVC.Repositories;
using TraineeMVC.ViewModels;

namespace TraineeMVC.Controllers;

public class LoginController : Controller
{
    private readonly IUserRepository _userRepository;

    public LoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // GET: /Login
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // POST: /Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(UserDetailsLoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userRepository.GetByUsernameAsync(model.Username);

        if (user == null)
        {
            ModelState.AddModelError(
                string.Empty,
                "Invalid username or password.");

            return View(model);
        }

        string hashedPassword = CalculateHash(model.Password);

        if (user.PasswordHash != hashedPassword)
        {
            ModelState.AddModelError(
                string.Empty,
                "Invalid username or password.");

            return View(model);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(
                "FullName",
                user.FirstName + " " + user.LastName)
        };

        var identity = new ClaimsIdentity(
            claims,
            "MyCookieAuthentication");

        var principal = new ClaimsPrincipal(identity);

        var authenticationProperties = new AuthenticationProperties
        {
            IsPersistent = model.RememberMe
        };

        await HttpContext.SignInAsync(
            "MyCookieAuthentication",
            principal,
            authenticationProperties);

        return RedirectToAction(
            "Index",
            "Admin");
    }

    // POST: /Login/Logout
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("MyCookieAuthentication");

        return RedirectToAction("Index", "Home");
    }

    private string CalculateHash(string password)
    {
        using var sha256 = SHA256.Create();

        var bytes = sha256.ComputeHash(
            Encoding.UTF8.GetBytes(password));

        return Convert.ToHexString(bytes);
    }
}