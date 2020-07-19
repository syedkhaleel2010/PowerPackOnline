using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PowerPack.API.Repositories
{
    public class LogInUserRepository : SqlRepository<LogInUser>, ILogInUserRepository
    {
        private readonly IConfiguration _config;

        public LogInUserRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<LogInUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<LogInUser> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LogInUser> GetLogInUserByUserName(string UserName, string Password)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", UserName, DbType.String);
                parameters.Add("@Password", Password, DbType.String);
                return await conn.QueryFirstOrDefaultAsync<LogInUser>("Admin.GetOASISLogin", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<LogInUser>> GetUserList(int Id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id, DbType.Int32);
                return await conn.QueryAsync<LogInUser>("Admin.GetUserList", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public override void InsertAsync(LogInUser entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(LogInUser entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
