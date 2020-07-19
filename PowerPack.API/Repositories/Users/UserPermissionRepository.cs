using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using PowerPack.API.Models;

namespace PowerPack.API.Repositories
{
    public class UserPermissionRepository : SqlRepository<UserPermission>, IUserPermissionRepository
    {
        private readonly IConfiguration _config;

        public UserPermissionRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }
        public PagePermission GetUserPermissions(string userId, string moduleUrl, string moduleCode, int userTypeId)
        {
            PagePermission permission = new PagePermission();
            //permission.UserId = userId;
            using (var conn = GetOpenConnection())
            {
                if (/*userTypeId == (int)UserTypes.StoreAdmin ||*/ userTypeId == (int)UserTypes.SuperAdmin)//Admin
                {
                    //Get ModuleId
                    string query = "SELECT top 1 ModuleId FROM Admin.ActivePowerPackModuleStructure";

                    DynamicParameters parameter = new DynamicParameters();
                    if (!string.IsNullOrEmpty(moduleUrl))
                    {
                        query += " WHERE lower(dbo.FormatModuleUrl(ModuleUrl)) = lower(dbo.FormatModuleUrl(@ModuleUrl))";
                        parameter.Add("@ModuleUrl", moduleUrl, DbType.String);
                    }
                    else
                    {
                        query += " WHERE lower(ModuleCode) = lower(@ModuleCode)";
                        parameter.Add("@ModuleCode", moduleCode, DbType.String);
                    }

                    permission.ModuleId = conn.QueryFirstOrDefault<int>(query, parameter, commandType: CommandType.Text);
                    permission.CanView = permission.CanAdd = permission.CanEdit = permission.CanDelete = true;
                }
                else
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserId", userId, DbType.String);
                    parameters.Add("@ModuleUrl", moduleUrl, DbType.String);
                    if (!string.IsNullOrEmpty(moduleCode))
                        parameters.Add("@ModuleCode", moduleCode, DbType.String);
                    var modulePermission = conn.QueryFirstOrDefault<ModulePermission>("[Admin].[GetUserPermissions]", parameters, commandType: CommandType.StoredProcedure);

                    permission = new PagePermission();
                    if (modulePermission != null)
                    {
                        permission.ModuleId = modulePermission.ModuleId;

                        if (!string.IsNullOrEmpty(modulePermission.PermissionCategoryIds))
                        {
                            string[] permissionCategories = modulePermission.PermissionCategoryIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (permissionCategories.Count() > 0)
                            {
                                if (permissionCategories.Contains(((int)PermissionCategory.View).ToString()))
                                {
                                    permission.CanView = true;
                                    if (permissionCategories.Contains(((int)PermissionCategory.AddEditDelete).ToString()))
                                    {
                                        permission.CanAdd = true; permission.CanEdit = true; permission.CanDelete = true;
                                    }
                                    else
                                    {
                                        if (permissionCategories.Contains(((int)PermissionCategory.Add).ToString()))
                                            permission.CanAdd = true;

                                        if (permissionCategories.Contains(((int)PermissionCategory.Update).ToString()))
                                            permission.CanEdit = true;

                                        if (permissionCategories.Contains(((int)PermissionCategory.Delete).ToString()))
                                            permission.CanDelete = true;
                                    }

                                }
                            }
                        }
                    }
                }
            }
            return permission;
        }



        public bool IsPermissionAssigned(string userName, string moduleUrl, int userTypeId = 1)
        {
            if (/*userTypeId == (int)UserTypes.StoreAdmin || */userTypeId == (int)UserTypes.SuperAdmin)
                return true;
            using (var conn = GetOpenConnection())
            {
                bool isPermissionAssigned = false;
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", userName, DbType.String);
                parameters.Add("@ModuleUrl", moduleUrl, DbType.String);
                isPermissionAssigned = conn.QueryFirstOrDefault<bool>("SELECT Admin.[IsPermissionAssigned](@UserID, @ModuleUrl)", parameters, commandType: CommandType.Text);
                return isPermissionAssigned;
            }
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<UserPermission>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<UserPermission> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(UserPermission entity)
        {
            throw new NotImplementedException();
        }
        public override void UpdateAsync(UserPermission entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public Int32 AddMenuItem(MenuItem menuItem)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MenuCategory", menuItem.MenuCategory, DbType.String);
                parameters.Add("@ModuleName", menuItem.ModuleName, DbType.String);
                parameters.Add("@CssClass", menuItem.CssClass, DbType.String);
                parameters.Add("@ModuleUrl", menuItem.ModuleUrl, DbType.String);
                parameters.Add("@ParentModuleId", menuItem.ParentModuleId, DbType.Int16);
                parameters.Add("@Sequence", menuItem.Sequence, DbType.Int32);
                parameters.Add("@ModuleCode", menuItem.ModuleCode, DbType.String);
                parameters.Add("@ShowInMenu", menuItem.ShowInMenu, DbType.Boolean);
                conn.Query<Int32>("[Admin].[InsertMenuItem]", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<Int32>("output");
            }
        }

        public bool IsCustomPermissionAssigned(int userId, string permissionCodes)
        {
            using (var conn = GetOpenConnection())
            {
                bool isPermissionAssigned = false;
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId, DbType.Int64);
                parameters.Add("@PermissionCodes", permissionCodes, DbType.String);
                isPermissionAssigned = conn.QueryFirstOrDefault<bool>("SELECT Admin.UserHasCustomPermission (@UserId, @PermissionCodes)", parameters, commandType: CommandType.Text);
                return isPermissionAssigned;
            }
        }

        public async Task<IEnumerable<ModuleStructure>> GetReportList()
        {
            using (var conn = GetOpenConnection())
            {
               
                return await conn.QueryAsync<ModuleStructure>("Admin.GetReportList", null, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
