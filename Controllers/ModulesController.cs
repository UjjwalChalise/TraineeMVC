
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Models;
using TraineeMVC.Data;

public class ModulesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ModulesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: MODULES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Modules.ToListAsync());
    }

    // GET: MODULES/Details/5
    public async Task<IActionResult> Details(int? moduleid)
    {
        if (moduleid == null)
        {
            return NotFound();
        }

        var module = await _context.Modules
            .FirstOrDefaultAsync(m => m.ModuleId == moduleid);
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
    public async Task<IActionResult> Create([Bind("ModuleId,Name,Description,CourseId,Course")] Module module)
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
    public async Task<IActionResult> Edit(int? moduleid)
    {
        if (moduleid == null)
        {
            return NotFound();
        }

        var module = await _context.Modules.FindAsync(moduleid);
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
    public async Task<IActionResult> Edit(int? moduleid, [Bind("ModuleId,Name,Description,CourseId,Course")] Module module)
    {
        if (moduleid != module.ModuleId)
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
                if (!ModuleExists(module.ModuleId))
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
    public async Task<IActionResult> Delete(int? moduleid)
    {
        if (moduleid == null)
        {
            return NotFound();
        }

        var module = await _context.Modules
            .FirstOrDefaultAsync(m => m.ModuleId == moduleid);
        if (module == null)
        {
            return NotFound();
        }

        return View(module);
    }

    // POST: MODULES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? moduleid)
    {
        var module = await _context.Modules.FindAsync(moduleid);
        if (module != null)
        {
            _context.Modules.Remove(module);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ModuleExists(int? moduleid)
    {
        return _context.Modules.Any(e => e.ModuleId == moduleid);
    }
}
