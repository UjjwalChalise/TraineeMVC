using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TraineeMVC.Models;
using TraineeMVC.Repositories;
using TraineeMVC.ViewModels;

namespace TraineeMVC.Controllers;

public class UserDetailsController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserDetailsController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // GET: /UserDetails/Create
    [HttpGet]
    public IActionResult Create()
    {
        var model = new UserCreateViewModel();

        return View(model);
    }

    // POST: /UserDetails/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UserCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Check whether the username is already taken
        if (await _userRepository.UsernameExistsAsync(model.Username))
        {
            ModelState.AddModelError(
                "Username",
                "This username is already taken.");

            return View(model);
        }

        // Convert AccountType into the relationships
        switch (model.AccountType)
        {
            case "Student":
                model.IsStudent = true;
                model.IsTeacher = false;
                break;

            case "Teacher":
                model.IsTeacher = true;
                model.IsStudent = false;
                break;

            case "Both":
                model.IsTeacher = true;
                model.IsStudent = true;
                break;

            default:
                ModelState.AddModelError(
                    "AccountType",
                    "Please select an account type.");

                return View(model);
        }

        // Create the UserDetails entity
        var user = new UserDetails
        {
            Username = model.Username,
            PasswordHash = CalculateHash(model.Password),
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            Address = model.Address,
            ProfileImagePath = model.ProfileImagePath
        };

        // Create Teacher record when selected
        if (model.IsTeacher)
        {
            user.Teacher = new Teacher
            {
                EmployeeNumber = model.EmployeeNumber,
                Department = model.Department,
                Qualification = model.Qualification
            };
        }

        // Create Student record when selected
        if (model.IsStudent)
        {
            user.Student = new Student
            {
                StudentNumber = model.StudentNumber,
                Program = model.Program,
                Semester = model.Semester
            };
        }

        await _userRepository.AddAsync(user);

        return RedirectToAction(
            "Index",
            "Login");
    }

    private string CalculateHash(string password)
    {
        using var sha256 = SHA256.Create();

        var bytes = sha256.ComputeHash(
            Encoding.UTF8.GetBytes(password));

        return Convert.ToHexString(bytes);
    }
}