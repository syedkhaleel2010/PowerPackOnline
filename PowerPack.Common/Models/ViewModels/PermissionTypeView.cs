namespace PowerPack.Common.ViewModels
{
    public class PermissionTypeView
    {
        public int ModuleId { get; set; }
        public int PermissionId { get; set; }
        public int? UserRoleId { get; set; }
        public short? UserId { get; set; }
        public bool GrantPermission { get; set; }
        public string PermissionName { get; set; }
        public string PermissionCode { get; set; }
        public short PermissionCategoryID { get; set; }
        public bool IsTopLevelParent { get; set; }
    }
}
