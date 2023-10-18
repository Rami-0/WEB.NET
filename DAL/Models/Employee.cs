using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DAL.Models;

public class Employee
{
    [Key] public int EmployeeId { get; set; } // This will be the primary key in the database.

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Surname is required.")]
    [StringLength(50)]
    public string Surname { get; set; }
    
    [StringLength(50)]
    public string Patronymic { get; set; }
    
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    // Define a foreign key for the project this employee is assigned to.
    public int ProjectId { get; set; }

    // Define a navigation property to link to the associated project.
    [ForeignKey("ProjectId")]
    public Project Project { get; set; } 

    // Add any other properties you need for employees.
}