using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Common.Enums;
using PowerPack.Common.Models;

namespace SIMS.API.Repositories
{
    public class TerminologyEditorRepository : SqlRepository<TerminologyEditorView>, ITerminologyEditorRepository
    {
        private readonly IConfiguration _config;

        public TerminologyEditorRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }
        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<TerminologyEditorView>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<TerminologyEditorView> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TerminologyEditorView>> GetTerminologyEditor(int? id,long schoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@SchoolId", schoolId, DbType.Int64);
                return await conn.QueryAsync<TerminologyEditorView>("Admin.GetTerminologyEditor", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public override void InsertAsync(TerminologyEditorView entity)
        {
            throw new NotImplementedException();
        }

        public bool TerminologyEditorCUD(TerminologyEditorView model, TransactionModes mode)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", model.Id, DbType.Int32);
                parameters.Add("@TransMode", (int)mode, DbType.Int32);
                parameters.Add("@SchoolId", model.SchoolId, DbType.Int64);
                parameters.Add("@UserId", model.UserId, DbType.Int64);
                parameters.Add("@OldTerm", model.OldTerm, DbType.String);
                parameters.Add("@NewTerm", model.NewTerm, DbType.String);
                parameters.Add("@UpdatedBy", model.UpdatedBy, DbType.Int64);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                 conn.Query<int>("Admin.TerminologyEditorCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        public override void UpdateAsync(TerminologyEditorView entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool CheckForTerminology(string term,int id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Term", term, DbType.String);
                parameters.Add("@Id", id, DbType.Int32);
                return conn.ExecuteScalar<bool>("Admin.CheckForTerminology", parameters, null, null, CommandType.StoredProcedure);
                
            }
            
        }
    }
}
