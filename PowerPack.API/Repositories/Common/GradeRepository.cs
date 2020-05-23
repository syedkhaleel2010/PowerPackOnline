using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PowerPack.Common.Models;

namespace SIMS.API.Repositories
{
    public class GradeRepository: SqlRepository<Grades>, IGradeRepository
    {
        private readonly IConfiguration _config;

        public GradeRepository(IConfiguration configuration): base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Grades>> GetAllAsync()
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();

                return await conn.QueryAsync<Grades>("SIMS.GetGrades", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public override async Task<Grades> GetAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", id, DbType.Int32);
                return await conn.QueryFirstAsync<Grades>("SIMS.GetGrades", parameters, null, null, CommandType.StoredProcedure);
            }
        }

         public async Task<IEnumerable<Grades>> GetList(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", id, DbType.Int32);
                return await conn.QueryAsync<Grades>("SIMS.GetGrades", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Sections>> GetSectionList(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GRD_ID", id, DbType.String);
                return await conn.QueryAsync<Sections>("SIMS.GetSections", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<GradesAccess>> GetGradesAccess(string username,string isSuperUser,Int32 acd_id,Int32 bsu_id,int grd_access,Int32 rsm_id,int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@USERNAME", username, DbType.String);
                parameters.Add("@IsSuperUser", isSuperUser, DbType.String);
                parameters.Add("@ACD_ID", acd_id, DbType.Int32);
                parameters.Add("@BSU_ID", bsu_id, DbType.Int32);
                parameters.Add("@GRD_ACCESS", grd_access, DbType.Int32);
                parameters.Add("@RSM_ID", rsm_id, DbType.Int32);
                parameters.Add("@DivisionId", divisionId, DbType.Int32);
                return await conn.QueryAsync<GradesAccess>("SIMS.BindGradeAccess", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Subjects>> GetSubjectsByGrade(Int32 acd_id, string grd_id, string username = "",string IsSuperUser="")
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", acd_id, DbType.Int32);
                parameters.Add("@GRDID", grd_id, DbType.String);
                parameters.Add("@username", username, DbType.String);
                parameters.Add("@IsSuperUser", IsSuperUser, DbType.String);
                return await conn.QueryAsync<Subjects>("SIMS.GetSubjectByGrade", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<SubjectGroups>> GetSubjectGroupBySubject(string username, string isSuperUser, Int32 bsu_id, string grd_id, Int32 sbg_id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@USERNAME", username, DbType.String);
                parameters.Add("@IsSuperUser", isSuperUser, DbType.String);
                parameters.Add("@BSU_ID", bsu_id, DbType.Int32);
                parameters.Add("@GRD_ID", grd_id, DbType.String);
                parameters.Add("@SBG_ID", sbg_id, DbType.Int32);
                return await conn.QueryAsync<SubjectGroups>("SIMS.GetSubjectGroupBySubject", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public override void InsertAsync(Grades entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(Grades entityToUpdate)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<ListItem>> GetSelectListItems(string listCode, string whereCondition, string whereConditionParamValues)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SelectListCode", listCode, DbType.String);
                parameters.Add("@SelectListCode", listCode, DbType.String);
                parameters.Add("@WhereCondition", whereCondition, DbType.String);
                parameters.Add("@WhereConditionParamValues", whereConditionParamValues, DbType.String);
                return await conn.QueryAsync<ListItem>("Admin.GetSelectListItems", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ListItem>> GetAcademicYearLists(string SchoolId, int CurriculumId, bool? IsCurrentCurriculum)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_BSU_ID", SchoolId, DbType.String);
                parameters.Add("@ACD_CLM_ID", CurriculumId, DbType.Int32);
                parameters.Add("@ACD_CURRENT", IsCurrentCurriculum, DbType.Boolean);
                return await conn.QueryAsync<ListItem>("[SIMS].[GetAcademicYearList]", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
