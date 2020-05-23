using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Common.Enums;
using SIMS.API.Models.CertificateBuilder;
using SIMS.API.Repositories.CertificateBuilder.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Repositories.CertificateBuilder
{
    public class CertificateBuilderRepository : SqlRepository<Template>, ICertificateBuilderRepository
    {
        private readonly IConfiguration configuration;

        public CertificateBuilderRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }

        public override void DeleteAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = GetTemplateParameters(new Template(id), TransactionModes.Delete);
                conn.Query<Int32>("SIMS.CRB_TemplateCUD", parameters, commandType: CommandType.StoredProcedure);
                parameters.Get<Int32>("Output");
            }
        }
        public async Task<bool> Delete(int id, string deletedBy)
        {
            using (var conn = GetOpenConnection())
            {
                var entity = new Template(id);
                entity.UpdatedBy = deletedBy;
                var parameters = GetTemplateParameters(entity, TransactionModes.Delete);
                await conn.QueryAsync<Int32>("SIMS.CRB_TemplateCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<Int32>("Output") > 0;
            }
        }

        public async override Task<IEnumerable<Template>> GetAllAsync()
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TemplateId", DBNull.Value, DbType.Int64);
                parameters.Add("@SchoolId", DBNull.Value, DbType.Int64);
                parameters.Add("@TemplateType", DBNull.Value, DbType.String);
                parameters.Add("@Period", DBNull.Value, DbType.String);
                parameters.Add("@UserId", DBNull.Value, DbType.Int64);
                parameters.Add("@IsActive", DBNull.Value, DbType.Boolean);
                return await conn.QueryAsync<Template>("SIMS.CRB_GetTemplate", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async override Task<Template> GetAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TemplateId", id, DbType.Int64);
                parameters.Add("@SchoolId", DBNull.Value, DbType.Int64);
                parameters.Add("@TemplateType", DBNull.Value, DbType.String);
                parameters.Add("@Period", DBNull.Value, DbType.String);
                parameters.Add("@UserId", DBNull.Value, DbType.Int64);
                parameters.Add("@IsActive", DBNull.Value, DbType.Boolean);
                return await conn.QueryFirstOrDefaultAsync<Template>("SIMS.CRB_GetTemplate", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Template>> GetTemplatesBySchoolId(long schoolId, string userId, bool isActive, string TemplateType, int? status, int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var model = new Template();
                var parameters = new DynamicParameters();
                parameters.Add("@TemplateId", DBNull.Value, DbType.Int64);
                parameters.Add("@SchoolId", schoolId, DbType.Int64);
                parameters.Add("@TemplateType", TemplateType, DbType.String);
                parameters.Add("@Period", DBNull.Value, DbType.String);
                parameters.Add("@Status", status, DbType.Int32);
                parameters.Add("@UserId", userId, DbType.String);
                parameters.Add("@IsActive", isActive, DbType.Boolean);
                parameters.Add("@DivisionId", divisionId, DbType.Int32);
                parameters.Add("@IncludeTemplateField", DBNull.Value, DbType.Boolean);
                return await conn.QueryAsync<Template>("SIMS.CRB_GetTemplate", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<Template> GetTemplateDetail(int? templateId, int? schoolId, string templateType, string period, string userId, bool? isActive, bool? includeTemplateField, int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var model = new Template();
                var parameters = new DynamicParameters();
                parameters.Add("@TemplateId", templateId, DbType.Int64);
                parameters.Add("@SchoolId", schoolId, DbType.Int64);
                parameters.Add("@TemplateType", templateType, DbType.String);
                parameters.Add("@Period", period, DbType.String);
                parameters.Add("@Status", DBNull.Value, DbType.Int32);
                parameters.Add("@UserId", userId, DbType.String);
                parameters.Add("@IsActive", isActive, DbType.Boolean);
                parameters.Add("@DivisionId", divisionId, DbType.Int32);
                parameters.Add("@IncludeTemplateField", includeTemplateField, DbType.Boolean);
                var result = await conn.QueryMultipleAsync("SIMS.CRB_GetTemplate", parameters, null, null, CommandType.StoredProcedure);

                model = result.ReadFirstOrDefault<Template>();
                if (includeTemplateField != null && includeTemplateField == true)
                {
                    var templateFieldList = await result.ReadAsync<TemplateField>();
                    model.TemplateFields = templateFieldList.ToList();
                }
                return model;
            }
        }

        //public async Task<TemplateField> GetTemplateFieldById(int templateFieldId)
        //{
        //    using (var conn = GetOpenConnection())
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@TemplateId", DBNull.Value, DbType.Int64);
        //        parameters.Add("@TemplateFieldId", templateFieldId, DbType.Int64);
        //        parameters.Add("@UserId", DBNull.Value, DbType.Int64);
        //        parameters.Add("@IsActive", DBNull.Value, DbType.Boolean);
        //        return await conn.QueryFirstOrDefaultAsync<TemplateField>("DE.GetTemplateField", parameters, null, null, CommandType.StoredProcedure);
        //    }
        //}

        //public async Task<IEnumerable<TemplateField>> GetTemplateFieldByTemplateId(int templateId, bool isActive)
        //{
        //    using (var conn = GetOpenConnection())
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@TemplateId", templateId, DbType.Int64);
        //        parameters.Add("@TemplateFieldId", DBNull.Value, DbType.Int64);
        //        parameters.Add("@UserId", DBNull.Value, DbType.Int64);
        //        parameters.Add("@IsActive", isActive, DbType.Boolean);
        //        return await conn.QueryAsync<TemplateField>("DE.GetTemplateField", parameters, null, null, CommandType.StoredProcedure);
        //    }
        //}

        public override void InsertAsync(Template entity)
        {
            
        }

        public async Task<int> Insert(Template entity)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = GetTemplateParameters(entity, TransactionModes.Insert);
                await conn.QueryAsync<Int32>("SIMS.CRB_TemplateCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<Int32>("Output");
            }
        }

        public override void UpdateAsync(Template entityToUpdate)
        {
            
        }

        public async Task<int> Update(Template entityToUpdate)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = GetTemplateParameters(entityToUpdate, TransactionModes.Update);
                await conn.QueryAsync<Int32>("SIMS.CRB_TemplateCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<Int32>("Output");
            }
        }


        #region Private Methods
        private DynamicParameters GetTemplateParameters(Template entity, TransactionModes mode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TransMode", (int)mode, DbType.Int32);
            parameters.Add("@TemplateId", entity.TemplateId, DbType.Int64);
            parameters.Add("@SchoolId", entity.SchoolId, DbType.Int64);
            parameters.Add("@Title", entity.Title, DbType.String);
            parameters.Add("@Description", entity.Description, DbType.String);
            parameters.Add("@TemplateType", entity.TemplateType, DbType.String);
            parameters.Add("@Period", entity.Period, DbType.String);
            parameters.Add("@Status", entity.Status, DbType.Int32);
            parameters.Add("@FileName", entity.FileName, DbType.String);
            parameters.Add("@FilePath", entity.FilePath, DbType.String);
            parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);
            parameters.Add("@CreatedBy", entity.CreatedBy, DbType.String);
            parameters.Add("@UpdatedBy", entity.UpdatedBy, DbType.String);
            parameters.Add("@DivisionId", entity.DivisionId, DbType.Int32);
            parameters.Add("@IsApprovalRequired", entity.IsApprovalRequired, DbType.Boolean);
            parameters.Add("@Output", dbType: DbType.Int32, direction: ParameterDirection.Output);

            if (entity.TemplateFields.Count > 0 && mode != TransactionModes.Delete)
            {
                DataTable dtTemplateField = new DataTable();
                dtTemplateField.Columns.Add("TemplateFieldId", typeof(Int64));
                dtTemplateField.Columns.Add("Field", typeof(string));
                dtTemplateField.Columns.Add("Placeholder", typeof(string));
                dtTemplateField.Columns.Add("IsLabel", typeof(bool));
                dtTemplateField.Columns.Add("IsActive", typeof(bool));
                dtTemplateField.Columns.Add("CertificateColumnId", typeof(int));
                foreach (var item in entity.TemplateFields)
                {
                    dtTemplateField.Rows.Add(item.TemplateFieldId, item.Field, item.Placeholder, item.IsLabel, item.IsActive, item.CertificateColumnId);
                }

                parameters.Add("@TemplateField", dtTemplateField, DbType.Object);
            }

            return parameters;
        }
        #endregion
        public async Task<bool> SaveTemplateImageData(Template templateModel)
        {
            bool result = false;
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TemplateId", templateModel.TemplateId, DbType.Int64);
                parameters.Add("@FileName", templateModel.FileName, DbType.String);
                parameters.Add("@FilePath", templateModel.FilePath, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Query<int>("SIMS.CRB_SaveTemplateFileData", parameters, commandType: CommandType.StoredProcedure);
                if (parameters.Get<int>("output") > 0)
                    result = true;
                else
                    result = false;
            }
            return result;
        }

        public async Task<bool> SaveCertificateAssignedColumns(IEnumerable<TemplateField> fieldList)
        {
            var dt = new DataTable();
            dt.Columns.Add("CertificateColumnId", typeof(int));
            dt.Columns.Add("TemplateId", typeof(long));
            dt.Columns.Add("TemplateFieldId", typeof(long));
            foreach (var item in fieldList)
            {
                dt.Rows.Add(item.CertificateColumnId, item.TemplateId, item.TemplateFieldId);
            }

            bool result = false;
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FieldsData", dt, DbType.Object);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryAsync<int>("SIMS.CRB_SaveCertificateAssignedColumns", parameters, commandType: CommandType.StoredProcedure);
                if (parameters.Get<int>("output") > 0)
                    result = true;
                else
                    result = false;
            }
            return result;
        }

        public async Task<IEnumerable<TemplateFieldMapping>> GetTemplateFieldData(int templateId, long studentId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StudentId", studentId, DbType.Int64);
                parameters.Add("@TemplateId", templateId, DbType.Int32);
                return await conn.QueryAsync<TemplateFieldMapping>("SIMS.CRB_GetTemplateFieldMappingData", parameters, null, null, CommandType.StoredProcedure);                
            }
        }
    }
}
