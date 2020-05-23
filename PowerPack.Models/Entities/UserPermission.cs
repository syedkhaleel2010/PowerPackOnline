using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models
{
    public class UserPermission
    {
        public long UserId
        {
            get; set;
        }
        public int RoleId
        {
            get; set;
        }

        public int PermissionId
        {
            get; set;
        }

        public short ModuleId
        {
            get; set;
        }

        public short PermissionCategoryId
        {
            get; set;
        }

        public string ModuleUrl
        {
            get; set;
        }
    }
}
