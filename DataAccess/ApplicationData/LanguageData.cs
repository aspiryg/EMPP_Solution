using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ApplicationData
{
    public class LanguageData
    {
        [Key]
        public int Id { get; set; }
        public string ApplicantLanguage { get; set; } = string.Empty;
        public string SecondLanguage { get; set; } = string.Empty;
        public string EngApprovedTest { get; set; } = string.Empty;
        public string CELPIPReading { get; set; } = string.Empty;
        public string CELPIPWriting { get; set; } = string.Empty;
        public string CELPIPSpeaking { get; set; } = string.Empty;
        public string CELPIPListening { get; set; } = string.Empty;
        public string IELTSReading { get; set; } = string.Empty;
        public string IELTSWriting { get; set; } = string.Empty;
        public string IELTSSpeaking { get; set; } = string.Empty;
        public string IELTSListening { get; set; } = string.Empty;
        public string PTEReading { get; set; } = string.Empty;
        public string PTEWriting { get; set; } = string.Empty;
        public string PTESpeaking { get; set; } = string.Empty;
        public string PTEListening { get; set; } = string.Empty;

        public bool DoneDueLingo { get; set; }
        public string DueLingoReading { get; set; } = string.Empty;
        public string DueLingoWriting { get; set; } = string.Empty;
        public string DueLingoSpeaking { get; set; } = string.Empty;
        public string DueLingoListening { get; set; } = string.Empty;

        public string FrenchApprovedTest { get; set; } = string.Empty;

        // Navigation Property to LanguageTest
        public ICollection<LanguageTest> LanguageTests { get; set; }


        // Foreign Key to Initial Stage
        public int InitialStageId { get; set; }
        [ForeignKey("InitialStageId")]
        public InitialStage InitialStage { get; set; }


        // System Information
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
