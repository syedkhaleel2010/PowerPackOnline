using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using PowerPack.Common.Helpers;
using PowerPack.Common.Models;
using PowerPack.Models;
using PowerPackOnline.Web.EditModels;
using PowerPackOnline.Web.Helpers;
using PowerPackOnline.Web.Models;

namespace PowerPackOnline.Web.Services
{
    public class UserLocationMapService : IUserLocationMapService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = Constants.PowerPackApiUrl;
        readonly string _path = "api/v1/userlocationmap";
        #endregion

        public UserLocationMapService()
        {
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        /// <summary>
        /// Author : Tejal Chaudhari
        /// Created Date : 16-JUN-2019
        /// Description : To fetch locations by user id using api service
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        public IEnumerable<UserLocationMap> GetUserLocationMapsByUserId(int id)
        {
            var uri = API.UserLocationMap.GetUserLocationMapsByUserId(_path,id);
            IEnumerable<UserLocationMap> userLocationMaps = new List<UserLocationMap>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                userLocationMaps = EntityMapper<string, IEnumerable<UserLocationMap>>.MapFromJson(jsonDataProviders);
            }
            return userLocationMaps;
        }

        /// <summary>
        /// Author : Tejal Chaudhari
        /// Created Date : 16-JUN-2019
        /// Description : To update locations(BU) for a user using api service
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        public bool InsertUserLocationMaps(IEnumerable<UserLocationMap> userLocationMapList)
        {
            var uri = API.UserLocationMap.InsertUserLocationMaps(_path);
            
            HttpResponseMessage response = _client.PostAsJsonAsync(uri, userLocationMapList).Result;
            return response.IsSuccessStatusCode;
        }
    }
}