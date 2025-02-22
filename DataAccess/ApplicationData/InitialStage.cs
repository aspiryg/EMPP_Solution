﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ApplicationData
{
    public class InitialStage
    {
        public int Id { get; set; }
        public Guid ApplicationNumber { get; set; } = Guid.NewGuid();

        // Application Information
        public string ApplicationMainCategory { get; set; } = string.Empty; // Immigration, Volunteer, Other
        public string ApplicationSubCategory { get; set; } = string.Empty; // Permanent Residence, Work Permit, Study Permit, Visitor Visa, Refugee Claim, Volunteer, Other
        public string ApplicationType { get; set; } = string.Empty; // Federal, Quebec, Provincial, Refugee, Volunteer, Other
        public string ApplicationStatus { get; set; } = string.Empty; // In Progress, Submitted, Approved, Rejected, Other
        public string ApplicationStage { get; set; } = string.Empty; // Initial, Second, Third, Fourth, Fifth, Sixth, Seventh, Eighth, Ninth, Tenth, Other

        // Personal Information
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Understanding the terms and conditions of the application
        public bool TermsAndConditions { get; set; }
        // Understanding the privacy policy of the application
        public bool PrivacyPolicy { get; set; }
        // Confirming the information provided is true and accurate
        public bool ConfirmInformation { get; set; }
        // volunteer to participate in the application
        public string? VolunteeringAvailability { get; set; } = string.Empty;
        public string VolunteeringArea { get; set; } = string.Empty;
        public string VolunteeringSkills { get; set; } = string.Empty;
        public int WeeklyVolunteeringHours { get; set; }
        public bool AgeConfirmation { get; set; }
        public bool IsRefugee { get; set; }
        public bool IsLivingInCanada { get; set; }
        public bool WantToResideInQuebec { get; set; }
        public bool HasPreviousApplication { get; set; }
        public string PreviousApplicationDetails { get; set; } = string.Empty;

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

        // one to one relationship with LanguageData
        public LanguageData LanguageData { get; set; }

    }
}
