
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Models;
using TraineeMVC.Data;

public class AssignmentSubmissionController : Controller
{
    private readonly ApplicationDbContext _context;

    public AssignmentSubmissionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ASSIGNMENTSUBMISSIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.AssignmentSubmissions.ToListAsync());
    }

    // GET: ASSIGNMENTSUBMISSIONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var assignmentsubmission = await _context.AssignmentSubmissions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (assignmentsubmission == null)
        {
            return NotFound();
        }

        return View(assignmentsubmission);
    }

    // GET: ASSIGNMENTSUBMISSIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ASSIGNMENTSUBMISSIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,AssignmentId,Assignment,StudentId,Student,SubmittedAt,FilePath,Content,Grade,Feedback")] AssignmentSubmission assignmentsubmission)
    {
        if (ModelState.IsValid)
        {
            _context.Add(assignmentsubmission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(assignmentsubmission);
    }

    // GET: ASSIGNMENTSUBMISSIONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var assignmentsubmission = await _context.AssignmentSubmissions.FindAsync(id);
        if (assignmentsubmission == null)
        {
            return NotFound();
        }
        return View(assignmentsubmission);
    }

    // POST: ASSIGNMENTSUBMISSIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,AssignmentId,Assignment,StudentId,Student,SubmittedAt,FilePath,Content,Grade,Feedback")] AssignmentSubmission assignmentsubmission)
    {
        if (id != assignmentsubmission.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(assignmentsubmission);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentSubmissionExists(assignmentsubmission.Id))
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
        return View(assignmentsubmission);
    }

    // GET: ASSIGNMENTSUBMISSIONS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var assignmentsubmission = await _context.AssignmentSubmissions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (assignmentsubmission == null)
        {
            return NotFound();
        }

        return View(assignmentsubmission);
    }

    // POST: ASSIGNMENTSUBMISSIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var assignmentsubmission = await _context.AssignmentSubmissions.FindAsync(id);
        if (assignmentsubmission != null)
        {
            _context.AssignmentSubmissions.Remove(assignmentsubmission);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AssignmentSubmissionExists(int? id)
    {
        return _context.AssignmentSubmissions.Any(e => e.Id == id);
    }
}
