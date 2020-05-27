
using Newtonsoft.Json;
using PowerPack.Common.Helpers;
using PowerPack.Common.Helpers.Extensions;
using PowerPack.Common.Models;
using PowerPack.Common.ViewModels;
using PowerPack.Models;
using PowerPackOnline.Web.EditModels;
using PowerPackOnline.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PowerPackOnline.Web.Services
{
    public class UserRoleService : IUserRoleService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = Constants.PowerPackApiUrl;
        readonly string _path = "api/v1/UserRole";
        #endregion

        public UserRoleService()
        {
            if (_client.BaseAddress == null)
            {
                // Initializing our HttpClient temporarly here, try to move into some generic class.
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        #region Methods
        public IEnumerable<UserRole> GetUserRoles()
        {
            var uri = API.UserRole.GetUserRoles(_path);
            IEnumerable<UserRole> UserRoles = new List<UserRole>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                UserRoles = EntityMapper<string, IEnumerable<UserRole>>.MapFromJson(jsonDataProviders);
            }
            return UserRoles;
        }

        public UserRole GetUserRoleById(int id)
        {
            var UserRole = new UserRole();
            var uri = API.UserRole.GetUserRoleById(_path, id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                UserRole = EntityMapper<string, UserRole>.MapFromJson(jsonDataProviders);
            }
            return UserRole;
        }

        public bool UpdateUserRoleData(UserRoleEdit model)
        {
            bool result = false;
            var uri = string.Empty;
            var sourceModel = new UserRole();
            EntityMapper<UserRoleEdit, UserRole>.Map(model, sourceModel);

            sourceModel.SchoolId = SessionHelper.CurrentSession.SchoolId;
            if(model.IsAddMode)
                uri = API.UserRole.InsertUserRole(_path);
            else
                uri = API.UserRole.UpdateUserRole(_path);
            HttpResponseMessage response = _client.PostAsJsonAsync(uri, sourceModel).Result;           
            return response.IsSuccessStatusCode;
        }

        public bool DeleteUserRoleData(int id)
        {
            var uri = API.UserRole.DeleteUserRole(_path, id);
            HttpResponseMessage response = _client.DeleteAsync(uri).Result;
            return response.IsSuccessStatusCode;
        }

        public IEnumerable<ModuleStructure> GetModuleList(int systemlanguageid, string modulecode)
        {
            IEnumerable<ModuleStructure> moduleStructures = new List<ModuleStructure>();
            
            var uri = API.UserRole.GetModuleList(_path,systemlanguageid,modulecode);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                moduleStructures = EntityMapper<string, IEnumerable<ModuleStructure>>.MapFromJson(jsonDataProviders);
            }
            return moduleStructures;
        }

        public IEnumerable<ModuleStructure> GetModuleStructureList(int systemlanguageid, int? moduleid, string modulecode)
        {
            IEnumerable<ModuleStructure> moduleStructures = new List<ModuleStructure>();

            var uri = API.UserRole.GetModuleStructureList(_path, systemlanguageid,moduleid, modulecode);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                moduleStructures = EntityMapper<string, IEnumerable<ModuleStructure>>.MapFromJson(jsonDataProviders);
            }
            return moduleStructures;
        }

        public IEnumerable<PermissionTypeView> GetAllPermissionData(int userroleId, int userId, int moduleId, bool loadcustomepermission, int schoolId)
        {
            IEnumerable<PermissionTypeView> moduleStructures = new List<PermissionTypeView>();

            var uri = API.UserRole.GetAllPermissionData(_path, userroleId,userId, moduleId, loadcustomepermission,schoolId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                moduleStructures = EntityMapper<string, IEnumerable<PermissionTypeView>>.MapFromJson(jsonDataProviders);
            }
            return moduleStructures;
        }

        public bool UpdatePermissionTypeDataCUD(List<PowerPack.Common.Models.CustomPermissionEdit> MappingDetails, string operationtype, short? userId, short userRoleId)
        {
            PowerPack.Common.Models.UpdatePermissionDataWrapper modelObj = new PowerPack.Common.Models.UpdatePermissionDataWrapper();
            modelObj.objCustomPermissionEditList = MappingDetails;
            modelObj.OperationType = operationtype;
            modelObj.UserId = userId;
            modelObj.UserRoleId = userRoleId;
            modelObj.SchoolId = (int)SessionHelper.CurrentSession.SchoolId;
            var uri = API.UserRole.UpdatePermissionTypeDataCUD(_path);
            HttpResponseMessage response = _client.PostAsJsonAsync(uri, modelObj).Result;
            return response.IsSuccessStatusCode;
        }

        public IEnumerable<UserRoleMapping> GetAllUserRoleMappingData(string userId, string schoolId)
        {
            IEnumerable<UserRoleMapping> userRoleMappings = new List<UserRoleMapping>();

            var uri = API.UserRole.GetAllUserRoleMappingData(_path, userId, schoolId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                userRoleMappings = EntityMapper<string, IEnumerable<UserRoleMapping>>.MapFromJson(jsonDataProviders);
            }
            return userRoleMappings;
        }

        public object CheckUserRoleMapping(string userId, short? roleId)
        {
            var uri = API.UserRole.CheckUserRoleMapping(_path, userId, roleId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            return response.IsSuccessStatusCode;
        }

        public bool InsertUserRoleMappingData(string userId, short roleId)
        {
            var uri = API.UserRole.InsertUserRoleMappingData(_path, userId,roleId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            return response.IsSuccessStatusCode;
        }

        public bool DeleteUserRoleMappingData(string userId, short roleId)
        {
            var uri = API.UserRole.DeleteUserRoleMappingData(_path, userId, roleId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            return response.IsSuccessStatusCode;
        }

        public IEnumerable<UserRole> GetUserRolesBySchoolId(int schoolId)
        {
            var uri = API.UserRole.GetUserRolesBySchoolId(_path, schoolId);
            IEnumerable<UserRole> UserRoles = new List<UserRole>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                UserRoles = EntityMapper<string, IEnumerable<UserRole>>.MapFromJson(jsonDataProviders);
            }
            return UserRoles;
        }

        public IEnumerable<User> GetUsersForRole(int roleId, int schoolId)
        {
            var uri = API.UserRole.GetUsersForRole(_path,roleId, schoolId);
            IEnumerable<User> Users = new List<User>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                Users = EntityMapper<string, IEnumerable<User>>.MapFromJson(jsonDataProviders);
            }
            return Users;
        }
        public IEnumerable<PermissionTypeView> GetAllReportPermissionData(int userRoleId, int moduleId, long schoolId, int isRoleId, int isUserId, int parentModuleId)
        {
            IEnumerable<PermissionTypeView> moduleStructures = new List<PermissionTypeView>();

            var uri = API.UserRole.GetAllReportPermissionData(_path, userRoleId, moduleId, schoolId, isRoleId, isUserId,  parentModuleId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                moduleStructures = EntityMapper<string, IEnumerable<PermissionTypeView>>.MapFromJson(jsonDataProviders);
            }
            return moduleStructures;
        }

        public bool SetReportPermissionForUserAndRole(List<PowerPack.Common.Models.CustomPermissionEdit> MappingDetails, string operationtype, int userRoleId, long schoolId, short IsUser, short IsRole)
        {

            HttpResponseMessage response = _client.PostAsJsonAsync(API.UserRole.SetReportPermissionForUserAndRole(_path, operationtype, userRoleId, schoolId, IsUser, IsRole), MappingDetails).Result;
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
