using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.ApplicationModels
{
    public class LanguageTestDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Language is required")]
        public string Language { get; set; } = string.Empty;
        [Required(ErrorMessage = "Test Type is required")]
        public string TestType { get; set; } = string.Empty;
        public string TestScore { get; set; } = string.Empty;
        // Only Numeric Value
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public string Reading { get; set; } = string.Empty;
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public string Writing { get; set; } = string.Empty;
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public string Speaking { get; set; } = string.Empty;
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public string Listening { get; set; } = string.Empty;
        public string TestFile { get; set; } = string.Empty;
        // public IBrowserFile TestFileUpload { get; set; }
        public string TestLink { get; set; } = string.Empty;
        public bool TestLessThanTwoYears { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Test Date is required")]
        public DateTime? TestDate { get; set; }


        // Foreign Key to LanguageData
        public int LanguageDataId { get; set; }
        public LanguageDataDTO LanguageData { get; set; }


        // System Information
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }

        // Methods

        // array of test scores of reading, writing, speaking, and listening
        public IEnumerable<int> TestScores
        {
            get
            {
                return [int.Parse(Reading), int.Parse(Writing), int.Parse(Speaking), int.Parse(Listening)];
            }
        }

        // join the test scores into a single string
        public void JoinTestScores()
        {
            TestScore = string.Join(",", TestScores);
        }

        // Average of the test scores
        public double AverageTestScore()
        {
            return TestScores.Average();
        }

        public int TotalTestScore()
        {
            return TestScores.Sum();
        }

        // Check if the test is less than two years
        public bool SetTestLessThanTwoYears()
        {
            if (TestDate != null)
            {
                return  TestDate.Value.AddYears(2) > DateTime.Now;
            }
            return false;
        }
        
    }
}
