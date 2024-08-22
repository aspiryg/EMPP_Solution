using Microsoft.AspNetCore.Identity;

namespace EMPP_Server.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        // Personal Information
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }

}
