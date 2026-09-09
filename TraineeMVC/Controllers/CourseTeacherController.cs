using Microsoft.AspNetCore.Mvc;

namespace TraineeMVC.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Data;
using TraineeMVC.Models;

public class CourseTeacherController : Controller
{
    private readonly ApplicationDbContext _context;

    public CourseTeacherController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CourseTeacher
    public async Task<IActionResult> Index()
    {
        var courseTeachers = _context.CourseTeachers
            .Include(ct => ct.Course)
            .Include(ct => ct.Teacher)
                .ThenInclude(t => t.UserDetails);

        return View(await courseTeachers.ToListAsync());
    }

    // GET: CourseTeacher/Create
    public IActionResult Create()
    {
        PopulateDropdowns();
        return View();
    }

    // POST: CourseTeacher/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseTeacher courseTeacher)
    {
        bool alreadyExists = await _context.CourseTeachers.AnyAsync(ct =>
            ct.CourseId == courseTeacher.CourseId &&
            ct.TeacherId == courseTeacher.TeacherId);

        if (alreadyExists)
        {
            ModelState.AddModelError(
                "", "This teacher is already assigned to this course.");
        }

        if (ModelState.IsValid)
        {
            _context.Add(courseTeacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        PopulateDropdowns(courseTeacher.CourseId, courseTeacher.TeacherId);
        return View(courseTeacher);
    }

    // GET: CourseTeacher/Delete?courseId=1&teacherId=2
    public async Task<IActionResult> Delete(int? courseId, int? teacherId)
    {
        if (courseId == null || teacherId == null)
        {
            return NotFound();
        }

        var courseTeacher = await _context.CourseTeachers
            .Include(ct => ct.Course)
            .Include(ct => ct.Teacher)
                .ThenInclude(t => t.UserDetails)
            .FirstOrDefaultAsync(ct =>
                ct.CourseId == courseId && ct.TeacherId == teacherId);

        if (courseTeacher == null)
        {
            return NotFound();
        }

        return View(courseTeacher);
    }

    // POST: CourseTeacher/Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int courseId, int teacherId)
    {
        var courseTeacher = await _context.CourseTeachers
            .FindAsync(courseId, teacherId);

        if (courseTeacher != null)
        {
            _context.CourseTeachers.Remove(courseTeacher);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private void PopulateDropdowns(int? selectedCourseId = null, int? selectedTeacherId = null)
    {
        ViewBag.CourseId = new SelectList(
            _context.Courses, "Id", "Title", selectedCourseId);

        var teachers = _context.Teachers
            .Include(t => t.UserDetails)
            .Select(t => new
            {
                t.Id,
                FullName = t.UserDetails.FirstName + " " + t.UserDetails.LastName
            })
            .ToList();

        ViewBag.TeacherId = new SelectList(
            teachers, "Id", "FullName", selectedTeacherId);
    }
}