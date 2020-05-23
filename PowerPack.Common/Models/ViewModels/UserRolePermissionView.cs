using PowerPack.Common.Models;
using PowerPack.Models;
using System.Collections.Generic;

namespace PowerPack.Common.ViewModels
{
    public class UserRolePermissionView
    {
        public string ModuleName { get; set; }
        public short? ModuleID { get; set; }
        public int UserID { get; set; }
        public IEnumerable<UserRole> UserRoleList { get; set; }
        public IEnumerable<ModuleStructure> ParentMenuList { get; set; }
        //public IEnumerable<PermissionTypeView> PermissionType { get; set; }
        public IEnumerable<PermissionTypeView> PermissionType { get; set; }
        public IEnumerable<CustomPermissionEdit> UserRolePermission { get; set; }
    }

}
