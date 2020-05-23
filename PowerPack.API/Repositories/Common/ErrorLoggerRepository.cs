using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Repositories
{
    public class ErrorLoggerRepository : SqlRepository<ErrorLogModel>, IErrorLoggerRepository
    {
        public ErrorLoggerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        #region Generated Methods
        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ErrorLogModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<ErrorLogModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }        

        public override void InsertAsync(ErrorLogModel entity)
        {
            throw new NotImplementedException();
        }        

        public override void UpdateAsync(ErrorLogModel entityToUpdate)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Public Method
        public async Task<string> GetErrorLog(string applicationName, Guid errorId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Application", applicationName, DbType.String);
                parameters.Add("@ErrorId", errorId, DbType.Guid);
                return await conn.QueryFirstOrDefaultAsync<string>("[logs].[GetErrorXml]", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ErrorLog GetErrorLogs(string applicationName, int pageIndex, int pageSize, string search, string sortColumn, string sortColumnDir)
        {
            var errorLog = new ErrorLog();
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Application", applicationName, DbType.String);
                parameters.Add("@PageIndex", pageIndex, DbType.Int32);
                parameters.Add("@PageSize", pageSize, DbType.Int32);
                if (!string.IsNullOrEmpty(search))
                    parameters.Add("@search", search, DbType.String);
                parameters.Add("@sortColumn", sortColumn, DbType.String);
                parameters.Add("@sortColumnDir", sortColumnDir, DbType.String);
                parameters.Add("@TotalCount", direction: ParameterDirection.Output, dbType: DbType.Int32);
                errorLog.ErrorLogs = conn.Query<ErrorLogModel>("[logs].[GetErrorsXml]", parameters, commandType: CommandType.StoredProcedure);
                errorLog.TotalCount = parameters.Get<int>("TotalCount");
                return errorLog;
            }
        }

        public async Task<bool> LogError(ErrorLogModel error)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ErrorId", error.ErrorId, DbType.Guid);
                parameters.Add("@Application", error.Application);
                parameters.Add("@Host", error.Host);
                parameters.Add("@Type", error.Type);
                parameters.Add("@Source", error.Source);
                parameters.Add("@User", error.User);
                parameters.Add("@Message", error.Message);
                parameters.Add("@AllXml", error.AllXml);
                parameters.Add("@StatusCode", error.StatusCode);
                parameters.Add("@SchoolId", error.SchoolId);
                parameters.Add("@TimeUtc", error.TimeUtc);
                parameters.Add("@output", direction: ParameterDirection.Output, dbType: DbType.Boolean);
                await conn.QueryAsync("[logs].[LogError]", parameters, commandType: CommandType.StoredProcedure);
                return  parameters.Get<bool>("output");
            }
        }
        #endregion
    }
}
