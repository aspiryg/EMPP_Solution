﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.ApplicationModels
{
    public class WorkHistoryDTO
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ReasonForLeaving { get; set; } = string.Empty;
        public string ContractType { get; set; } = string.Empty;
        public string TypeOfEmployment { get; set; } = string.Empty;
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? SupervisorName { get; set; }
        public string? SupervisorPhone { get; set; }
        public string? SupervisorEmail { get; set; }
        public bool CanContact { get; set; }
        public bool IsCurrentJob { get; set; }

        // System Information
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }

        // Foreign Key
        public int AppId { get; set; }
        public InitialStageDTO Application { get; set; }

        // Navigation Property for Skill
        public ICollection<SkillDTO> Skills { get; set; } = [];

        // Navigation Property for WorkAchievement
        public ICollection<WorkAchievementDTO> WorkAchievements { get; set; } = [];
    }
}
