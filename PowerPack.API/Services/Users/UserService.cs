using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerPack.API.Repositories;
using PowerPack.Common.Models;
using PowerPack.Models;
using PowerPack.Models.Entities;

namespace PowerPack.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Author : Athar Shaikh
        /// Created Date : 16-July-2020
        /// Description : To fetch all the users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 18-June-2019
        /// Description : To fetch all user feelings
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserFeelingView>> GetUserFeelings()
        {
            return await _userRepository.GetUserFeelings();
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 18-June-2019
        /// Description : To fetch all user profile avatar
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserProfileView>> GetProfileAvatars()
        {
            return await _userRepository.GetProfileAvatars();
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 18-June-2019
        /// Description : To Insert user feelings
        /// </summary>
        /// <returns></returns>
        public bool UpdateUserFeeling(UserFeelingView userFeelingView)
        {
            return _userRepository.UpdateUserFeeling(userFeelingView);
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 24-June-2019
        /// Description : To UpdateUserProfile
        /// </summary>
        /// <returns></returns>
        public bool UpdateUserProfile(UserProfileView userProfileView)
        {
            return _userRepository.UpdateUserProfile(userProfileView);
        }
        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 16-Oct-2019
        /// Description : To insert log for notification
        /// </summary>
        /// <returns></returns>
        public bool PushNotificationLogs(string notificationType, int sourceId, long userId)
        {
            return _userRepository.PushNotificationLogs(notificationType, sourceId, userId);
        }
        /// <summary>
        /// Author : Athar Shaikh
        /// Created Date : 16-July-2020
        /// Description : To fetch all the users by StoreId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUserByStore(int? id, int UserTypeId)
        {
            return await _userRepository.GetUsersByStore(id, UserTypeId);
        }

        /// <summary>
        /// Author : Girish Sonawane 
        /// Created Date : 15/10/2019
        /// Description : To get user notifications
        /// </summary>
        /// <param name="userTypeId"></param>
        /// <param name="userId"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserNotificationView>> GetUserNotifications(int? userTypeId, long userId, long loginUserId)
        {
            return await _userRepository.GetUserNotifications(userTypeId, userId, loginUserId);
        }
        /// <summary>
        /// Author : Girish Sonawane 
        /// Created Date : 15/10/2019
        /// Description : To get all notifications
        /// </summary>
        /// <param name="userTypeId"></param>
        /// <param name="userId"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserNotificationView>> GetAllNotifications(int? userTypeId, long userId, long loginUserId)
        {
            return await _userRepository.GetAllNotifications(userTypeId, userId, loginUserId);
        }
        /// <summary>
        /// Author : Athar Shaikh
        /// Created Date : 16-July-2020
        /// Description : To fetch all the user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        /// <summary>
        /// Author : Athar Shaikh
        /// Created Date : 19-July-2020
        /// Description : To fetch all the user name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typeId"></param>
        /// <param name="StoreId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> SearchUserByName(string name, int typeId = 0, int StoreId = 0)
        {
            return await _userRepository.SearchUserByName(name, typeId, StoreId);
        }

        /// <summary>
        /// Author : Athar Shaikh
        /// Created Date : 13-June-2019
        /// Description : To fetch user by role and location allowed to access
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="bussinessUnitId">
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsersByRolesLocatonAllowed(string roles, long bussinessUnitId)
        {
            return await _userRepository.GetUsersByRolesLocatonAllowed(roles, bussinessUnitId);
        }

        /// <summary>
        /// Author : Mahesh Chikhale
        /// Created Date : 21-Oct-2019
        /// Description : To Insert Error Log
        /// </summary>
        /// <param name="objErrorLog"></param>
        /// <returns></returns>
        public bool saveErrorLogger(ErrorLogger objErrorLog)
        {
            return _userRepository.SaveErrorLogger(objErrorLog);
        }

        /// <summary>
        /// Author :Mahesh Chikhale
        /// Created Date : 21-Oct -2019
        /// Description : To get DB log details after user reported error
        /// </summary>       
        /// <returns></returns>
        public async Task<IEnumerable<DBLogDetails>> GetDBLogdetails()
        {
            return await _userRepository.GetDBLogdetails();
        }

    }
}
