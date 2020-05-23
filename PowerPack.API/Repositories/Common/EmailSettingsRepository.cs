using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PowerPack.Common.ViewModels;
using PowerPack.Common.Models;
using PowerPack.Common.DataAccess;
using PowerPack.Common.Helpers;

namespace SIMS.API.Repositories
{
    public class EmailSettingsRepository : SqlRepository<EmailSettingsView>, IEmailSettingsRepository
    {
        private readonly IConfiguration _config;

        public EmailSettingsRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<EmailSettingsView>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<EmailSettingsView> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmailSettingsView> GetEmailSettings()
        {
            using (var conn = GetOpenConnection())
            {
                string query = "SELECT TOP 1 AuthorizedName, SenderName, SenderEmail, SenderPassword, SMTPClient, PortNo, IsSSLEnabled FROM Admin.EmailSettings";

                return await conn.QueryFirstOrDefaultAsync<EmailSettingsView>(query, commandType: CommandType.Text);
            }
        }

        public async Task<SystemLanguage> GetSchoolCurrentLanguage(int SchoolId)
        {
            using (var conn = GetOpenConnection())
            {
                string query = "SELECT TOP 1 SystemLanguageId FROM Admin.SchoolSettings WHERE SchoolId = @SchoolId";
                var parameters = new DynamicParameters();
                parameters.Add("@SchoolId", SchoolId, DbType.Int32);
                return await conn.QueryFirstOrDefaultAsync<SystemLanguage>(query,parameters, commandType: CommandType.Text);
            }
        }

        public override void InsertAsync(EmailSettingsView entity)
        {
            throw new NotImplementedException();
        }

        public bool SetSchoolCurrentLanguage(int languageId, int schoolId)
        {
            using (var conn = GetOpenConnection())
            {
                bool response = false;
                var parameters = new DynamicParameters();
                parameters.Add("@SchoolId", schoolId, DbType.Int32);
                parameters.Add("@languageId", languageId, DbType.Int32);
                response= conn.QueryFirstOrDefault<bool>("Admin.SetSchoolCurrentLanguage", parameters, commandType: CommandType.StoredProcedure);
                return response;
            }
        }

        public override void UpdateAsync(EmailSettingsView entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
