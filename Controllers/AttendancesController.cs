
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Models;

public class AttendancesController : Controller
{
    private readonly TraineeDbContext _context;

    public AttendancesController(TraineeDbContext context)
    {
        _context = context;
    }

    // GET: ATTENDANCES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Attendances.ToListAsync());
    }

    // GET: ATTENDANCES/Details/5
    public async Task<IActionResult> Details(int? attendanceid)
    {
        if (attendanceid == null)
        {
            return NotFound();
        }

        var attendance = await _context.Attendances
            .FirstOrDefaultAsync(m => m.AttendanceId == attendanceid);
        if (attendance == null)
        {
            return NotFound();
        }

        return View(attendance);
    }

    // GET: ATTENDANCES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ATTENDANCES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("AttendanceId,StudentId,CourseId,AttendanceDate,Status,Student,Course")] Attendance attendance)
    {
        if (ModelState.IsValid)
        {
            _context.Add(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(attendance);
    }

    // GET: ATTENDANCES/Edit/5
    public async Task<IActionResult> Edit(int? attendanceid)
    {
        if (attendanceid == null)
        {
            return NotFound();
        }

        var attendance = await _context.Attendances.FindAsync(attendanceid);
        if (attendance == null)
        {
            return NotFound();
        }
        return View(attendance);
    }

    // POST: ATTENDANCES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? attendanceid, [Bind("AttendanceId,StudentId,CourseId,AttendanceDate,Status,Student,Course")] Attendance attendance)
    {
        if (attendanceid != attendance.AttendanceId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(attendance);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(attendance.AttendanceId))
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
        return View(attendance);
    }

    // GET: ATTENDANCES/Delete/5
    public async Task<IActionResult> Delete(int? attendanceid)
    {
        if (attendanceid == null)
        {
            return NotFound();
        }

        var attendance = await _context.Attendances
            .FirstOrDefaultAsync(m => m.AttendanceId == attendanceid);
        if (attendance == null)
        {
            return NotFound();
        }

        return View(attendance);
    }

    // POST: ATTENDANCES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? attendanceid)
    {
        var attendance = await _context.Attendances.FindAsync(attendanceid);
        if (attendance != null)
        {
            _context.Attendances.Remove(attendance);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AttendanceExists(int? attendanceid)
    {
        return _context.Attendances.Any(e => e.AttendanceId == attendanceid);
    }
}
