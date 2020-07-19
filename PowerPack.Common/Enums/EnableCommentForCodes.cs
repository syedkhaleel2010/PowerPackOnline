using PowerPack.Common.Helpers;

namespace PowerPack.Common.Enums
{
    public enum EnableCommentForCodes
    {
        [StringValue("None")]
        None,
        [StringValue("User")]
        User,
        [StringValue("Admin")]
        Admin,
        [StringValue("All")]
        All
    }
}
