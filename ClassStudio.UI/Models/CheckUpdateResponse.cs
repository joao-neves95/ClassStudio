using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassStudio.UI.Models
{
    public class CheckUpdateResponse
    {
        public bool UpdateAvailable { get; set; }

        public string CurrentVersion { get; set; }

        public string NewAvailableVersion { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }
}
