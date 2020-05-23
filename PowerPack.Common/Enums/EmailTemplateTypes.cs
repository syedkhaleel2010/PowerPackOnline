using PowerPack.Common.Helpers;

namespace PowerPack.Common.Enums
{
    public enum EmailTemplates : byte
    {
        [StringValue("_DefaultEmailTemplate")]
        Default,
        [StringValue("_EmailTemplate_1")]
        Template_1,
        [StringValue("_EmailTemplate_2")]
        Template_2,
        [StringValue("_EmailTemplate_3")]
        Template_3,
        [StringValue("_TaskReminderEmailTemplate")]
        TaskReminderEmailTemplate
    }

}
