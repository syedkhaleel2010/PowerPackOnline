using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerPackOnline.Web.Helpers
{
    public static class API
    {
        public static class Login
        {
            public static string IsValidUser(string baseUri, string Username,string Password) => $"{baseUri}/IsValidUser?Username={Username}&Password{Password}";
        }

        public static class Common
        {
            public static string GetEmailSettings(string baseUri) => $"{baseUri}/getEmailSettings";
            public static string GetStoreCurrentLanguage(string baseUri, int StoreId) => $"{baseUri}/getStoreCurrentLanguage?StoreId={StoreId}";
            public static string SetStoreCurrentLanguage(string baseUri, int languageId, int StoreId) => $"{baseUri}/setStoreCurrentLanguage?languageId={languageId}&StoreId={StoreId}";
            public static string OperationAuditCU(string baseUri) => $"{baseUri}/OperationAuditCU";
        }
        public static class ErrorLogger
        {
            public static string GetErrorLogs(string baseUri, string applicationName, int pageIndex, int pageSize, string search, string sortColumn, string sortColumnDir) =>
                $"{baseUri}/GetErrorLogs?applicationName={applicationName}&pageIndex={pageIndex}&pageSize={pageSize}&search={search}&sortColumn={sortColumn}&sortColumnDir={sortColumnDir}";
            public static string GetErrorLog(string baseUri, string applicationName, Guid errorId) =>
                $"{baseUri}/GetErrorLog?applicationName={applicationName}&errorId={errorId}";
            public static string LogError(string baseUri) =>
                $"{baseUri}/LogError";
        }

        public static class ModuleStructure
        {
            public static string GetPowerPackModuleStructure(string baseUri, int systemLanguageId,
            int userId, string applicationCode, string traverseDirection, string moduleUrl, string moduleCode, bool excludeParent,
            string excludeModuleCodes, bool? showInMenu)
                => $"{baseUri}/getPowerPackmodulestructure?systemLanguageId={systemLanguageId}&userId={userId}&applicationCode={applicationCode}&traverseDirection={traverseDirection}&moduleUrl={moduleUrl}&moduleCode={moduleCode}&excludeParent={excludeParent}&excludeModuleCodes={excludeModuleCodes}&showInMenu={showInMenu}";
        }
        public static class SelectList
        {
            public static string GetSelectListItems(string baseUri, string listCode, string whereCondition, object whereConditionParamValues) => $"{baseUri}/getselectlistitems?listCode={listCode}&whereCondition={whereCondition}&whereConditionParamValues={whereConditionParamValues}";
            public static string GetSubjectListItems(string baseUri, int languageId, int userId) => $"{baseUri}/getsubjectlistitems?languageId={languageId}&userId={userId}";
        }
        public static class LogInUser
        {
            public static string GetLoginUserByUserName(string baseUri) => $"{baseUri}/getloginuserbyusername/";
            public static string GetUserList(string baseUri, int StoreId) => $"{baseUri}/getuserlist/{StoreId}";
        }

        public static class Users
        {
            public static string GetAllUsers(string baseUri) => $"{baseUri}/getallusers/";
            public static string GetUserFeelings(string baseUri) => $"{baseUri}/getalluserfeelings/";
            public static string GetProfileAvatars(string baseUri) => $"{baseUri}/getprofileavatars/";
            public static string UpdateUserFeeling(string baseUri) => $"{baseUri}/updateuserfeeling";
            public static string UpdateUserProfile(string baseUri) => $"{baseUri}/updateuserprofile";


            public static string GetUserByStore(string baseUri, long? StoreId, int userTypeId) => $"{baseUri}/getusersbyStore?id={StoreId}&userTypeId={userTypeId}";
            public static string GetUserNotifications(string baseUri, int userTypeId, long? userId, long? loginUserId) => $"{baseUri}/getusernotifications?userTypeId={userTypeId}&userId={userId}&loginUserId={loginUserId}";
            public static string GetAllNotifications(string baseUri, int userTypeId, long? userId, long? loginUserId) => $"{baseUri}/getallnotifications?userTypeId={userTypeId}&userId={userId}&loginUserId={loginUserId}";

            public static string PushNotificationLogs(string baseUri, string notificationType, int sourceId, long userId) => $"{baseUri}/pushnotificationlogs?notificationType={notificationType}&sourceId={sourceId}&userId={userId}";

            public static string GetUserById(string baseUri, long UserId) => $"{baseUri}/getuserbyid?id={UserId}";
            public static string SearchUserByName(string baseUri, string name, int typeId = 0, long StoreId = 0) => $"{baseUri}/searchuserbyname?name={name}&typeId={typeId}&StoreId={StoreId}";
            public static string GetUsersByRolesLocatonAllowed(string baseUri, string roles) => $"{baseUri}/getusersbyrolelocation?roles={roles}";
            public static string SendErrorLog(string baseUri) => $"{baseUri}/saveErrorLogger";
            public static string GetDBLogDetails(string baseUri) => $"{baseUri}/GetDBLogdetails";

        }

        public static class UserLoginLog
        {
            public static string InsertUserLoginLogs(string baseUri) => $"{baseUri}/InsertUserLoginLogs";
        }



    }
}