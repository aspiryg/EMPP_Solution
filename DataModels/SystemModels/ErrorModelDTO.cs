using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.SystemModels
{
    public class ErrorModelDTO
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string? Title { get; set; }
        public string? StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
