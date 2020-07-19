using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Models.Entities;

namespace PowerPack.API.Repositories
{
    public class UserLoginLogRepository : SqlRepository<UserLoginLogs>, IUserLoginLogRepository
    {
        public UserLoginLogRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #region Generated Methods
        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<UserLoginLogs>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<UserLoginLogs> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(UserLoginLogs entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(UserLoginLogs entityToUpdate)
        {
            throw new NotImplementedException();
        }
        #endregion
        public async Task<long> InsertUserLoginLogs(UserLoginLogs loginLogs)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LoginUserName", loginLogs.LoginUserName);
                parameters.Add("@LoginMode", loginLogs.LoginMode);
                parameters.Add("@LoginStatus", loginLogs.LoginStatus);
                parameters.Add("@LoginBrowser", loginLogs.LoginBrowser);
                parameters.Add("@LoginSource", loginLogs.LoginSource);
                parameters.Add("@LoginIP", loginLogs.LoginIP);
                parameters.Add("@IsPowerPackApiValid", loginLogs.IsPowerPackApiValid);
                parameters.Add("@LoginSessionId", loginLogs.LoginSessionId);
                parameters.Add("@AuthorizationLog", loginLogs.AuthorizationLog);
                parameters.Add("@output",direction: ParameterDirection.Output, dbType: DbType.Int64);
                await conn.QueryAsync<long>("[Logs].[UserLoginLogC]", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<long>("output");
            }
        }        
    }
}
