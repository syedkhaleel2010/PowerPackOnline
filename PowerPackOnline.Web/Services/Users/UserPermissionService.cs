using PowerPack.Models;
using PowerPackOnline.Web.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PowerPack.Common.Helpers;
using PowerPackOnline.Web.Helpers;
using System.Web;
using System.Collections.Generic;

namespace PowerPackOnline.Web.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = Constants.PowerPackApiUrl;
        readonly string _path = "api/v1/userpermission";
        #endregion

        public UserPermissionService()
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

        public bool AddMenuItem(MenuItem menuItem)
        {
            var uri = API.UserPermission.AddMenuItem(_path);
            HttpResponseMessage response = _client.PostAsJsonAsync(uri, menuItem).Result;
            return response.IsSuccessStatusCode;
        }

        public PagePermission GetUserPermissions(string userId, string moduleUrl, string moduleCode, int userTypeId)
        {
            var pagePermission = new PagePermission();
            var encryptModuleUrl = EncryptDecryptHelper.EncryptUrl(moduleUrl);
            var encryptModuleCode =  EncryptDecryptHelper.EncryptUrl(moduleCode);
            var uri = API.UserPermission.GetUserPermission(_path, userId, encryptModuleUrl, encryptModuleCode, userTypeId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                pagePermission = EntityMapper<string, PagePermission>.MapFromJson(jsonDataProviders);
            }
            return pagePermission;
        }

        public bool IsPermissionAssigned(string userName, string moduleUrl, int userTypeId)
        {
            var result = false;
            var encryptModuleUrl = EncryptDecryptHelper.EncryptUrl(moduleUrl);
            var uri = API.UserPermission.CheckUserPermission(_path, userName, encryptModuleUrl, userTypeId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                result = Convert.ToBoolean(jsonDataProviders);
            }
            return result;
        }
        public bool IsCustomPermissionAssigned(int userId, string permissionCodes)
        {
            var result = false;
            var uri = API.UserPermission.IsCustomPermissionAssigned(_path, userId, permissionCodes);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                result = Convert.ToBoolean(jsonDataProviders);
            }
            return result;
        }

        public IEnumerable<ModuleStructure> GetReportList()
        {
            var uri = API.UserPermission.GetReportList(_path);
            IEnumerable<ModuleStructure> reportlist = new List<ModuleStructure>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                reportlist = EntityMapper<string, IEnumerable<ModuleStructure>>.MapFromJson(jsonDataProviders);
            }
            return reportlist;
        }
    }
}