using PowerPack.Common.Models;
using PowerPack.Models;
using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPackOnline.Web.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<UserFeelingView> GetUserFeelings();
        IEnumerable<UserProfileView> GetProfileAvatars();
        bool UpdateUserFeeling(UserFeelingView userFeelingView);
        bool UpdateUserProfile(UserProfileView userProfileView);
        IEnumerable<UserNotificationView> GetUserNotifications();
        bool PushNotificationLogs(string notificationType, int sourceId, long userId);
        IEnumerable<User> GetUserBySchool(long? schoolId, int userTypeId);
        User GetUserById(long userId);
        IEnumerable<User> SearchUserByName(string name, long schoolId = 0, int userTypeId = 0);
        IEnumerable<User> GetUsersByRolesLocatonAllowed(string roles);
        bool SendErrorLog(ErrorLogger errorLogger);
        IEnumerable<DBLogDetails> GetDBLogDetails();
    }
}
