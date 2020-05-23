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
    public class CurriculumRoleRepository : SqlRepository<CurriculumRole>, ICurriculumRoleRepository
    {
        private readonly IConfiguration _config;

        public CurriculumRoleRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<CurriculumRole>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<CurriculumRole> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CurriculumRole> GetUserCurriculumRole(string BSU_ID = "", string UserName = "")
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.String);
                parameters.Add("@UserName", UserName, DbType.String);
                return await conn.QueryFirstOrDefaultAsync<CurriculumRole>("SIMS.GetACDID_CLMID_IsSuperUser", parameters, null, null, CommandType.StoredProcedure);
            }

        }

        public async Task<IEnumerable<Curriculum>> GetCurriculum(long BSU_ID, int? CLM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.String);
                parameters.Add("@CLM_ID", CLM_ID, DbType.Int32);
                return await conn.QueryAsync<Curriculum>("[SIMS].[GetCurriculum]", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public override void InsertAsync(CurriculumRole entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(CurriculumRole entityToUpdate)
        {
            throw new NotImplementedException();
        }

       
    }
}
