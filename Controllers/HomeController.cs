using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TraineeMVC.Models;

namespace TraineeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly TraineeDbContext _context;

        public HomeController(TraineeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new DashboardViewModel
            {
                TotalStudents = _context.Students.Count(),
                TotalTeachers = _context.Teachers.Count(),
                TotalCourses = _context.Courses.Count(),
                TotalModules = _context.Modules.Count(),
                TotalTasks = _context.Tasks.Count(),
                TotalAttendance = _context.Attendances.Count(),
                TotalAssignments = _context.Assignments.Count(),
                TotalUsers = _context.Users.Count()
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}