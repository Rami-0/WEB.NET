using System.ComponentModel.DataAnnotations;

namespace DAL.ViewModels;

    public class RoleViewModel
    {
        [Required(ErrorMessage = "Role name is required.")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }

