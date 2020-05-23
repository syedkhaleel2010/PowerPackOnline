using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Repositories
{
    public class ModuleStructureRepository : SqlRepository<ModuleStructure>, IModuleStructureRepository
    {
        private readonly IConfiguration _config;

        public ModuleStructureRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public async Task<IEnumerable<ModuleStructure>> GetPowerPackModuleStructure( int systemLanguageId, 
            int userId, string applicationCode, string traverseDirection, string moduleUrl, string moduleCode, bool excludeParent, 
            string excludeModuleCodes, bool? showInMenu)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId, DbType.String);
                parameters.Add("@ApplicationCode", applicationCode, DbType.String);
                parameters.Add("@TraverseDirection", traverseDirection, DbType.String);
                parameters.Add("@SystemLanguageId", systemLanguageId, DbType.String);
                parameters.Add("@ModuleUrl", moduleUrl, DbType.String);
                parameters.Add("@ModuleCode", moduleCode, DbType.String);
                parameters.Add("@ExcludeParent", excludeParent, DbType.Boolean);
                parameters.Add("@ExcludeModuleCodes", excludeModuleCodes, DbType.String);
                parameters.Add("@ShowInMenu", showInMenu, DbType.Boolean);
                return await conn.QueryAsync<ModuleStructure>("Admin.GetModuleStructure", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        #region Generated Methods

        public async override Task<ModuleStructure> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ModuleStructure>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


        public override void InsertAsync(ModuleStructure entity)
        {
            throw new NotImplementedException();
        }


        public override void UpdateAsync(ModuleStructure entityToUpdate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
