using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ApplicationData
{
    public class LanguageTest
    {
        public int Id { get; set; }
        public string Language { get; set; } = string.Empty;
        public string TestType { get; set; } = string.Empty;
        public string TestScore { get; set; } = string.Empty;
        public string Reading { get; set; } = string.Empty;
        public string Writing { get; set; } = string.Empty;
        public string Speaking { get; set; } = string.Empty;
        public string Listening { get; set; } = string.Empty;
        public string TestFile { get; set; } = string.Empty;
        public string TestLink { get; set; } = string.Empty;
        public bool TestLessThanTwoYears { get; set; }
        public DateTime? TestDate { get; set; }


        // Foreign Key to LanguageData
        public int LanguageDataId { get; set; }
        [ForeignKey("LanguageDataId")]
        public LanguageData LanguageData { get; set; }

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
