namespace DAL.Models;

public class Employee
{
    public int EmployeeId { get; set; } // This will be the primary key in the database.
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Email { get; set; }

    // Define a foreign key for the project this employee is assigned to.
    public int ProjectId { get; set; }

    // Define a navigation property to link to the associated project.
    public Project Project { get; set; } 

    // Add any other properties you need for employees.
}