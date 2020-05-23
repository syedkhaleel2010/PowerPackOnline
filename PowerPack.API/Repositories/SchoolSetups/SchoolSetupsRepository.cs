using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;

namespace SIMS.API.Repositories
{
    public class SchoolSetupsRepository : SqlRepository<SubTerms>, ISchoolSetupsRepository
    {
        public SchoolSetupsRepository(IConfiguration configuration) : base(configuration)
        {
        }        

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<SubTerms>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<SubTerms> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(SubTerms entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(SubTerms entityToUpdate)
        {
            throw new NotImplementedException();
        }

        #region Assessment Term
        public async Task<string> AssessmentTermCUD(AssessmentTerm assessmentTerm)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TSM_ID", assessmentTerm.Id);
                parameters.Add("@TRM_ID", assessmentTerm.TermId);
                parameters.Add("@DESCRIPTION", assessmentTerm.Description);
                parameters.Add("@ORDER", assessmentTerm.DisplayOrder);
                parameters.Add("@b_LOCK", assessmentTerm.IsLock);
                parameters.Add("@DATAMODE", assessmentTerm.DataMode);
                return await conn.ExecuteScalarAsync<string>("SIMS.AssessmentTermCUD", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion
        #region Terminology
        public async Task<IEnumerable<Terminology>> GetTerminologyLable(long academicYearId, long schoolId, int CLM_ID, string LanguageCode, int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", academicYearId);
                parameters.Add("@BSU_ID", schoolId);
                parameters.Add("@CLM_ID", CLM_ID);
                parameters.Add("@DivisionId", divisionId);
                parameters.Add("@LANG_CODE", LanguageCode);
                return await conn.QueryAsync<Terminology>("[SIMS].[GetTerminology]", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<string> TerminologyCU(TerminologyCU terminologyCU)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", terminologyCU.AcademicId);
                parameters.Add("@CLM_ID", terminologyCU.CurriculumId);
                parameters.Add("@BSU_ID", terminologyCU.SchoolId);
                parameters.Add("@DivisionId", terminologyCU.DivisionId);
                parameters.Add("@LANG_CODE", terminologyCU.LangCode);
                parameters.Add("@Terminology", terminologyCU.TerminologiesDT, DbType.Object);
                parameters.Add("@output", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await conn.QueryAsync<string>("SIMS.TerminologyCU", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<string>("output");
            }
        }
        #endregion
        #region Academic Terms
        public async Task<IEnumerable<AcademicTerms>> GetAcademicTerms(long BSU_ID, long ACD_ID, long BSU_CLM_ID, int? divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID);
                parameters.Add("@ACD_ID", ACD_ID);
                parameters.Add("@BSU_CLM_ID", BSU_CLM_ID);
                parameters.Add("@DivisionId", divisionId);
                return await conn.QueryAsync<AcademicTerms>("[SIMS].[BindAcademicTerms]", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<string> AcademicTermsCUD(AcademicTerms AcademicTerms)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TRM_ID", AcademicTerms.TRM_ID);
                parameters.Add("@TRM_ACD_ID", AcademicTerms.ACD_ID);
                parameters.Add("@TRM_BSU_ID", AcademicTerms.BSU_ID);
                parameters.Add("@TRM_DESCRIPTION", AcademicTerms.Term_Description);
                parameters.Add("@TRM_STARTDATE", AcademicTerms.Term_StartDate);
                parameters.Add("@TRM_ENDDATE", AcademicTerms.Term_EndDate);
                parameters.Add("@TRM_DIVISION_ID", AcademicTerms.DivisionId);
                parameters.Add("@DATAMODE", AcademicTerms.DataMode);
                //parameters.Add("@output", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                return await conn.ExecuteScalarAsync<string>("SIMS.AcademicTermsCUD", parameters, commandType: CommandType.StoredProcedure);
                //await conn.QueryAsync<string>("SIMS.AcademicTermsCUD", parameters, commandType: CommandType.StoredProcedure);
                //return parameters.Get<string>("output");
                //parameters.Add("@output", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                //return await conn.ExecuteScalarAsync<string>("SIMS.AcademicTermsCUD", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion


        #region Grade Master
        /// <summary>
        /// Get the grade list
        /// </summary>
        /// <param name="academicYearId"></param>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GradeDisplay>> GradeDisplay(long academicYearId, long schoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", academicYearId);
                parameters.Add("@BSU_ID", schoolId);
                return await conn.QueryAsync<GradeDisplay>("[SIMS].[GetGradeDisplay]", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<string> GradeDisplayU(GradeDisplayU gradeDisplay)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GradeDisplay", gradeDisplay.GradeDisplaysDT, DbType.Object);
                parameters.Add("@output", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await conn.QueryAsync<string>("SIMS.GradeDisplayU", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<string>("output");
            }
        }
        #endregion
    }
}
