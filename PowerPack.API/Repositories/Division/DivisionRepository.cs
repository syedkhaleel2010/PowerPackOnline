using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace SIMS.API.Repositories
{
    public class DivisionRepository : SqlRepository<DivisionDetails>, IDivisionRepositorycs
    {
        private readonly IConfiguration _config;
        public DivisionRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<DivisionDetails>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<DivisionDetails> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(DivisionDetails entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(DivisionDetails entityToUpdate)
        {
            throw new NotImplementedException();
        }
        public async Task<int> SaveDivisionDetails(DivisionDetails DivisionDetails, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {

                var parameters = new DynamicParameters();
                parameters.Add("@DivisionId", DivisionDetails.DivisionId, DbType.Int64);
                parameters.Add("@DivisionName", DivisionDetails.DivisionName, DbType.String);
                parameters.Add("@GradeId", DivisionDetails.GradeList, DbType.String);
                parameters.Add("@SchoolId", DivisionDetails.BSU_ID, DbType.Int64);
                parameters.Add("@CreatedBy", DivisionDetails.CREATED_BY, DbType.String);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.SaveDivisionDetails", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<DivisionDetails>> GetDivisionDetails(long BSU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                
                return await conn.QueryAsync<DivisionDetails>("SIMS.GetDivisionDetails", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<DivisionDetails>> GetDivisionDetails(long BSU_ID, long acdId, string isSuperUser, string username)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", acdId, DbType.Int64);
                parameters.Add("@IsSuperUser", isSuperUser, DbType.String);
                parameters.Add("@Username", username, DbType.String);
                return await conn.QueryAsync<DivisionDetails>("SIMS.GetDivisionDetailsForDropdown", parameters, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
