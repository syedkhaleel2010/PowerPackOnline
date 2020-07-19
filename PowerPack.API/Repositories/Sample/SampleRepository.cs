using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.API.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace PowerPack.API.Repositories
{
    public class SampleRepository : SqlRepository<SampleDetails>, ISampleRepositorycs
    {
        private readonly IConfiguration _config;
        public SampleRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<SampleDetails>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<SampleDetails> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(SampleDetails entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(SampleDetails entityToUpdate)
        {
            throw new NotImplementedException();
        }
        //public async Task<int> SaveSampleDetails(SampleDetails SampleDetails, string DATAMODE)
        //{
        //    using (var conn = GetOpenConnection())
        //    {

        //        var parameters = new DynamicParameters();
        //        parameters.Add("@SampleId", SampleDetails.SampleId, DbType.Int64);
        //        parameters.Add("@SampleName", SampleDetails.SampleName, DbType.String);
        //        parameters.Add("@GradeId", SampleDetails.GradeList, DbType.String);
        //        parameters.Add("@Id", SampleDetails.BSU_ID, DbType.Int64);
        //        parameters.Add("@CreatedBy", SampleDetails.CREATED_BY, DbType.String);
        //        parameters.Add("@DATAMODE", DATAMODE, DbType.String);
        //        parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        await conn.QueryFirstOrDefaultAsync<int>("SIMS.SaveSampleDetails", parameters, null, null, CommandType.StoredProcedure);
        //        return parameters.Get<int>("output");
        //    }
        //}
        public async Task<IEnumerable<SampleDetails>> GetSampleDetails(long BSU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                
                return await conn.QueryAsync<SampleDetails>("SIMS.GetSampleDetails", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<SampleDetails>> GetSampleDetails(long BSU_ID, long acdId, string isSuperUser, string username)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", acdId, DbType.Int64);
                parameters.Add("@IsSuperUser", isSuperUser, DbType.String);
                parameters.Add("@Username", username, DbType.String);
                return await conn.QueryAsync<SampleDetails>("SIMS.GetSampleDetailsForDropdown", parameters, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
