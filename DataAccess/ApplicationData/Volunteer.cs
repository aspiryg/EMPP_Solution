using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ApplicationData
{
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }
        public Guid ApplicationNumber { get; set; } = Guid.NewGuid();
        public string AppNumber { get; set; } = string.Empty;

        // Contact Information
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string WhatsApp { get; set; } = string.Empty;

        // Address Information
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }


        // Personal Information
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;

        // Occupation Information
        public string MainOccupation { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; } = 0;
        public string? HighestEducation { get; set; }
        public string? Language { get; set; }
        public string? ReadingLevel { get; set; }
        public string? WritingLevel { get; set; }
        public string? SpeakingLevel { get; set; }
        public string? ListeningLevel { get; set; }
        public string? VolunteerArea { get; set; }
        public string? VolunteerSkills { get; set; }
        public int WeeklyVolunteeringHours { get; set; }
        public string? VolunteeringAvailability { get; set; }
        public string? VolunteeringReason { get; set; }
        public string? VolunteeringExpectation { get; set; }
        public string? VolunteeringExperience { get; set; }

        // System Information
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }


        public string UserId { get; set; } = string.Empty;
    }
}
