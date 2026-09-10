using Microsoft.AspNetCore.Mvc;
using TraineeMVC.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using TraineeMVC.Models;

namespace TraineeMVC.Controllers;

public class AuthenticationController : Controller
{
    private readonly IAuthenticationRepository _repository;
    private readonly PasswordHasher<UserDetails> _passwordHasher = new();

    public AuthenticationController(IAuthenticationRepository repository)
    {
        _repository = repository;
    }

    // GET: /Authentication/Login
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = await _repository.GetUserByUsername(username);

        if (user == null)
        {
            ViewBag.Error = "Invalid username or password";
            return View();
        }

        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.Password,
            password
        );

        if (result == PasswordVerificationResult.Failed)
        {
            ViewBag.Error = "Invalid username or password";
            return View();
        }

        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Role),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
    };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        return RedirectToAction("Index", "Home");
    }
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login", "Authentication");
    }



}