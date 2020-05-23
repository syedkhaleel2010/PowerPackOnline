using PowerPack.Common.Helpers;

namespace PowerPack.Common.Enums
{
    public enum PlanTemplateTypes
    {
        [StringValue("Scheme of Work")]
        SOW,
        [StringValue("Lesson Plan")]
        Plan,
        [StringValue("Certificate")]
        Certificate
    }

    public enum PlanPeriod
    {
        [StringValue("Daily")]
        Daily,
        [StringValue("Weekly")]
        Weekly,
        [StringValue("Monthly")]
        Monthly
    }

    public enum TemplateStatus
    {
        [StringValue("New")]
        New,
        [StringValue("Approved")]
        Approved,
        [StringValue("Pending For Approval")]
        Pending,
        [StringValue("Rejected")]
        Rejected
    }
}
