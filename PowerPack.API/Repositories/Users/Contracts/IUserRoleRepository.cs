using DbConnection;
using PowerPack.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerPack.Common.ViewModels;
using PowerPack.Common.Models;

namespace SIMS.API.Repositories
{
    public interface IUserRoleRepository: IGenericRepository<UserRole>
    {
        Task<IEnumerable<UserRole>> GetUserRoles();
        Task<IEnumerable<UserRoleMapping>> GetAllUserRoleMappingData(string userName, string schoolId);
        Task<IEnumerable<UserRoleMapping>> GetAssignedUserMappingData(int systemlanguageid, int roleid);
        Task<IEnumerable<ModuleStructure>> GetModuleList(int systemlanguageid, string modulecode);
        Task<IEnumerable<ModuleStructure>> GetUserRolePermissionList();
        Task<IEnumerable<ModuleStructure>> GetRolePowerPackModuleData(int userroleid);
        Task<IEnumerable<ModuleStructure>> GetRoleMappingData(int roleId, int schoolId);
        Task<IEnumerable<ModuleStructure>> GetModuleStructureList(int systemlanguageid, int? ModuleId, string ModuleCode);
        bool UpdateUserRoleData(UserRole entity, TransactionModes mode);
        Task<IEnumerable<PermissionTypeView>> GetAllPermissionData(int userRoleId, int userId, int moduleId, bool loadCustomePermission, int schoolId);
        Task<bool> UpdatePermissionTypeDataCUD(List<CustomPermissionEdit> MappingDetails, string operationtype, int? userId, short userRoleId,int schoolId);
        Task<object> CheckUserRoleMapping(string userId, short? roleId);
        Task<bool> InsertUserRoleMappingData(string userId, short roleId);
        Task<bool> DeleteUserRoleMappingData(string userId, short roleId);

        Task<IEnumerable<UserRole>> GetUserRolesBySchoolId(int schoolId);
        Task<IEnumerable<User>> GetUsersForRole(int roleId, int schoolId);

        Task<IEnumerable<PermissionTypeView>> GetAllReportPermissionData(int userRoleId, int moduleId, long schoolId,int isRoleId,int isUserId, int parentModuleId);

        bool SetReportPermissionForUserAndRole(List<CustomPermissionEdit> MappingDetails, string operationtype, int userRoleId, long schoolId,short IsUser,short IsRole);
    }
}
