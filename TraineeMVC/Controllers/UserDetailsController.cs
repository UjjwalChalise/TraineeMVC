using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Data;
using TraineeMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace TraineeMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserDetails.ToListAsync());
        }

        // GET: UserDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetails = await _context.UserDetails
                .FirstOrDefaultAsync(m => m.Id == id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // GET: UserDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Username,Password,Role,FirstName,LastName,DateOfBirth,Address")]
            UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(userDetails);
        }

        // GET: UserDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetails = await _context.UserDetails.FindAsync(id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // POST: UserDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Username,Password,Role,FirstName,LastName,DateOfBirth,Address")]
            UserDetails userDetails)
        {
            if (id != userDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDetailsExists(userDetails.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(userDetails);
        }

        // GET: UserDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetails = await _context.UserDetails
                .FirstOrDefaultAsync(m => m.Id == id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userDetails = await _context.UserDetails.FindAsync(id);

            if (userDetails != null)
            {
                _context.UserDetails.Remove(userDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool UserDetailsExists(int id)
        {
            return _context.UserDetails.Any(e => e.Id == id);
        }
    }
}

