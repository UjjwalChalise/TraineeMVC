using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TraineeMVC.Data;
using TraineeMVC.Models;
using TraineeMVC.Services;
using TraineeMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TraineeMVC.Controllers
{
    public class AccountController:Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher _hasher;

        public AccountController(ApplicationDbContext context, PasswordHasher hasher)
        {
            _context = context;
            _hasher = hasher;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpGet]
        public IActionResult Register() => View();
        // ----------------------

        [HttpGet]
        public IActionResult LoginStudent() => View();

        [HttpGet]
        public IActionResult LoginTeacher() => View();

        [HttpGet]
        public IActionResult RegisterStudent() => View();

        [HttpGet]
        public IActionResult RegisterTeacher() => View();


        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (await _context.ApplicationUsers.AnyAsync(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Email already registered.");
                return View(model);
            }

            var details = new UserDetails
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = _hasher.Hash(model.Password),
                ApplicationUser = new ApplicationUser { Email = model.Email, UserName = model.Email },
                Student = new Student()
            };

            _context.UserDetails.Add(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("LoginStudent");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (await _context.ApplicationUsers.AnyAsync(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Email already registered.");
                return View(model);
            }

            var details = new UserDetails
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = _hasher.Hash(model.Password),
                ApplicationUser = new ApplicationUser { Email = model.Email, UserName = model.Email },
                Teacher = new Teacher()
            };

            _context.UserDetails.Add(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("LoginTeacher");
        }

        [HttpPost]
        public async Task<IActionResult> LoginStudent(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _context.ApplicationUsers
                .Include(u => u.UserDetails).ThenInclude(d => d!.Student)
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user?.UserDetails?.Student == null || !_hasher.Verify(model.Password, user.UserDetails.PasswordHash))
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return View(model);
            }

            var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, $"{user.UserDetails.FirstName} {user.UserDetails.LastName}"),
            new(ClaimTypes.Role, "Student")
        };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> LoginTeacher(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _context.ApplicationUsers
                .Include(u => u.UserDetails).ThenInclude(d => d!.Teacher)
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user?.UserDetails?.Teacher == null || !_hasher.Verify(model.Password, user.UserDetails.PasswordHash))
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return View(model);
            }

            var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, $"{user.UserDetails.FirstName} {user.UserDetails.LastName}"),
            new(ClaimTypes.Role, "Teacher")
        };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Dashboard");
        }


        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
