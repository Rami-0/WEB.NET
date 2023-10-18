using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class UserRole
    {
        public string UserId { get; set; } // Foreign key to the user
        public string RoleId { get; set; } // Foreign key to the role

        // Navigation properties
        public ApplicationUser User { get; set; } // Reference to the user
        public IdentityRole Role { get; set; } // Reference to the role
    }
}