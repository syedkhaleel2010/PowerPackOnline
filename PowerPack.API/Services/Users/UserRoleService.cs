using PowerPack.Models;
using SIMS.API.Repositories;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerPack.Common.ViewModels;
using PowerPack.Common.Models;

namespace SIMS.API.Services
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

        public async Task<IEnumerable<UserRoleMapping>> GetAllUserRoleMappingData(string userName, string schoolId)
        {
            return await _userRoleRepository.GetAllUserRoleMappingData(userName, schoolId);
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
        public async Task<IEnumerable<ModuleStructure>> GetRoleMappingData(int roleId,int schoolId)
        {
            return await _userRoleRepository.GetRoleMappingData(roleId, schoolId);
        }
        public async Task<IEnumerable<ModuleStructure>> GetModuleStructureList(int systemlanguageid, int? moduleid, string modulecode)
        {
            return await _userRoleRepository.GetModuleStructureList(systemlanguageid, moduleid, modulecode);
        }
        public async Task<IEnumerable<PermissionTypeView>> GetAllPermissionData(int userRoleId, int userId, int moduleId, bool loadCustomePermission, int schoolId)
        {
            return await _userRoleRepository.GetAllPermissionData(userRoleId, userId, moduleId, loadCustomePermission, schoolId);
        }

        public async Task<bool> UpdatePermissionTypeDataCUD(List<CustomPermissionEdit> MappingDetails, string operationtype, int? userId, short userRoleId, int schoolId)
        {
            return await _userRoleRepository.UpdatePermissionTypeDataCUD(MappingDetails,operationtype,userId,userRoleId, schoolId);
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

        public Task<IEnumerable<UserRole>> GetUserRolesBySchoolId(int schoolId)
        {
            return _userRoleRepository.GetUserRolesBySchoolId(schoolId);
        }

        public Task<IEnumerable<User>> GetUsersForRole(int roleId, int schoolId)
        {
            return _userRoleRepository.GetUsersForRole(roleId, schoolId);
        }

        public Task<IEnumerable<PermissionTypeView>> GetAllReportPermissionData(int userRoleId, int moduleId, long schoolId, int isRoleId, int isUserId, int parentModuleId)
        {
            return _userRoleRepository.GetAllReportPermissionData( userRoleId,  moduleId,  schoolId,  isRoleId,  isUserId, parentModuleId);
        }

        public bool SetReportPermissionForUserAndRole(List<CustomPermissionEdit> MappingDetails, string operationtype, int userRoleId, long schoolId, short IsUser, short IsRole)
        {
            return _userRoleRepository.SetReportPermissionForUserAndRole(MappingDetails, operationtype, userRoleId, schoolId, IsUser, IsRole);
        }
    }
}
