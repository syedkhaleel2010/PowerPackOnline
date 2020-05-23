using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerPack.Models;
using SIMS.API.Models;
using SIMS.API.Repositories;

namespace SIMS.API.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserPermissionRepository _userPermissionRepository;

        public UserPermissionService(IUserPermissionRepository userPermissionRepository)
        {
            _userPermissionRepository = userPermissionRepository;
        }

        public int AddMenuItem(MenuItem menuItem)
        {
            return _userPermissionRepository.AddMenuItem(menuItem);
        }

        public PagePermission GetUserPermissions(string userId, string moduleUrl, string moduleCode, int userTypeId)
        {
           return  _userPermissionRepository.GetUserPermissions(userId, moduleUrl, moduleCode, userTypeId);
        }

        public bool IsPermissionAssigned(string userName, string moduleUrl, int userTypeId)
        {
            return _userPermissionRepository.IsPermissionAssigned(userName, moduleUrl, userTypeId);
        }
        public bool IsCustomPermissionAssigned(int userId, string permissionCodes)
        {
            return _userPermissionRepository.IsCustomPermissionAssigned(userId, permissionCodes);
        }

        public async Task<IEnumerable<ModuleStructure>> GetReportList()
        {
            return await _userPermissionRepository.GetReportList();
        }
    }
}
