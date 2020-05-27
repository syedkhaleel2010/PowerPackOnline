using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using PowerPack.Models.Entities;
using PowerPack.Common.Helpers.Extensions;
using PowerPackOnline.Web.Helpers;

namespace PowerPackOnline.Web.Services
{
    public class UserLoginLogService : IUserLoginLogService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = Constants.PowerPackApiUrl;
        readonly string _path = "api/v1/UserLoginLog";
        #endregion

        public UserLoginLogService()
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
        public long InsertUserLoginLogs(UserLoginLogs userLoginLogs)
        {
            var uri = API.UserLoginLog.InsertUserLoginLogs(_path);
            HttpResponseMessage response = _client.PostAsJsonAsync(uri, userLoginLogs).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result.ToLong();
            }
            return 0;
        }
    }
}