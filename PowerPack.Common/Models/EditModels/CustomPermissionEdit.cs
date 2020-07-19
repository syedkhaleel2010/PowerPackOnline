using System.Collections.Generic;

namespace PowerPack.Common.Models
{
    public class CustomPermissionEdit
    {
        public short UserRoleId { get; set; }

        public short PermissionId { get; set; }
        public short ModuleId { get; set; }
        public bool GrantPermission { get; set; }
        public short ParentModuleId { get; set; }
    }
    public class UpdatePermissionDataWrapper
    {
        public List<CustomPermissionEdit> objCustomPermissionEditList { get; set; }
        public string OperationType { get; set; }
        public short? UserId { get; set; }
        public short UserRoleId { get; set; }
        public int StoreId { get; set; }
    }
}
