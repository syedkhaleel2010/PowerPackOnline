using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models
{
    public class PermissionData
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public int UserRoleId { get; set; }
        public string PermissionCode { get; set; }
        public int PermissionCategoryID { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
        public int IsTopLevelParent { get; set; }
    }
}
