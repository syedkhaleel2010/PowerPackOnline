using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPackOnline.Web.Services
{
    public interface IUserPermissionService
    {
        bool IsPermissionAssigned(string userName, string moduleUrl, int userTypeId);
        PagePermission GetUserPermissions(string userId, string moduleUrl, string moduleCode, int userTypeId);

        bool AddMenuItem(MenuItem menuItem);
        bool IsCustomPermissionAssigned(int userId, string permissionCodes);

       IEnumerable<ModuleStructure> GetReportList();
    }
}
