using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeMVC.Models;
using TraineeMVC.Repositories;

namespace TraineeMVC.Controllers;

[Authorize(Roles = "Admin")]
public class UserDetailsController : Controller
{
    private readonly IUserDetailsRepository _repository;

    public UserDetailsController(IUserDetailsRepository repository)
    {
        _repository = repository;
    }

    // GET: UserDetails
    public async Task<IActionResult> Index()
    {
        return View(await _repository.GetAll());
    }

    // GET: UserDetails/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userDetails = await _repository.GetById(id.Value);

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
            await _repository.Create(userDetails);
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

        var userDetails = await _repository.GetById(id.Value);

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
            await _repository.Update(userDetails);
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

        var userDetails = await _repository.GetById(id.Value);

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
        await _repository.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}