
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Models;


public class TasksController : Controller
{
    private readonly TraineeDbContext _context;

    public TasksController(TraineeDbContext context)
    {
        _context = context;
    }

    // GET: TASKSS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Tasks.ToListAsync());
    }

    // GET: TASKSS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tasks = await _context.Tasks
            .FirstOrDefaultAsync(m => m.Id == id);
        if (tasks == null)
        {
            return NotFound();
        }

        return View(tasks);
    }

    // GET: TASKSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TASKSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description")] Tasks tasks)
    {
        if (ModelState.IsValid)
        {
            _context.Add(tasks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tasks);
    }

    // GET: TASKSS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tasks = await _context.Tasks.FindAsync(id);
        if (tasks == null)
        {
            return NotFound();
        }
        return View(tasks);
    }

    // POST: TASKSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Description")] Tasks tasks)
    {
        if (id != tasks.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(tasks);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(tasks.Id))
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
        return View(tasks);
    }

    // GET: TASKSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tasks = await _context.Tasks
            .FirstOrDefaultAsync(m => m.Id == id);
        if (tasks == null)
        {
            return NotFound();
        }

        return View(tasks);
    }

    // POST: TASKSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var tasks = await _context.Tasks.FindAsync(id);
        if (tasks != null)
        {
            _context.Tasks.Remove(tasks);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TasksExists(int? id)
    {
        return _context.Tasks.Any(e => e.Id == id);
    }
}
