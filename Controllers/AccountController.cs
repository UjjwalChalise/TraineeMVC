using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Data;
using TraineeMVC.Models;
using TraineeMVC.Services;
using TraineeMVC.ViewModel;

namespace TraineeMVC.Controllers;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(
        UserDetailsCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        string username = model.Username.Trim();

        bool usernameExists = await _context.UserDetails
            .AnyAsync(u => u.Username == username);

        if (usernameExists)
        {
            ModelState.AddModelError(
                "Username",
                "Username already exists.");

            return View(model);
        }

        var user = new UserDetails
        {
            Username = username,
            PasswordHash = PasswordHasher.Hash(model.Password),
            FirstName = model.FirstName.Trim(),
            LastName = model.LastName.Trim(),
            DateOfBirth = model.DateOfBirth,
            Address = model.Address,
            ProfileImagePath = model.ProfileImagePath
        };

        _context.UserDetails.Add(user);

        await _context.SaveChangesAsync();

        await SignInUser(user);

        return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(
        string username,
        string password,
        string? returnUrl = null)
    {
        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password))
        {
            ModelState.AddModelError(
                "",
                "Username and password are required.");

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        username = username.Trim();

        var user = await _context.UserDetails
            .FirstOrDefaultAsync(u => u.Username == username);

        if (user == null ||
            !PasswordHasher.Verify(
                password,
                user.PasswordHash))
        {
            ModelState.AddModelError(
                "",
                "Invalid username or password.");

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        await SignInUser(user);

        if (!string.IsNullOrEmpty(returnUrl) &&
            Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }

        return RedirectToAction("Index", "Home");
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login", "Account");
    }

    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View();
    }

    private async System.Threading.Tasks.Task SignInUser(UserDetails user)
    {
        var claims = new List<Claim>
        {
            new Claim(
                ClaimTypes.NameIdentifier,
                user.Id.ToString()),

            new Claim(
                ClaimTypes.Name,
                user.Username),

            new Claim(
                "FirstName",
                user.FirstName),

            new Claim(
                "LastName",
                user.LastName)
        };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);
    }
}