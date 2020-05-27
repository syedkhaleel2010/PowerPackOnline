
using Newtonsoft.Json;
using PowerPack.Common.Helpers;
using PowerPack.Common.Helpers.Extensions;
using PowerPack.Common.Models;
using PowerPack.Models;
using PowerPackOnline.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PowerPackOnline.Web.Services
{
    public class ModuleStructureService : IModuleStructureService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = Constants.PowerPackApiUrl;
        readonly string _path = "api/v1/modulestructure";
        #endregion

        public ModuleStructureService()
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
        public IEnumerable<ModuleStructure> GetPowerPackModuleStructure(int systemLanguageId,
            int userId, string applicationCode, string traverseDirection, string moduleUrl, string moduleCode, bool excludeParent,
            string excludeModuleCodes, bool? showInMenu)
        {
            var uri = API.ModuleStructure.GetPowerPackModuleStructure(_path,systemLanguageId, userId, applicationCode, traverseDirection, moduleUrl,
                moduleCode, excludeParent, excludeModuleCodes, showInMenu);
            IEnumerable<ModuleStructure> list = new List<ModuleStructure>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                list = EntityMapper<string, IEnumerable<ModuleStructure>>.MapFromJson(jsonDataProviders);
            }
            return list;
        }
       
        #endregion
    }
}
