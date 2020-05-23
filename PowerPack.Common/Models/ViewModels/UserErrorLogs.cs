using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.Models
{
    public class UserErrorLogs
    {
        public long ErrorLogId { get; set; }
        public string ErrorText { get; set; }
        public int UserId { get; set; }
        public string ModuleUrl { get; set; }
        public string UserIpAddress { get; set; }
        public string WebServerIpAddress { get; set; }
        public DateTime ReportingDate { get; set; }
        public string User { get; set; }
    }
}
