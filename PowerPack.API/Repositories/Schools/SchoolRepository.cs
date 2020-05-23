using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SIMS.API.Repositories
{
    public class SchoolRepository : SqlRepository<SchoolInformation>, ISchoolRepository
    {
        private readonly IConfiguration _config;

        public SchoolRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public async Task<IEnumerable<SchoolInformation>> GetSchoolList()
        {
            using (var conn = GetOpenConnection())
            {               
                return await conn.QueryAsync<SchoolInformation>("Admin.GetSchoolList", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<SchoolInformation>> GetAdminSchoolList()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<SchoolInformation>("[Admin].[GetAdminSchoolList]", commandType: CommandType.StoredProcedure);
            }
        }

        #region Generated Methods

        public async override Task<SchoolInformation> GetAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SchoolId", id, DbType.Int32);
                return await conn.QueryFirstOrDefaultAsync<SchoolInformation>("Admin.GetSchoolById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<SchoolInformation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
       

        public override void InsertAsync(SchoolInformation entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(SchoolInformation entityToUpdate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
