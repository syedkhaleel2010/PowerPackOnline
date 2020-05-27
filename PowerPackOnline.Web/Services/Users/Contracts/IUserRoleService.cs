using PowerPack.Common.ViewModels;
using PowerPack.Common.Models;
using PowerPack.Models;
using PowerPackOnline.Web.EditModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPackOnline.Web.Services
{
    public interface IUserRoleService
    {
        IEnumerable<UserRole> GetUserRoles();
        IEnumerable<UserRoleMapping> GetAllUserRoleMappingData(string userid, string schoolId);
        IEnumerable<ModuleStructure> GetModuleList(int systemlanguageid, string modulecode);
        IEnumerable<ModuleStructure> GetModuleStructureList(int systemlanguageid, int? moduleid, string modulecode);
        IEnumerable<PermissionTypeView> GetAllPermissionData(int userroleId, int userId, int moduleId, bool loadcustomepermission, int schoolId);
        bool UpdatePermissionTypeDataCUD(List<PowerPack.Common.Models.CustomPermissionEdit> mappingDetails, string operationType, short? userId, short userRoleId);
        UserRole GetUserRoleById(int id);
        bool UpdateUserRoleData(UserRoleEdit model);
        bool DeleteUserRoleData(int id);
        object CheckUserRoleMapping(string userId, short? roleId);
        bool InsertUserRoleMappingData(string userId, short roleId);
        bool DeleteUserRoleMappingData(string userId, short roleId);

        IEnumerable<UserRole> GetUserRolesBySchoolId(int schoolId);
        IEnumerable<User> GetUsersForRole(int roleId, int schoolId);

        IEnumerable<PermissionTypeView> GetAllReportPermissionData(int userRoleId, int moduleId, long schoolId, int isRoleId, int isUserId, int parentModuleId);
        bool SetReportPermissionForUserAndRole(List<PowerPack.Common.Models.CustomPermissionEdit> MappingDetails, string operationtype, int userRoleId, long schoolId, short IsUser, short IsRole);
    }
}
