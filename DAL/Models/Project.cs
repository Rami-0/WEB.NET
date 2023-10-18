namespace DAL.Models;

public class Project
{
    public int ProjectId { get; set; } // This will be the primary key in the database.
    public string Name { get; set; }
    public string CustomerCompany { get; set; }
    public string PerformingCompany { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Priority { get; set; }

    // Define a navigation property for employees assigned to this project.
    public List<Employee> Employees { get; set; }
    

    // Add any other properties you need for projects.
}