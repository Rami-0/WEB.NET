// WEB\Controllers\EmployeesController.cs

using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class EmployeesController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployeesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var employees = _context.Employees.ToList();
        return View(employees);
    }

    // Add actions for creating, editing, and deleting employees

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            // Data is valid, save to the database
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(employee); // Return to the "Create" view with validation errors
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Employee employee)
    {
        if (ModelState.IsValid)
        {
            // Data is valid, update the employee in the database
            _context.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(employee); // Return to the "Edit" view with validation errors
    }

    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        if (employee == null)
        {
            return NotFound(); // Handle employee not found
        }

        return View(employee);
    }
}