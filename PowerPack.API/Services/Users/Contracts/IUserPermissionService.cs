using PowerPack.Models;
using PowerPack.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Services
{
    public interface IUserPermissionService
    {
        bool IsPermissionAssigned(string userName, string moduleUrl, int userTypeId);
        PagePermission GetUserPermissions(string userId, string moduleUrl, string moduleCode, int userTypeId);
        Int32 AddMenuItem(MenuItem menuItem);
        bool IsCustomPermissionAssigned(int userId, string permissionCodes);
        Task<IEnumerable<ModuleStructure>> GetReportList();
    }
}
