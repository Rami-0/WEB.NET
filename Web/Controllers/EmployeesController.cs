// WEB\Controllers\EmployeesController.cs

using DAL;
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
    
    public IActionResult Create()
    {
        return View();
    }
    
    public IActionResult Edit(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        if (employee == null)
        {
            return NotFound(); // Handle employee not found
        }
        return View(employee);
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