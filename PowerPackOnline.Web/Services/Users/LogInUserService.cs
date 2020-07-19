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
using PowerPackOnline.Web.ViewModels;
namespace PowerPackOnline.Web.Services
{
    public class LogInUserService : ILogInUserService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = Constants.PowerPackApiUrl;
        readonly string _path = "api/v1/loginuser";
        #endregion

        public LogInUserService()
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

        //public LogInUser GetLoginUserByUserName(string userName,string Password)
        //{
        //    var loginUser = new LogInUser();
        //    //var encryptUserName = EncryptDecryptHelper.EncryptUrl(userName);
        //    var uri = API.LogInUser.GetLoginUserByUserName(_path);
        //    HttpResponseMessage response = _client.PostAsJsonAsync(uri, new LoginModel { UserName = userName, Password = Password }).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
        //        loginUser = EntityMapper<string, LogInUser>.MapFromJson(jsonDataProviders);
        //    }
        //    return loginUser;
        //}

        public IEnumerable<LogInUser> GetUserList(int StoreId)
        {
            var uri = API.LogInUser.GetUserList(_path, StoreId);
            IEnumerable<LogInUser> userList = new List<LogInUser>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                userList = EntityMapper<string, IEnumerable<LogInUser>>.MapFromJson(jsonDataProviders);
            }
            return userList;
        }
    }
}
