using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Repositories
{
    public class CommonSettingRepository : SqlRepository<CommonSetting>, ICommonSettingRepository
    {
        public CommonSettingRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<CommonSetting>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<CommonSetting> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(CommonSetting entity)
        {
            throw new NotImplementedException();
        }

        public long OperationDetailsCU(OperationAudit operationAudit)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", operationAudit.Id);
                parameters.Add("@ControllerName", operationAudit.ControllerName);
                parameters.Add("@ActionName", operationAudit.ActionName);
                parameters.Add("@Parameter", operationAudit.Parameters);
                parameters.Add("@CreatedBy", operationAudit.User.Id);
                parameters.Add("@result", operationAudit.Result);
                return conn.QueryAsync<long>("[logs].OperationDetailsCU", parameters, null, null, CommandType.StoredProcedure).Result.Single();
            }
        }

        public override void UpdateAsync(CommonSetting entityToUpdate)
        {
            throw new NotImplementedException();
        }


    }
}
