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
        Submitted,
        [StringValue("Investigator_Mapped")]
        Investigator_Mapped,
        [StringValue("Investigator_Unmapped")]
        Investigator_Unmapped,
        [StringValue("Document_Downloaded")]
        Document_Downloaded,
        [StringValue("Document_Removed")]
        Document_Removed,
        [StringValue("Document_Uploaded")]
        Document_Uploaded,
        //[StringValue("Investigation_Document_Downloaded")]
        //Investigation_Document_Downloaded,
        //[StringValue("Investigation_Document_Added")]
        //Investigation_Document_Added,
        //[StringValue("Investigation_Document_Updated")]
        Investigation_Document_Updated,
        [StringValue("Incident_Closed")]
        Incident_Closed,
        [StringValue("Incident_Reopened")]
        Incident_Reopened
    }
}
