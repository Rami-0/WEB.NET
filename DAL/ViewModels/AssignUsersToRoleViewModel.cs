using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAL.ViewModels;
public class AssignUsersToRoleViewModel
{
    [Required(ErrorMessage = "Role name is required.")]
    [Display(Name = "Role Name")]
    public string RoleName { get; set; }

    [Display(Name = "Users")] public List<SelectListItem> Users { get; set; }

    [Required(ErrorMessage = "Please select at least one user.")]
    [Display(Name = "Selected Users")]
    public List<string> SelectedUsers { get; set; }
}