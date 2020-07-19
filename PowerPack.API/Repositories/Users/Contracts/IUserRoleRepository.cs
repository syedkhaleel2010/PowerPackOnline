using DbConnection;
using PowerPack.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerPack.Common.ViewModels;
using PowerPack.Common.Models;

namespace PowerPack.API.Repositories
{
    public interface IUserRoleRepository: IGenericRepository<UserRole>
    {
        Task<IEnumerable<UserRole>> GetUserRoles();
        Task<IEnumerable<UserRoleMapping>> GetAllUserRoleMappingData(string userName, string Id);
        Task<IEnumerable<UserRoleMapping>> GetAssignedUserMappingData(int systemlanguageid, int roleid);
        Task<IEnumerable<ModuleStructure>> GetModuleList(int systemlanguageid, string modulecode);
        Task<IEnumerable<ModuleStructure>> GetUserRolePermissionList();
        Task<IEnumerable<ModuleStructure>> GetRolePowerPackModuleData(int userroleid);
        Task<IEnumerable<ModuleStructure>> GetRoleMappingData(int roleId, int Id);
        Task<IEnumerable<ModuleStructure>> GetModuleStructureList(int systemlanguageid, int? ModuleId, string ModuleCode);
        bool UpdateUserRoleData(UserRole entity, TransactionModes mode);
        Task<IEnumerable<PermissionTypeView>> GetAllPermissionData(int userRoleId, int userId, int moduleId, bool loadCustomePermission, int Id);
        Task<bool> UpdatePermissionTypeDataCUD(List<CustomPermissionEdit> MappingDetails, string operationtype, int? userId, short userRoleId,int Id);
        Task<object> CheckUserRoleMapping(string userId, short? roleId);
        Task<bool> InsertUserRoleMappingData(string userId, short roleId);
        Task<bool> DeleteUserRoleMappingData(string userId, short roleId);

        Task<IEnumerable<UserRole>> GetUserRolesById(int Id);
        Task<IEnumerable<User>> GetUsersForRole(int roleId, int Id);

        Task<IEnumerable<PermissionTypeView>> GetAllReportPermissionData(int userRoleId, int moduleId, long Id,int isRoleId,int isUserId, int parentModuleId);

        bool SetReportPermissionForUserAndRole(List<CustomPermissionEdit> MappingDetails, string operationtype, int userRoleId, long Id,short IsUser,short IsRole);
    }
}
