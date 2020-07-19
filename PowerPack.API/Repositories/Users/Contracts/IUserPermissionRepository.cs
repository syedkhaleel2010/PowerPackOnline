using DbConnection;
using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerPack.API.Models;

namespace PowerPack.API.Repositories
{
    public interface IUserPermissionRepository : IGenericRepository<UserPermission>
    {
        bool IsPermissionAssigned(string userName, string moduleUrl, int userTypeId);
        PagePermission GetUserPermissions(string userId, string moduleUrl, string moduleCode, int userTypeId);

        Int32 AddMenuItem(MenuItem menuItem);

        bool IsCustomPermissionAssigned(int userId, string permissionCodes);


        Task<IEnumerable<ModuleStructure>> GetReportList();


    }
}
