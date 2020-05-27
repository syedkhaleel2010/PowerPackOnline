using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using PowerPack.Common.Helpers;
using PowerPack.Common.Models;
using PowerPack.Models;
using PowerPack.Models.Entities;
using PowerPackOnline.Web.Helpers;

namespace PowerPackOnline.Web.Services
{
    public class UserService : IUserService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = Constants.PowerPackApiUrl;
        readonly string _path = "api/v1/Users";
        #endregion

        public UserService()
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
        /// Author : Athar Shaikh
        /// Created Date : 16-MAY-2019
        /// Description : To fetch all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            var uri = API.Users.GetAllUsers(_path);
            IEnumerable<User> Users = new List<User>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                Users = EntityMapper<string, IEnumerable<User>>.MapFromJson(jsonDataProviders);
            }
            return Users;
        }
        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 18-JUNE-2019
        /// Description : To fetch all user feelings
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserFeelingView> GetUserFeelings()
        {
            var uri = API.Users.GetUserFeelings(_path);
            IEnumerable<UserFeelingView> lstUserFeelingView = new List<UserFeelingView>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                lstUserFeelingView = EntityMapper<string, List<UserFeelingView>>.MapFromJson(jsonDataProviders);
            }
            return lstUserFeelingView;
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 18-JUNE-2019
        /// Description : To fetch all user avatars
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserProfileView> GetProfileAvatars()
        {
            var uri = API.Users.GetProfileAvatars(_path);
            IEnumerable<UserProfileView> lstUserFeelingView = new List<UserProfileView>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                lstUserFeelingView = EntityMapper<string, List<UserProfileView>>.MapFromJson(jsonDataProviders);
            }
            return lstUserFeelingView;
        }
        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 18-JUNE-2019
        /// Description : To Update user feeling
        /// </summary>
        ///<param name="feelingId"></param>
        ///<param name="userTypeId"></param>
        ///<param name="userId"></param>
        /// <returns></returns>
        public bool UpdateUserFeeling(UserFeelingView userFeelingView)
        {
            var uri = string.Empty;
            uri= API.Users.UpdateUserFeeling(_path);
            HttpResponseMessage response = _client.PostAsJsonAsync(uri, userFeelingView).Result;
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 18-JUNE-2019
        /// Description : To Update user feeling
        /// </summary>
        /// <returns></returns>
        public bool UpdateUserProfile(UserProfileView userProfileView)
        {
            var uri = string.Empty;
            uri = API.Users.UpdateUserProfile(_path);
            HttpResponseMessage response = _client.PostAsJsonAsync(uri, userProfileView).Result;
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 16-Oct-2019
        /// Description : To insert notification log
        /// </summary>
        /// <returns></returns>
        public bool PushNotificationLogs(string notificationType, int sourceId, long userId)
        {
            bool bFlag = true;
            var uri = string.Empty;
            uri = API.Users.PushNotificationLogs(_path, notificationType, sourceId, userId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                bFlag = Convert.ToBoolean(jsonDataProviders);
            }
            return bFlag;
        }

        /// <summary>
        /// Author : Athar Shaikh
        /// Created Date : 16-MAY-2019
        /// Description : To fetch all users by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(long id)
        {
            var user = new User();
            var uri = API.Users.GetUserById(_path, id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                user = EntityMapper<string, User>.MapFromJson(jsonDataProviders);
            }
            return user;
        }

        /// <summary>
        /// Author : Athar Shaikh
        /// Created Date : 16-MAY-2019
        /// Description : To fetch all users filtered by school id
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="userTypeId"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUserBySchool(long? schoolId, int userTypeId)
        {
            var uri = API.Users.GetUserBySchool(_path, schoolId, userTypeId);
            IEnumerable<User> Users = new List<User>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                Users = EntityMapper<string, IEnumerable<User>>.MapFromJson(jsonDataProviders);
            }
            return Users;
        }

        public IEnumerable<UserNotificationView> GetUserNotifications()
        {
            long userId = SessionHelper.CurrentSession.IsStudent()? SessionHelper.CurrentSession.Id:SessionHelper.CurrentSession.CurrentSelectedStudent.UserId;
            int userTypeId = SessionHelper.CurrentSession.UserTypeId;
            long loginUserId = SessionHelper.CurrentSession.Id;
            var uri = API.Users.GetUserNotifications(_path, userTypeId, userId, loginUserId);
            IEnumerable<UserNotificationView> Notifications = new List<UserNotificationView>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                Notifications = EntityMapper<string, IEnumerable<UserNotificationView>>.MapFromJson(jsonDataProviders);
            }
            return Notifications;
        }

        public IEnumerable<UserNotificationView> GetAllNotifications()
        {
            long userId = SessionHelper.CurrentSession.IsStudent() ? SessionHelper.CurrentSession.Id : SessionHelper.CurrentSession.CurrentSelectedStudent.UserId;
            int userTypeId = SessionHelper.CurrentSession.UserTypeId;
            long loginUserId = SessionHelper.CurrentSession.Id;
            var uri = API.Users.GetAllNotifications(_path, userTypeId, userId, loginUserId);
            IEnumerable<UserNotificationView> Notifications = new List<UserNotificationView>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                Notifications = EntityMapper<string, IEnumerable<UserNotificationView>>.MapFromJson(jsonDataProviders);
            }
            return Notifications;
        }

        /// <summary>
        /// Author : Athar Shaikh
        /// Created Date : 13-June-2019
        /// Description :  To fetch user by role and location allowed to access
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUsersByRolesLocatonAllowed(string roles)
        {
            var uri = API.Users.GetUsersByRolesLocatonAllowed(_path, roles);
            IEnumerable<User> Users = new List<User>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                Users = EntityMapper<string, IEnumerable<User>>.MapFromJson(jsonDataProviders);
            }
            return Users;
        }

        /// <summary>
        /// Author : Athar Shaikh
        /// Created Date : 19-MAY-2019
        /// Description : To search users by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="schoolId"></param>
        /// <param name="userTypeId"></param>
        /// <returns></returns>
        public IEnumerable<User> SearchUserByName(string name, long schoolId = 0, int userTypeId = 0)
        {
            var uri = API.Users.SearchUserByName(_path, name, userTypeId, schoolId);
            IEnumerable<User> Users = new List<User>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                Users = EntityMapper<string, IEnumerable<User>>.MapFromJson(jsonDataProviders);
            }
            return Users;
        }
        public bool SendErrorLog(ErrorLogger errorLogger)
        {
            var uri = string.Empty;
            uri = API.Users.SendErrorLog(_path);
            HttpResponseMessage response = _client.PostAsJsonAsync(uri, errorLogger).Result;
            return response.IsSuccessStatusCode;
        }
        public IEnumerable<DBLogDetails> GetDBLogDetails()
        {
            var uri = API.Users.GetDBLogDetails(_path);
            IEnumerable<DBLogDetails> dbLogs = new List<DBLogDetails>();
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                dbLogs = EntityMapper<string, IEnumerable<DBLogDetails>>.MapFromJson(jsonDataProviders);
            }
            return dbLogs;
        }

    }
}