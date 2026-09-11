using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TraineeMVC.Data;
using TraineeMVC.Models;
using TraineeMVC.Services;
using TraineeMVC.ViewModels;

namespace TraineeMVC.Controllers
{
    public class AccountController : Controller
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

        [HttpGet]
        public IActionResult LoginStudent() => View();

        [HttpGet]
        public IActionResult LoginTeacher() => View();

        [HttpGet]
        public IActionResult RegisterStudent() => View();

        [HttpGet]
        public IActionResult RegisterTeacher() => View();

        private async Task<UserDetails> RegisterUser(RegisterViewModel model)
        {
            var details = new UserDetails
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = _hasher.Hash(model.Password),

                ApplicationUser = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email
                }
            };

            _context.UserDetails.Add(details);
            await _context.SaveChangesAsync();

            return details;
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await _context.ApplicationUsers.AnyAsync(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Email already registered.");
                return View(model);
            }

            var details = await RegisterUser(model);

            var student = new Student
            {
                UserDetailsId = details.Id
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(LoginStudent));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await _context.ApplicationUsers.AnyAsync(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Email already registered.");
                return View(model);
            }

            var details = await RegisterUser(model);

            var teacher = new Teacher
            {
                UserDetailsId = details.Id
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(LoginTeacher));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _context.ApplicationUsers
                .Include(u => u.UserDetails)
                    .ThenInclude(u => u!.Student)
                .Include(u => u.UserDetails)
                    .ThenInclude(u => u!.Teacher)
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            bool validPassword = _hasher.Verify(
                model.Password,
                user.UserDetails!.PasswordHash);

            if (!validPassword)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            var claims = new List<Claim>
    {
        new Claim(
            ClaimTypes.NameIdentifier,
            user.Id.ToString()),

        new Claim(
            ClaimTypes.Name,
            $"{user.UserDetails.FirstName} {user.UserDetails.LastName}")
    };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            if (user.UserDetails.Student != null)
            {
                return RedirectToAction(
                    "Index",
                    "Student");
            }

            if (user.UserDetails.Teacher != null)
            {
                return RedirectToAction(
                    "Index",
                    "Teacher");
            }

            ModelState.AddModelError("", "Account type not found.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }


    }
}
