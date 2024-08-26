using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ApplicationData
{
    public class ApplicantLanguage
    {
        public int Id { get; set; }
        public string Language { get; set; } = string.Empty;
        public string Proficiency { get; set; } = string.Empty;
    }
}
