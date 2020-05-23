using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.Models
{
    public class UserNotificationView
    {
        public DateTime Date { get; set; }
        public string Notification { get; set; }
        public long SourceID { get; set; }
        public string ModuleCode { get; set; }
        public string NotificationModuleName { get; set; }
        public string NotificationType { get; set; }
        public string ModuleIconCssClass { get; set; }
        public string NotificationMessage { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsRead { get; set; }
    }
}
