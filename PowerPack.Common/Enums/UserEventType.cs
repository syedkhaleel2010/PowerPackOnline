using PowerPack.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.Enums
{
    public enum UserEventType
    {
        [StringValue("Added")]
        Added,
        [StringValue("Updated")]
        Updated,
        [StringValue("Removed")]
        Removed,
        [StringValue("Assigned")]
        Assigned,
        [StringValue("Mail_Notified")]
        Mail_Notified,
        [StringValue("Web_Notifed")]
        Web_Notifed,
        [StringValue("SMS_Notifed")]
        SMS_Notifed,
        [StringValue("Mapped")]
        Mapped,
        [StringValue("Completed")]
        Completed,
        [StringValue("Incompleted")]
        Incompleted,
        [StringValue("Approved")]
        Approved,
        [StringValue("Submitted")]
        Submitted       
    }
}
