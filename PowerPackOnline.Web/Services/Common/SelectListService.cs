
using Newtonsoft.Json;
using PowerPack.Common.Helpers;
using PowerPack.Common.Helpers.Extensions;
using PowerPack.Common.Localization;
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
    public class SelectListService : ISelectListService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = Constants.PowerPackAPIUrl;
        readonly string _path = "api/v1/selectlist";
        #endregion

        public SelectListService()
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
        public IEnumerable<ListItem> GetSelectListItems(string listCode, string whereCondition, object whereConditionParamValues)
        {
            var uri = API.SelectList.GetSelectListItems(_path, listCode, whereCondition, whereConditionParamValues);
            IEnumerable<ListItem> list = new List<ListItem>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                list = EntityMapper<string, IEnumerable<ListItem>>.MapFromJson(jsonDataProviders);
            }
            return list;
        }

      

        #endregion
    }
}
