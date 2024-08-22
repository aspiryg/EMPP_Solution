using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ApplicationData
{
    public class MainInfo
    {
        // Immigration Application
        [Key]
        public int Id { get; set; }
        public Guid ApplicationNumber { get; set; } = Guid.NewGuid();
        public string AppNumber { get; set; } = string.Empty;
        // Contact Information
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string WhatsApp { get; set; } = string.Empty;
        // Personal Information
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Country of Residence")]
        public string COR { get; set; } = string.Empty;
        public DateTime? DateOfEntry { get; set; }
        public string? PassportNumber { get; set; }
        public string? PassportExpiry { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string? CountryOfBirth { get; set; }

        // Occupation Information
        public string MainOccupation { get; set; } = string.Empty;

        public int YearsOfExperience { get; set; } = 0;

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

        // Navigation Property for Work History
        public ICollection<WorkHistory> WorkHistories { get; set; } = [];
    }
}
