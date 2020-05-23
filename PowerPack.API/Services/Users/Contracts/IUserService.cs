using PowerPack.Common.Models;
using PowerPack.Models;
using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<IEnumerable<UserFeelingView>> GetUserFeelings();

        Task<IEnumerable<UserProfileView>> GetProfileAvatars();

        Task<IEnumerable<User>> GetUserBySchool(int? id, int UserTypeId);
        Task<IEnumerable<UserNotificationView>> GetUserNotifications(int? userTypeId, long userId, long loginUserId);
        Task<IEnumerable<UserNotificationView>> GetAllNotifications(int? userTypeId, long userId, long loginUserId);

        Task<User> GetUserById(int id);

        Task<IEnumerable<User>> SearchUserByName(string name, int typeId = 0, int schoolId = 0);

        Task<IEnumerable<User>> GetUsersByRolesLocatonAllowed(string roles, long businessUnitId);

        bool UpdateUserFeeling(UserFeelingView userFeelingView);

        bool UpdateUserProfile(UserProfileView userProfileView);
        bool saveErrorLogger(ErrorLogger errorLogger);
        Task<IEnumerable<DBLogDetails>> GetDBLogdetails();
        bool PushNotificationLogs(string notificationType, int sourceId, long userId);
    }
}
