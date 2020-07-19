using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PowerPack.Common.ViewModels;
using PowerPack.Common.Models;
using PowerPack.Common.DataAccess;

namespace PowerPack.API.Repositories
{
    public class UserRoleRepository : SqlRepository<UserRole>, IUserRoleRepository
    {
        private readonly IConfiguration _config;

        public UserRoleRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public async Task<IEnumerable<UserRole>> GetUserRoles()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<UserRole>("Admin.GetUserRoleData", CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesById(int Id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                //parameters.Add("@UserRoleId", DBNull.Value, DbType.Int32);
                parameters.Add("@BSU_ID", Id, DbType.Int32);

                return await conn.QueryAsync<UserRole>("[SIMS].GetUserRoleData", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public bool UpdateUserRoleData(UserRole entity, TransactionModes mode)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = GetUserRolesParameters(entity, mode);
                conn.Query<int>("Admin.UserRoleCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        #region Private Methods
        private DynamicParameters GetUserRolesParameters(UserRole entity, TransactionModes mode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TransMode", (int)mode, DbType.Int32);
            parameters.Add("@UserRoleId", entity.UserRoleId, DbType.Int32);
            parameters.Add("@UserRoleName", entity.UserRoleName, DbType.String);
            parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);
            parameters.Add("@Id", entity.Id, DbType.Int32);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            return parameters;
        }
        #endregion

        #region Generated Methods

        public async override Task<UserRole> GetAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ROL_ID", id, DbType.Int32);
                return await conn.QueryFirstOrDefaultAsync<UserRole>("[SIMS].[GetUserRoleData]", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<UserRole>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


        public override void InsertAsync(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(UserRole entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserRoleMapping>> GetAllUserRoleMappingData(string userName, string Id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userName, DbType.String);
                parameters.Add("@Id", Id, DbType.String);
                return await conn.QueryAsync<UserRoleMapping>("SIMS.GetAllUserRoleMappingData", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<UserRoleMapping>> GetAssignedUserMappingData(int systemlanguageid, int roleid)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SystemLanguageId", systemlanguageid, DbType.Int32);
                parameters.Add("@RoleId", roleid, DbType.Int32);
                return await conn.QueryAsync<UserRoleMapping>("Admin.GetAssignedUserMappingData", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ModuleStructure>> GetModuleList(int systemlanguageid, string modulecode)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SystemLanguageId", systemlanguageid, DbType.Int32);
                parameters.Add("@ModuleCode", modulecode, DbType.String);
                return await conn.QueryAsync<ModuleStructure>("Admin.GetModuleList", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ModuleStructure>> GetUserRolePermissionList()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<ModuleStructure>("Admin.GetUserRolePermissionList", CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ModuleStructure>> GetRolePowerPackModuleData(int userroleid)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserRoleId", userroleid, DbType.Int32);
                return await conn.QueryAsync<ModuleStructure>("Admin.GetRolePowerPackModuleData", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ModuleStructure>> GetRoleMappingData(int roleId, int Id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RoleId", roleId, DbType.Int32);
                parameters.Add("@RoleId", Id, DbType.Int32);
                return await conn.QueryAsync<ModuleStructure>("Admin.GetRoleMappingData", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ModuleStructure>> GetModuleStructureList(int systemlanguageid, int? moduleid, string modulecode)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SystemLanguageId", systemlanguageid, DbType.Int16);
                parameters.Add("@ModuleId", moduleid, DbType.Int32);
                parameters.Add("@ModuleCode", modulecode, DbType.String);
                return await conn.QueryAsync<ModuleStructure>("Admin.GetModuleStructureList", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<PermissionTypeView>> GetAllPermissionData(int userRoleId, int userId, int moduleId, bool loadCustomePermission, int Id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserRoleId", userRoleId, DbType.Int32);
                parameters.Add("@UserId", userId, DbType.Int32);
                parameters.Add("@ModuleId", moduleId, DbType.Int16);
                parameters.Add("@Id", Id, DbType.Int32);
                parameters.Add("@LoadCustomPermission", loadCustomePermission, DbType.Boolean);

                return await conn.QueryAsync<PermissionTypeView>("Admin.GetAllPermissionData", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<bool> UpdatePermissionTypeDataCUD(List<CustomPermissionEdit> MappingDetails, string operationtype, int? userId, short userRoleId, int Id)
        {
            using (var conn = GetOpenConnection())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("GrantPermission");
                if (MappingDetails != null)
                {
                    foreach (var item in MappingDetails)
                    {
                        dt.Rows.Add(item.PermissionId, item.GrantPermission);
                    }

                }
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId, DbType.Int32);
                parameters.Add("@UserRoleId", userRoleId, DbType.Int16);
                parameters.Add("@OperationType", operationtype, DbType.String);
                parameters.Add("@PermissionTypeData", dt, DbType.Object);
                parameters.Add("@Id", Id, DbType.Int32);
                parameters.Add("@output", 0, DbType.Int32, ParameterDirection.Output);


                if (userId == null)
                {
                    conn.Query<int>("[Admin].[BatchUpdatePermissionTypesCUD]", parameters, commandType: CommandType.StoredProcedure);
                    return parameters.Get<int>("output") > 0;
                }
                else
                {
                    conn.Query<int>("[Admin].[BatchUpdateUserCustomPermissionCUD]", parameters, commandType: CommandType.StoredProcedure);
                    return parameters.Get<int>("output") > 0;
                }
            }
        }

        public async Task<object> CheckUserRoleMapping(string userId, short? roleId)
        {
            using (var conn = GetOpenConnection())
            {
                string query = "SELECT COUNT(RoleId) FROM [SIMS].[UserRoleMapping] WHERE UserId = @UserId and RoleId = @RoleId";
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId, DbType.String);
                parameters.Add("@RoleId", roleId, DbType.Int32);

                return await conn.ExecuteScalarAsync(query, parameters, commandType: CommandType.Text);
            }
        }
        public async Task<bool> InsertUserRoleMappingData(string userId, short roleId)
        {

            using (var conn = GetOpenConnection())
            {
                string query = "Insert into [SIMS].[UserRoleMapping] (UserId,RoleId) values (@UserId,@RoleId) ";
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId, DbType.String);
                parameters.Add("@RoleId", roleId, DbType.Int64);
                return await conn.ExecuteAsync(query, parameters, commandType: CommandType.Text) > 0;

                //var parameters = new DynamicParameters();
                //parameters.Add("@TransMode", (int)TransactionModes.Insert, DbType.Int32);
                //parameters.Add("@UserId", userId, DbType.Int64);
                //parameters.Add("@RoleId", roleId, DbType.Int32);
                //parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //await conn.QueryAsync<Int32>("Admin.UserRoleMappingCUD", parameters, commandType: CommandType.StoredProcedure);
                //return parameters.Get<Int32>("output") > 0;
            }
        }
        public async Task<bool> DeleteUserRoleMappingData(string userId, short roleId)
        {
            using (var conn = GetOpenConnection())
            {
                string query = string.Join("\n",
                "Delete from [SIMS].[UserRoleMapping] WHERE UserId = @UserId and RoleId = @RoleId");

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId, DbType.String);
                parameters.Add("@RoleId", roleId, DbType.Int64);

                return await conn.ExecuteAsync(query, parameters, commandType: CommandType.Text) > 0;

                //var parameters = new DynamicParameters();
                //parameters.Add("@TransMode", (int)TransactionModes.Delete, DbType.Int32);
                //parameters.Add("@UserId", userId, DbType.String);
                //parameters.Add("@RoleId", roleId, DbType.Int32);
                //parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //await conn.QueryAsync<Int32>("Admin.UserRoleMappingCUD", parameters, commandType: CommandType.StoredProcedure);
                //return parameters.Get<Int32>("output") > 0;
            }
        }

        public async Task<IEnumerable<User>> GetUsersForRole(int roleId, int Id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ROL_ID", roleId, DbType.Int32);
                parameters.Add("@BSU_ID", Id, DbType.Int32);

                return await conn.QueryAsync<User>("[SIMS].GetUserListByRoleId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<PermissionTypeView>> GetAllReportPermissionData(int userRoleId, int moduleId, long Id, int isRoleId, int isUserId, int parentModuleId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserRoleId", userRoleId, DbType.Int32);
                parameters.Add("@ModuleId", moduleId, DbType.Int16);
                parameters.Add("@Id", Id, DbType.Int64);
                parameters.Add("@IsRoleId", isRoleId, DbType.Int32);
                parameters.Add("@IsUserId", isUserId, DbType.Int32);
                parameters.Add("@parentModuleId", parentModuleId, DbType.Int32);

                return await conn.QueryAsync<PermissionTypeView>("Admin.GetAllReportPermissionData", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public bool SetReportPermissionForUserAndRole(List<CustomPermissionEdit> MappingDetails, string operationtype, int userRoleId, long Id, short IsUser, short IsRole)
        {
            using (var conn = GetOpenConnection())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("GrantPermission");
                if (MappingDetails != null)
                {
                    foreach (var item in MappingDetails)
                    {
                        dt.Rows.Add(item.PermissionId, item.GrantPermission);
                    }

                }
                var parameters = new DynamicParameters();
                parameters.Add("@OperationType", operationtype, DbType.String);
                parameters.Add("@UserRoleId", userRoleId, DbType.Int32);
                parameters.Add("@Id", Id, DbType.Int64);
                parameters.Add("@PermissionTypeData", dt, DbType.Object);
                parameters.Add("@IsUser", IsUser, DbType.Int16);
                parameters.Add("@IsRole", IsRole, DbType.Int16);
                parameters.Add("@output", 0, DbType.Int32, ParameterDirection.Output);

                conn.Query<int>("[Admin].[SetReportPermissionForUserAndRole]", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;

            }
        }




        #endregion
    }
}
