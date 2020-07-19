using PowerPack.Common.Models;
using PowerPack.Common.ViewModels;
using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Services
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRole>> GetUserRoles();
        Task<UserRole> GetUserRoleById(int id);
        Task<IEnumerable<UserRoleMapping>> GetAllUserRoleMappingData(string userName, string StoreId);
        Task<IEnumerable<UserRoleMapping>> GetAssignedUserMappingData(int systemlanguageid, int roleid);
        Task<IEnumerable<ModuleStructure>> GetModuleList(int systemlanguageid, string modulecode);
        Task<IEnumerable<ModuleStructure>> GetUserRolePermissionList();
        Task<IEnumerable<ModuleStructure>> GetRolePowerPackModuleData(int userroleid);
        Task<IEnumerable<ModuleStructure>> GetRoleMappingData(int roleId, int StoreId);
        Task<IEnumerable<ModuleStructure>> GetModuleStructureList(int systemlanguageid, int? moduleid, string modulecode);
        Task<IEnumerable<PermissionTypeView>> GetAllPermissionData(int userroleid, int userid, int moduleid, bool loadcustomepermission,int StoreId);
        Task<bool> UpdatePermissionTypeDataCUD(List<CustomPermissionEdit> MappingDetails, string operationtype, int? userId, short userRoleId, int StoreId);
        bool InsertUserRole(UserRole entity);
        bool UpdateUserRole(UserRole entity);
        bool DeleteUserRole(int id);
        Task<object> CheckUserRoleMapping(string userId, short? roleId);
        Task<bool> InsertUserRoleMappingData(string userId, short roleId);
        Task<bool> DeleteUserRoleMappingData(string userId, short roleId);

        //Task<IEnumerable<UserRole>> GetUserRolesByStoreId(int StoreId);
        Task<IEnumerable<User>> GetUsersForRole(int roleId, int StoreId);
        Task<IEnumerable<PermissionTypeView>> GetAllReportPermissionData(int userRoleId, int moduleId, long StoreId, int isRoleId, int isUserId, int parentModuleId);
        bool SetReportPermissionForUserAndRole(List<CustomPermissionEdit> MappingDetails, string operationtype, int userRoleId, long StoreId, short IsUser, short IsRole);
    }
}
