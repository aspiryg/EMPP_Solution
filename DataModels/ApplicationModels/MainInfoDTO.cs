using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.ApplicationModels
{
    public class MainInfoDTO
    {
        // Immigration Application
        public int Id { get; set; }
        public Guid ApplicationNumber { get; set; } = Guid.NewGuid();
        public string AppNumber { get; set; } = string.Empty;
        // Contact Information
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;
        [Display(Name = "WhatsApp Number")]
        public string WhatsApp { get; set; } = string.Empty;
        // Personal Information
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; } = string.Empty;
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Country of Residence")]
        public string COR { get; set; } = string.Empty;
        [Display(Name = "Date of Entry")]
        public DateTime? DateOfEntry { get; set; }
        [Display(Name = "Passport Number")]
        public string? PassportNumber { get; set; }
        [Display(Name = "Passport Expiry")]
        public string? PassportExpiry { get; set; }
        [Display(Name = "Address Line 1")]
        public string? AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }
        [Display(Name = "City")]
        public string? City { get; set; }
        [Display(Name = "State")]
        public string? State { get; set; }
        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }
        [Display(Name = "National")]
        public string Nationality { get; set; } = string.Empty;
        [Display(Name = "Country of Birth")]
        public string? CountryOfBirth { get; set; }

        // Occupation Information
        [Display(Name = "Main Occupation")]
        public string MainOccupation { get; set; } = string.Empty;
        [Display(Name = "Years of Experience")]
        public int YearsOfExperience { get; set; }

        // System Information
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }

        // Foreign Key for the User
        public string UserId { get; set; } = string.Empty;


        // Navigation Property for Initial Stage
        public int InitialStageId { get; set; }
        public InitialStageDTO InitialStage { get; set; }

    }
}
