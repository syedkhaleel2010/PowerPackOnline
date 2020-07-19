using PowerPack.Models;
using PowerPack.API.Repositories;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerPack.Common.ViewModels;
using PowerPack.Common.Models;

namespace PowerPack.API.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<IEnumerable<UserRole>> GetUserRoles()
        {
            return await _userRoleRepository.GetUserRoles();
        }

        public async Task<UserRole> GetUserRoleById(int id)
        {
            return await _userRoleRepository.GetAsync(id);
        }

        public bool InsertUserRole(UserRole entity)
        {
            return _userRoleRepository.UpdateUserRoleData(entity, TransactionModes.Insert);
        }

        public bool UpdateUserRole(UserRole entity)
        {
            return _userRoleRepository.UpdateUserRoleData(entity, TransactionModes.Update);
        }

        public bool DeleteUserRole(int id)
        {
            UserRole entity = new UserRole(id);
            return _userRoleRepository.UpdateUserRoleData(entity, TransactionModes.Delete);
        }

        public async Task<IEnumerable<UserRoleMapping>> GetAllUserRoleMappingData(string userName, string StoreId)
        {
            return await _userRoleRepository.GetAllUserRoleMappingData(userName, StoreId);
        }

        public async Task<IEnumerable<UserRoleMapping>> GetAssignedUserMappingData(int systemlanguageid, int roleid)
        {
            return await _userRoleRepository.GetAssignedUserMappingData(systemlanguageid,roleid);
        }
        public async Task<IEnumerable<ModuleStructure>> GetModuleList(int systemlanguageid, string modulecode)
        {
            return await _userRoleRepository.GetModuleList(systemlanguageid, modulecode);
        }
        public async Task<IEnumerable<ModuleStructure>> GetUserRolePermissionList()
        {
            return await _userRoleRepository.GetUserRolePermissionList();
        }
        public async Task<IEnumerable<ModuleStructure>> GetRolePowerPackModuleData(int userroleid)
        {
            return await _userRoleRepository.GetRolePowerPackModuleData(userroleid);
        }
        public async Task<IEnumerable<ModuleStructure>> GetRoleMappingData(int roleId,int StoreId)
        {
            return await _userRoleRepository.GetRoleMappingData(roleId, StoreId);
        }
        public async Task<IEnumerable<ModuleStructure>> GetModuleStructureList(int systemlanguageid, int? moduleid, string modulecode)
        {
            return await _userRoleRepository.GetModuleStructureList(systemlanguageid, moduleid, modulecode);
        }
        public async Task<IEnumerable<PermissionTypeView>> GetAllPermissionData(int userRoleId, int userId, int moduleId, bool loadCustomePermission, int StoreId)
        {
            return await _userRoleRepository.GetAllPermissionData(userRoleId, userId, moduleId, loadCustomePermission, StoreId);
        }

        public async Task<bool> UpdatePermissionTypeDataCUD(List<CustomPermissionEdit> MappingDetails, string operationtype, int? userId, short userRoleId, int StoreId)
        {
            return await _userRoleRepository.UpdatePermissionTypeDataCUD(MappingDetails,operationtype,userId,userRoleId, StoreId);
        }

        public async Task<object> CheckUserRoleMapping(string userId, short? roleId)
        {
            return await _userRoleRepository.CheckUserRoleMapping(userId,roleId);
        }

        public async Task<bool> InsertUserRoleMappingData(string userId, short roleId)
        {
            return await _userRoleRepository.InsertUserRoleMappingData(userId, roleId);
        }

        public async Task<bool> DeleteUserRoleMappingData(string userId, short roleId)
        {
            return await _userRoleRepository.DeleteUserRoleMappingData(userId, roleId);
        }

        //public Task<IEnumerable<UserRole>> GetUserRolesByStoreId(int StoreId)
        //{
        //    return _userRoleRepository.GetUserRolesByStoreId(StoreId);
        //}

        public Task<IEnumerable<User>> GetUsersForRole(int roleId, int StoreId)
        {
            return _userRoleRepository.GetUsersForRole(roleId, StoreId);
        }

        public Task<IEnumerable<PermissionTypeView>> GetAllReportPermissionData(int userRoleId, int moduleId, long StoreId, int isRoleId, int isUserId, int parentModuleId)
        {
            return _userRoleRepository.GetAllReportPermissionData( userRoleId,  moduleId,  StoreId,  isRoleId,  isUserId, parentModuleId);
        }

        public bool SetReportPermissionForUserAndRole(List<CustomPermissionEdit> MappingDetails, string operationtype, int userRoleId, long StoreId, short IsUser, short IsRole)
        {
            return _userRoleRepository.SetReportPermissionForUserAndRole(MappingDetails, operationtype, userRoleId, StoreId, IsUser, IsRole);
        }
    }
}
