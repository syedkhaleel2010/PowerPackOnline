using PowerPack.Common.Helpers;

namespace PowerPack.Common.Enums
{
    public enum UserEventModule
    {
        [StringValue("None")]
        None,
        [StringValue("Incident")]
        Incident,
        [StringValue("Task")]
        Task,
        [StringValue("ScoreCard")]
        ScoreCard,
    }
}
