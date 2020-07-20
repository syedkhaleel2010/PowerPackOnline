using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Common.Models;
using PowerPack.Models;
using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace PowerPack.API.Repositories
{
    public class UserRepository : SqlRepository<User>, IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        /// <summary>
        /// Author : 
        /// Created Date : 16-July-2020
        /// Description : To fetch all the users
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<User>("dbo.GetUsers", CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Author : 
        /// Created Date : 18-JUNE-2019
        /// Description : To fetch user feelings 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserFeelingView>> GetUserFeelings()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<UserFeelingView>("Admin.GetUserFeelings", CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Author : 
        /// Created Date : 18-JUNE-2019
        /// Description : To fetch user profile avatar 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserProfileView>> GetProfileAvatars()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<UserProfileView>("Admin.GetProfileAvatars", CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Author : 
        /// Created Date : 18-JUNE-2019
        /// Description : To update user feelings 
        /// </summary>
        /// <returns></returns>
        public bool UpdateUserFeeling(UserFeelingView userFeelingView)
        {
            using (var conn = GetOpenConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FeelingId", userFeelingView.FeelId, DbType.Int64);
                parameters.Add("@UserTypeId", userFeelingView.UserTypeId, DbType.Int64);
                parameters.Add("@UserId", userFeelingView.UserId, DbType.Int64);
                parameters.Add("@strCurrentStatus", userFeelingView.CurrentStatus, DbType.String);
                parameters.Add("@Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Query<int>("Admin.UpdateUserFeeling", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("Output") > 0;
            }
        }
        /// <summary>
        /// Author : 
        /// Created Date : 24-JUNE-2019
        /// Description : To UpdateUserProfile
        /// </summary>
        /// <returns></returns>
        public bool UpdateUserProfile(UserProfileView userProfileView)
        {
            using (var conn = GetOpenConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AvatarId", userProfileView.AvatarId, DbType.Int32);
                parameters.Add("@UserId", Convert.ToInt64(userProfileView.UserId), DbType.Int64);
                parameters.Add("@ProfilePhoto", userProfileView.ProfilePhoto, DbType.String);
                parameters.Add("@Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Query<int>("Admin.UpdateUserProfile", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("Output") > 0;
            }
        }

        /// <summary>
        /// Author : 
        /// Created Date : 16-OCT-2019
        /// Description : To Insert Notification Log
        /// </summary>
        /// <returns></returns>
        public bool PushNotificationLogs(string notificationType, int sourceId, long userId)
        {
            using (var conn = GetOpenConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SourceId", sourceId, DbType.Int32);
                parameters.Add("@UserId", userId, DbType.Int64);
                parameters.Add("@NotificationType", notificationType, DbType.String);
                parameters.Add("@Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Query<int>("Admin.PushNotificationLogs", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("Output") > 0;
            }
        }
        /// <summary>
        /// Author : 
        /// Created Date : 16-July-2020
        /// Description : To fetch users by  id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsersByStore(int? Id, int UserTypeId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id, DbType.Int32);
                return await conn.QueryAsync<User>("[SIMS].GetUsers", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Author :  
        /// Created Date : 15/10/2019
        /// Description : To get user notifications
        /// </summary>
        /// <param name="userTypeId"></param>
        /// <param name="userId"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserNotificationView>> GetUserNotifications(int? userTypeId, long userId, long loginUserId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId, DbType.Int64);
                parameters.Add("@UserTypeId", userTypeId, DbType.Int32);
                parameters.Add("@loginUserId", loginUserId, DbType.Int32);
                return await conn.QueryAsync<UserNotificationView>("dbo.GetUserNotifications", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Author :  
        /// Created Date : 15/10/2019
        /// Description : To get user notifications
        /// </summary>
        /// <param name="userTypeId"></param>
        /// <param name="userId"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserNotificationView>> GetAllNotifications(int? userTypeId, long userId, long loginUserId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId, DbType.Int64);
                parameters.Add("@UserTypeId", userTypeId, DbType.Int32);
                parameters.Add("@loginUserId", loginUserId, DbType.Int32);
                return await conn.QueryAsync<UserNotificationView>("dbo.GetAllNotifications", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Author : 
        /// Created Date : 16-July-2020
        /// Description : To fetch user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<User> GetAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", id, DbType.Int32);
                return await conn.QueryFirstOrDefaultAsync<User>("dbo.[GetUsersById]", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Author : 
        /// Created Date : 19-July-2020
        /// Description : To fetch user by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typeId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> SearchUserByName(string name, int typeId = 0, int Id = 0)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id, DbType.Int32);
                parameters.Add("@typeId", typeId, DbType.Int32);
                parameters.Add("@Name", name, DbType.String);
                return await conn.QueryAsync<User>("dbo.UserSearchByName", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Author : 
        /// Created Date : 13-JUNE-2019
        /// Description : To fetch user by role and location allowed to access
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsersByRolesLocatonAllowed(string roles, long businessUnitId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Roles", roles, DbType.String);
                parameters.Add("@BusinessUnitId", businessUnitId, DbType.Int32);
                return await conn.QueryAsync<User>("[dbo].[GetUsersByRolesandLocations]", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Author :Mahesh Chikhale
        /// Created Date : 21-Oct-2019
        /// Description : To save Error logged by User
        /// </summary>
        /// <returns></returns>
        public bool SaveErrorLogger(ErrorLogger objErrorLog)
        {
            using (var conn = GetOpenConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ErrorText", objErrorLog.ErrorMessage, DbType.String);
                parameters.Add("@UserId", objErrorLog.UserId, DbType.Int64);
                parameters.Add("@ModuleUrl", objErrorLog.ModuleUrl, DbType.String);
                parameters.Add("@UserIpAddress", objErrorLog.UserIpAddress, DbType.String);
                parameters.Add("@WebServerIpAddress", objErrorLog.WebServerIpAddress, DbType.String);
                parameters.Add("@Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                DataTable dtErrorFiles = new DataTable();
                dtErrorFiles.Columns.Add("TaskId", typeof(Int64));
                dtErrorFiles.Columns.Add("FileName", typeof(string));
                dtErrorFiles.Columns.Add("UploadedFileName", typeof(string));
                dtErrorFiles.Columns.Add("RefTaskID", typeof(Int64));
               
                //foreach (var item in objErrorLog.lstTaskFiles)
                //{
                //    dtErrorFiles.Rows.Add(item.TaskId, item.FileName, item.UploadedFileName, 1);
                //}
                parameters.Add("@ErrorFiles", dtErrorFiles, DbType.Object);
                conn.Query<int>("Admin.SaveErrorLogs", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("Output") > 0;
            }
        }

        /// <summary>
        /// Author :Mahesh Chikhale
        /// Created Date : 21-Oct-2019
        /// Description : To get DB log details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DBLogDetails>> GetDBLogdetails()
        {
           
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<DBLogDetails>("[dbo].[sp_who3]", null, null, null, CommandType.StoredProcedure);
            }
        }
        #region Common method
        public override void InsertAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(User entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}