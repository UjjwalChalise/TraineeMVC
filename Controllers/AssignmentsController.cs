
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Models;
using TraineeMVC.Data;

public class AssignmentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public AssignmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ASSIGNMENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Assignments.ToListAsync());
    }

    // GET: ASSIGNMENTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var assignment = await _context.Assignments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (assignment == null)
        {
            return NotFound();
        }

        return View(assignment);
    }

    // GET: ASSIGNMENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ASSIGNMENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,CourseId,Course,Title,Description,DueDate,MaximumMarks,Submissions")] Assignment assignment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(assignment);
    }

    // GET: ASSIGNMENTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var assignment = await _context.Assignments.FindAsync(id);
        if (assignment == null)
        {
            return NotFound();
        }
        return View(assignment);
    }

    // POST: ASSIGNMENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,CourseId,Course,Title,Description,DueDate,MaximumMarks,Submissions")] Assignment assignment)
    {
        if (id != assignment.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(assignment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(assignment.Id))
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
        return View(assignment);
    }

    // GET: ASSIGNMENTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var assignment = await _context.Assignments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (assignment == null)
        {
            return NotFound();
        }

        return View(assignment);
    }

    // POST: ASSIGNMENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var assignment = await _context.Assignments.FindAsync(id);
        if (assignment != null)
        {
            _context.Assignments.Remove(assignment);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AssignmentExists(int? id)
    {
        return _context.Assignments.Any(e => e.Id == id);
    }
}
