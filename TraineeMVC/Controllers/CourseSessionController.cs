
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Models;
using TraineeMVC.Data;

public class CourseSessionController : Controller
{
    private readonly ApplicationDbContext _context;

    public CourseSessionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: COURSESESSIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.CourseSessions.ToListAsync());
    }

    // GET: COURSESESSIONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var coursesession = await _context.CourseSessions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (coursesession == null)
        {
            return NotFound();
        }

        return View(coursesession);
    }

    // GET: COURSESESSIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: COURSESESSIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,CourseId,Course,SessionDate,StartTime,EndTime,Topic,Attendances")] CourseSession coursesession)
    {
        if (ModelState.IsValid)
        {
            _context.Add(coursesession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(coursesession);
    }

    // GET: COURSESESSIONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var coursesession = await _context.CourseSessions.FindAsync(id);
        if (coursesession == null)
        {
            return NotFound();
        }
        return View(coursesession);
    }

    // POST: COURSESESSIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,CourseId,Course,SessionDate,StartTime,EndTime,Topic,Attendances")] CourseSession coursesession)
    {
        if (id != coursesession.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(coursesession);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseSessionExists(coursesession.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(coursesession);
    }

    // GET: COURSESESSIONS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var coursesession = await _context.CourseSessions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (coursesession == null)
        {
            return NotFound();
        }

        return View(coursesession);
    }

    // POST: COURSESESSIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var coursesession = await _context.CourseSessions.FindAsync(id);
        if (coursesession != null)
        {
            _context.CourseSessions.Remove(coursesession);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CourseSessionExists(int? id)
    {
        return _context.CourseSessions.Any(e => e.Id == id);
    }
}
