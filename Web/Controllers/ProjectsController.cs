// WEB\Controllers\ProjectsController.cs

using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ProjectsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProjectsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // public IActionResult Index()
    // {
    //     var projects = _context.Projects.ToList();
    //     return View(projects);
    // }

    public IActionResult Index(DateTime? startDate, DateTime? endDate, int? priority, string sortOrder)
    {
        // Retrieve projects from the database
        var projects = _context.Projects.AsQueryable();

        // Filtering
        if (startDate != null)
        {
            projects = projects.Where(p => p.StartDate >= startDate);
        }

        if (endDate != null)
        {
            projects = projects.Where(p => p.EndDate <= endDate);
        }

        if (priority != null)
        {
            projects = projects.Where(p => p.Priority == priority);
        }

        // Sorting
        ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["CustomerSortParam"] = sortOrder == "Customer" ? "customer_desc" : "Customer";
        ViewData["StartDateSortParam"] = sortOrder == "StartDate" ? "startdate_desc" : "StartDate";
        ViewData["EndDateSortParam"] = sortOrder == "EndDate" ? "enddate_desc" : "EndDate";
        ViewData["PrioritySortParam"] = sortOrder == "Priority" ? "priority_desc" : "Priority";

        switch (sortOrder)
        {
            case "name_desc":
                projects = projects.OrderByDescending(p => p.Name);
                break;
            case "Customer":
                projects = projects.OrderBy(p => p.CustomerCompany);
                break;
            case "customer_desc":
                projects = projects.OrderByDescending(p => p.CustomerCompany);
                break;
            case "StartDate":
                projects = projects.OrderBy(p => p.StartDate);
                break;
            case "startdate_desc":
                projects = projects.OrderByDescending(p => p.StartDate);
                break;
            case "EndDate":
                projects = projects.OrderBy(p => p.EndDate);
                break;
            case "enddate_desc":
                projects = projects.OrderByDescending(p => p.EndDate);
                break;
            case "Priority":
                projects = projects.OrderBy(p => p.Priority);
                break;
            case "priority_desc":
                projects = projects.OrderByDescending(p => p.Priority);
                break;
            default:
                projects = projects.OrderBy(p => p.Name);
                break;
        }

        return View(projects.ToList());
    }

    public IActionResult AddEmployee(int projectId, int employeeId)
    {
        // Implement logic to associate an employee with a project
        return null!;
    }

    public IActionResult RemoveEmployee(int projectId, int employeeId)
    {
        // Implement logic to disassociate an employee from a project
        return null!;
    }
    
    public IActionResult Details(int id)
    {
        var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
        if (project == null)
        {
            return NotFound(); // Handle project not found
        }
        return View(project);
    }

    // Add actions for creating, editing, and deleting projects
}