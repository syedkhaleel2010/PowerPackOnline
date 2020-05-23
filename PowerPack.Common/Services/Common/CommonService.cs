
using Newtonsoft.Json;
using PowerPack.Common.Helpers;
using PowerPack.Common.Helpers.Extensions;
using PowerPack.Common.Models;
using PowerPack.Common.ViewModels;
using PowerPack.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PowerPack.Common.Services
{
    public class CommonService : ICommonService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = PowerPackConfiguration.Instance.PowerPackApiUrl;
        readonly string _path = "api/v1/Common";
        public CommonService()
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
        #endregion
        public EmailSettingsView GetEmailSettings()
        {
            var emailSettingsView = new EmailSettingsView();

            var uri = CommonAPI.Common.GetEmailSettings(_path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                emailSettingsView = EntityMapper<string, EmailSettingsView>.MapFromJson(jsonDataProviders);
            }
            return emailSettingsView;
        }

        public SystemLanguage GetSchoolCurrentLanguage(int schoolId)
        {
            var systemLanguage = new SystemLanguage();
           
            var uri = CommonAPI.Common.GetSchoolCurrentLanguage(_path, schoolId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                systemLanguage = EntityMapper<string, SystemLanguage>.MapFromJson(jsonDataProviders);
            }
            return systemLanguage;
        }

        public bool SetSchoolCurrentLanguage(int languageId, int schoolId)
        {
            var result = false;
            var uri = CommonAPI.Common.SetSchoolCurrentLanguage(_path,languageId,schoolId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                result = Convert.ToBoolean(jsonDataProviders);
            }
            return result;
        }
    }
}