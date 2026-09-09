
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Models;
using TraineeMVC.Data;

public class ModuleController : Controller
{
    private readonly ApplicationDbContext _context;

    public ModuleController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: MODULES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Modules.ToListAsync());
    }

    // GET: MODULES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var module = await _context.Modules
            .FirstOrDefaultAsync(m => m.Id == id);
        if (module == null)
        {
            return NotFound();
        }

        return View(module);
    }

    // GET: MODULES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MODULES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,Courses")] Module module)
    {
        if (ModelState.IsValid)
        {
            _context.Add(module);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(module);
    }

    // GET: MODULES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var module = await _context.Modules.FindAsync(id);
        if (module == null)
        {
            return NotFound();
        }
        return View(module);
    }

    // POST: MODULES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Description,Courses")] Module module)
    {
        if (id != module.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(module);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(module.Id))
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
        return View(module);
    }

    // GET: MODULES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var module = await _context.Modules
            .FirstOrDefaultAsync(m => m.Id == id);
        if (module == null)
        {
            return NotFound();
        }

        return View(module);
    }

    // POST: MODULES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var module = await _context.Modules.FindAsync(id);
        if (module != null)
        {
            _context.Modules.Remove(module);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ModuleExists(int? id)
    {
        return _context.Modules.Any(e => e.Id == id);
    }
}
