using Microsoft.AspNetCore.Identity;
namespace DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfileImage { get; set; }
        
        // Navigation properties
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Project> Projects { get; set; }

        // Custom methods (optional)
        public void UpdateProfilePicture(string imageUrl)
        {
            // Implement logic to update the user's profile picture
        }

        // You can add additional properties specific to your user here
    }
}
