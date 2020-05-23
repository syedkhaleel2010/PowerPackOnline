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
using SIMS.API.Helpers;

namespace SIMS.API.Repositories
{
    public class AssessmentRepository : SqlRepository<Assessment>, IAssessmentRepository
    {
        private readonly IConfiguration _config;

        public AssessmentRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Assessment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Assessment> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentList>> GetStudentList(string GRD_ID, Int32 ACD_ID, Int32 SGR_ID, Int32 SCT_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
                parameters.Add("@SGR_ID", SGR_ID, DbType.Int32);
                parameters.Add("@SCT_ID", SCT_ID, DbType.Int32);
                return await conn.QueryAsync<StudentList>("SIMS.GetStudentList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ReportHeader>> GetReportHeaders(string GRD_ID, Int32 ACD_ID, Int32 SBG_ID, Int32 RPF_ID, Int32 RSM_ID, string prv, ReportHeaderType IsGradeBook)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@RPF_ID", RPF_ID, DbType.Int32);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);                
                parameters.Add("@RSM_ID", RSM_ID, DbType.Int32);
                if (IsGradeBook == ReportHeaderType.ReportWriting)
                {
                    parameters.Add("@SBG_ID", prv, DbType.String);
                    parameters.Add("@prev_RPF_ID", string.Empty, DbType.String);
                    return await conn.QueryAsync<ReportHeader>("SIMS.GetReportHeader_ReportWriting", parameters, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    parameters.Add("@SBG_ID", SBG_ID, DbType.String);
                    parameters.Add("@prev_RPF_ID", prv, DbType.String);
                }
                if (IsGradeBook == ReportHeaderType.GradeBook)
                    return await conn.QueryAsync<ReportHeader>("SIMS.GetReportHeaders_GradeBook", parameters, null, null, CommandType.StoredProcedure);
                return await conn.QueryAsync<ReportHeader>("SIMS.GetReportHeaders", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ReportHeaderDropDown>> GetReportHeadersDropdowns(Int32 RSM_ID, Int32 SBG_ID, Int32 RSD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSM_ID", RSM_ID, DbType.Int32);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int32);
                parameters.Add("@RSD_ID", RSD_ID, DbType.Int32);
                return await conn.QueryAsync<ReportHeaderDropDown>("SIMS.BindReportDropdown", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<AssessmentData>> GetAssessmentData(Int32 ACD_ID, Int32 SBG_ID, Int32 RPF_ID, Int32 RSM_ID, string prv)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int32);
                parameters.Add("@RPF_ID", RPF_ID, DbType.Int32);
                parameters.Add("@RSM_ID", RSM_ID, DbType.Int32);
                parameters.Add("@prev_RPF_ID", prv, DbType.String);
                return await conn.QueryAsync<AssessmentData>("SIMS.GetAssessmentData", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> InsertAssessmentData(string student_xml, string username, int bEdit)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STUDENT_XML", student_xml, DbType.String);
                parameters.Add("@USR_NAME", username, DbType.String);
                parameters.Add("@bEdit", bEdit, DbType.Int32);
                return await conn.QueryFirstAsync<int>("SIMS.InsertAssessmentData", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public override void InsertAsync(Assessment entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(Assessment entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MarkEntry>> GetAssessmentActivityList(long ACD_ID = 0, long CAM_ID = 0, string GRD_ID = "", long STM_ID = 0, long TRM_ID = 0, long SGR_ID = 0, long SBG_ID = 0, int GRADE_ACCESS = 0, string Username = "", string SuperUser = "")
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@CAM_ID", CAM_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@STM_ID", STM_ID, DbType.Int64);
                parameters.Add("@TRM_ID", TRM_ID, DbType.Int64);
                parameters.Add("@SGR_ID", SGR_ID, DbType.Int64);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                parameters.Add("@GRADE_ACCESS", GRADE_ACCESS, DbType.Int32);
                parameters.Add("@Username", Username, DbType.String);
                parameters.Add("@SuperUser", SuperUser, DbType.String);
                return await conn.QueryAsync<MarkEntry>("SIMS.GetAssessmentActivityList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<MarkEntryData>> GetMarkEntryData(long CAS_ID, double MIN_MARK, double MAX_MARK)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CAS_ID", CAS_ID, DbType.Int32);
                parameters.Add("@MIN_MARK", MIN_MARK, DbType.Decimal);
                parameters.Add("@MAX_MARK", MAX_MARK, DbType.Decimal);
                return await conn.QueryAsync<MarkEntryData>("SIMS.GetMarkEntryData", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<MarkEntryAOLData>> GetMarkEntryAOLData(long CAS_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CAS_ID", CAS_ID, DbType.Int32);
                return await conn.QueryAsync<MarkEntryAOLData>("SIMS.GetMarkEntryData_AOL", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public bool InsertMarkEntryAOLData(List<MarkEntryAOLData> lstmarkEntryAOLData, string Username, bool bWithoutSkill, long CAS_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                DataTable dt = new DataTable();
                dt.Columns.Add("STA_ID", typeof(long));
                dt.Columns.Add("STU_ID", typeof(long));
                dt.Columns.Add("STU_NO", typeof(long));
                dt.Columns.Add("STU_NAME", typeof(string));
                dt.Columns.Add("SKILL_NAME", typeof(string));
                dt.Columns.Add("SKILL_MARK", typeof(double));
                dt.Columns.Add("SKILL_GRADE", typeof(string));
                dt.Columns.Add("SKILL_MAX_MARK", typeof(double));
                dt.Columns.Add("MARKS", typeof(double));
                dt.Columns.Add("STA_GRADE", typeof(string));
                dt.Columns.Add("IS_ENABLED", typeof(string));
                dt.Columns.Add("WITHOUTSKILLS_MARKS", typeof(double));
                dt.Columns.Add("WITHOUTSKILLS_GRADE", typeof(string));
                dt.Columns.Add("WITHOUTSKILLS_MAXMARKS", typeof(double));
                dt.Columns.Add("CHAPTER", typeof(string));
                dt.Columns.Add("FEEDBACK", typeof(string));
                dt.Columns.Add("WOT", typeof(string));
                dt.Columns.Add("TARGET", typeof(string));
                dt.Columns.Add("bATTENDED", typeof(string));
                dt.Columns.Add("STU_STATUS", typeof(string));
                dt.Columns.Add("SKILL_ORDER", typeof(int));



                foreach (var item in lstmarkEntryAOLData)
                {
                    dt.Rows.Add(item.STA_ID, item.STU_ID, item.STU_NO, item.STU_NAME, item.SKILL_NAME, item.SKILL_MARK,
                        item.SKILL_GRADE, item.SKILL_MAX_MARK, item.MARKS, item.STA_GRADE, item.IS_ENABLED, item.WITHOUTSKILLS_MARKS,
                        item.WITHOUTSKILLS_GRADE, item.WITHOUTSKILLS_MAXMARKS, item.CHAPTER, item.FEEDBACK, item.WOT, item.TARGET,
                        item.bATTENDED, item.STU_STATUS, item.SKILL_ORDER
                        );
                }
                parameters.Add("@AOL_DATA", dt, DbType.Object);
                parameters.Add("@Username", Username, DbType.String);
                parameters.Add("@bWithoutSkill", bWithoutSkill, DbType.Boolean);
                parameters.Add("@CAS_ID", CAS_ID, DbType.Int64);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);


                conn.Query<int>("[SIMS].[SaveMarkEntry_AOL]", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }

        }

        public bool InsertMarkEntryData(List<MarkEntryData> lstmarkEntryData, long SlabId, string entryType, long CAS_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                DataTable dt = new DataTable();
                dt.Columns.Add("STA_ID", typeof(long));
                dt.Columns.Add("STU_ID", typeof(long));
                dt.Columns.Add("STU_NO", typeof(long));
                dt.Columns.Add("STU_NAME", typeof(string));
                dt.Columns.Add("MARKS", typeof(double));
                dt.Columns.Add("MARK_GRADE", typeof(string));
                dt.Columns.Add("MIN_MARK", typeof(double));
                dt.Columns.Add("MAX_MARK", typeof(double));
                dt.Columns.Add("IS_ENABLED", typeof(string));
                dt.Columns.Add("STU_STATUS", typeof(string));
                dt.Columns.Add("CAS_ID", typeof(long));

                foreach (var item in lstmarkEntryData)
                {
                    dt.Rows.Add(
                        item.STA_ID,
                        item.STU_ID,
                        item.STU_NO,
                        item.STU_NAME,
                        item.MARKS,
                        item.MARK_GRADE,
                        item.MIN_MARK,
                        item.MAX_MARK,
                        Convert.ToString(item.IS_ENABLED),
                        item.STU_STATUS,
                        CAS_ID
                        );
                }
                parameters.Add("@MARKENTRY_DATA", dt, DbType.Object);
                parameters.Add("@SLAB_ID", SlabId, DbType.String);
                parameters.Add("@ENTRYTYPE", entryType, DbType.String);
                parameters.Add("@CAS_ID", CAS_ID, DbType.Int64);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);


                conn.Query<int>("SIMS.SaveMarkEntry", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        public async Task<IEnumerable<AssessmentComments>> GetAssessmentComments(int CAT_ID, long STU_ID)
        {

            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CAT_ID", CAT_ID, DbType.Int32);
                parameters.Add("@STU_ID", STU_ID, DbType.Int64);
                return await conn.QueryAsync<AssessmentComments>("SIMS.GetAssessment_Comments", parameters, null, null, CommandType.StoredProcedure);

                // return await conn.QueryAsync<AssessmentComments>("SIMS.GetAssessment_Comments", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<GetHeaderBySubjectCategory>> GetHeaderBySubjectCategory(long SGRP_ID)
        {

            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@SGRP_ID", SGRP_ID, DbType.Int64);
                return await conn.QueryAsync<GetHeaderBySubjectCategory>("SIMS.GetHeaderBySubjectCategory", parameters, null, null, CommandType.StoredProcedure);

                // return await conn.QueryAsync<AssessmentComments>("SIMS.GetAssessment_Comments", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<AssessmentCategory>> GetAssessmentCategories(long CAT_BSU_ID, string CAT_GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CAT_BSU_ID", CAT_BSU_ID.ToString(), DbType.Int32);
                parameters.Add("@CAT_GRD_ID", string.IsNullOrEmpty(CAT_GRD_ID) ? "" : CAT_GRD_ID, DbType.String);
                return await conn.QueryAsync<AssessmentCategory>("SIMS.GetAssessmentCategoryForComment", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<SectionAccess>> GetSectionAccess(string USERNAME, string IsSuperUser, long ACD_ID, long BSU_ID, int GRD_ACCESS, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@USERNAME", USERNAME, DbType.String);
                parameters.Add("@IsSuperUser", IsSuperUser, DbType.String);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int32);
                parameters.Add("@GRD_ACCESS", GRD_ACCESS, DbType.Int32);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);

                return await conn.QueryAsync<SectionAccess>("SIMS.BindSectionAccess", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<HeaderOptional>> GetReportHeaderOptional(string AOD_IDs)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AOD_IDs", AOD_IDs, DbType.String);

                return await conn.QueryAsync<HeaderOptional>("SIMS.GetReportHeadersOptional", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<AssessmentDataOptional>> GetAssessmentDataOptional(long ACD_ID, long RPF_ID, long RSM_ID, long SBG_ID, long SGR_ID, string GRD_ID, long SCT_ID, string AOD_IDs)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
                parameters.Add("@RPF_ID", RPF_ID, DbType.Int32);
                parameters.Add("@RSM_ID", RSM_ID, DbType.Int32);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int32);
                parameters.Add("@SGR_ID", SGR_ID, DbType.Int32);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SCT_ID", SCT_ID, DbType.Int32);
                parameters.Add("@AOD_IDs", AOD_IDs, DbType.String);


                return await conn.QueryAsync<AssessmentDataOptional>("SIMS.GetAssessmentDataOptional", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<AssessmentPreviousSchedule>> GetAssessmentPreviousSchedule(long ACD_ID, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                return await conn.QueryAsync<AssessmentPreviousSchedule>("SIMS.GetAssessmentPreviousSchedule", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<AssessmentOptionalList>> GetAssessmentOptionList(long BSU_ID, long ACD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                return await conn.QueryAsync<AssessmentOptionalList>("SIMS.GetAssessmentOptionList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<bool> IsReportPublish(long RPP_RSM_ID, long RPP_RPF_ID, long RPP_ACD_ID, string RPP_GRD_ID, long RPP_SCT_ID, long RPP_TRM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RPP_RSM_ID", RPP_RSM_ID, DbType.Int64);
                parameters.Add("@RPP_RPF_ID", RPP_RPF_ID, DbType.Int64);
                parameters.Add("@RPP_ACD_ID", RPP_ACD_ID, DbType.Int64);
                parameters.Add("@RPP_GRD_ID", RPP_GRD_ID, DbType.String);
                parameters.Add("@RPP_SCT_ID", RPP_SCT_ID, DbType.Int64);
                parameters.Add("@RPP_TRM_ID", RPP_TRM_ID, DbType.Int64);
                return await conn.QueryFirstOrDefaultAsync<bool>("SIMS.IsReportPublish", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        #region Grade Book Setup       
        public async Task<IEnumerable<GradeBookGradeScale>> GetGradeScaleList(long BSU_ID, long ACD_ID, long TEACHER_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@TEACHER_ID", TEACHER_ID, DbType.Int64);
                return await conn.QueryAsync<GradeBookGradeScale>("SIMS.GradeBook_GetGradeScaleList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<GradeBookGradeScaleDetail>> GetGradeScaleDetailList(long GSM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GSM_ID", GSM_ID, DbType.Int64);
                return await conn.QueryAsync<GradeBookGradeScaleDetail>("SIMS.GradeBook_GetGradeScaleDetailList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveGradeScaleAndDetail(GradeBookGradeScale gradeBookGradeScale, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GSM_ID", gradeBookGradeScale.GSM_ID, DbType.Int64);
                parameters.Add("@GSM_DESCRIPTION", gradeBookGradeScale.GSM_DESCRIPTION, DbType.String);
                parameters.Add("@GSM_BSU_ID", gradeBookGradeScale.GSM_BSU_ID, DbType.Int64);
                parameters.Add("@GSM_ACD_ID", gradeBookGradeScale.GSM_ACD_ID, DbType.Int64);
                parameters.Add("@GSM_TEACHER_ID", gradeBookGradeScale.GSM_TEACHER_ID, DbType.Int64);
                parameters.Add("@IsCommon", gradeBookGradeScale.IsCommon, DbType.Boolean);
                parameters.Add("@GradeBook_ScaleDetail", gradeBookGradeScale.GradeBookGradeScaleDetailDT, DbType.Object);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.GradeBook_SaveGradeScaleAndDetail", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<int> SaveGradeBookSetup(GradeBookSetup gradeBookSetup, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GBM_ID", gradeBookSetup.GBM_ID, DbType.Int64);
                parameters.Add("@GBM_BSU_ID", gradeBookSetup.GBM_BSU_ID, DbType.Int64);
                parameters.Add("@GBM_ACD_ID", gradeBookSetup.GBM_ACD_ID, DbType.Int64);
                parameters.Add("@GBM_TRM_ID", gradeBookSetup.GBM_TRM_ID, DbType.Int64);
                parameters.Add("@GBM_GRD_ID", gradeBookSetup.GBM_GRD_ID, DbType.String);
                parameters.Add("@GBM_SBG_ID", gradeBookSetup.GBM_SBG_ID, DbType.Int64);
                parameters.Add("@GBM_SGR_ID", gradeBookSetup.GBM_SGR_ID, DbType.Int64);
                parameters.Add("@GBM_RSM_ID", gradeBookSetup.GBM_RSM_ID, DbType.Int64);
                parameters.Add("@GBM_RSD_ID", gradeBookSetup.GBM_RSD_ID, DbType.Int64);
                parameters.Add("@GBM_RPF_ID", gradeBookSetup.GBM_RPF_ID, DbType.Int64);
                parameters.Add("@GBM_SHORT_CODE", gradeBookSetup.GBM_SHORT_CODE, DbType.String);
                parameters.Add("@GBM_DESCR", gradeBookSetup.GBM_DESCR, DbType.String);
                parameters.Add("@GBM_DUE_DATE", gradeBookSetup.GBM_DUE_DATE, DbType.DateTime);
                parameters.Add("@GBM_bON_PORTAL", gradeBookSetup.GBM_bON_PORTAL, DbType.Boolean);
                parameters.Add("@GBM_PUBLISH_DATE", gradeBookSetup.GBM_PUBLISH_DATE, DbType.DateTime);
                parameters.Add("@GBM_ENTRY_MODE", gradeBookSetup.GBM_ENTRY_MODE, DbType.String);
                parameters.Add("@GBM_MARK_TYPE", gradeBookSetup.GBM_MARK_TYPE, DbType.String);
                parameters.Add("@GBM_MAX_MARK", gradeBookSetup.GBM_MAX_MARK, DbType.Double);
                parameters.Add("@GBM_MIN_MARK", gradeBookSetup.GBM_MIN_MARK, DbType.Double);
                parameters.Add("@GBM_GSM_ID", gradeBookSetup.GBM_GSM_ID, DbType.Int64);
                parameters.Add("@GBM_TEACHER_ID", gradeBookSetup.GBM_TEACHER_ID, DbType.Int64);
                parameters.Add("@GBM_CREATED_BY", gradeBookSetup.GBM_CREATED_BY, DbType.String);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.GradeBook_SaveGradeBookSetup", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<GradeBookSetup>> GetGradeBookSetupList(GradeBookSetup gradeBookSetup)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@GBM_BSU_ID", gradeBookSetup.GBM_BSU_ID, DbType.Int64);
                parameters.Add("@GBM_ACD_ID", gradeBookSetup.GBM_ACD_ID, DbType.Int64);
                parameters.Add("@GBM_TRM_ID", gradeBookSetup.GBM_TRM_ID, DbType.Int64);
                parameters.Add("@GBM_GRD_ID", gradeBookSetup.GBM_GRD_ID, DbType.String);
                parameters.Add("@GBM_SBG_ID", gradeBookSetup.GBM_SBG_ID, DbType.Int64);
                parameters.Add("@GBM_SGR_ID", gradeBookSetup.GBM_SGR_ID, DbType.Int64);
                parameters.Add("@GBM_RSM_ID", gradeBookSetup.GBM_RSM_ID, DbType.Int64);
                parameters.Add("@GBM_RPF_ID", gradeBookSetup.GBM_RPF_ID, DbType.Int64);
                parameters.Add("@GBM_RSD_ID", gradeBookSetup.GBM_RSD_ID, DbType.Int64);
                return await conn.QueryAsync<GradeBookSetup>("SIMS.GradeBook_GetGradeBookSetupList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ReportHeaderModel>> GetReportHeaderByRSMID(long RSM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSM_ID", RSM_ID, DbType.Int64);
                return await conn.QueryAsync<ReportHeaderModel>("SIMS.GetReportHeaderByRSMID", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveProcessingRuleSetup(ProcessingRuleSetup processingRuleSetup, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PRS_ID", processingRuleSetup.PRS_ID, DbType.Int64);
                parameters.Add("@PRS_RSD_ID", processingRuleSetup.PRS_RSD_ID, DbType.Int64);
                parameters.Add("@PRS_GBM_IDS", processingRuleSetup.PRS_GBM_IDS, DbType.String);
                parameters.Add("@PRS_CalculationType", processingRuleSetup.PRS_CalculationType, DbType.String);
                parameters.Add("@PRS_MODIFIED_BY", processingRuleSetup.PRS_MODIFIED_BY, DbType.String);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.GradeBook_SaveProcessingRuleSetup", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<ListItem>> GetReportHeaderDDLByRSMID(long RSM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSM_ID", RSM_ID, DbType.Int64);
                return await conn.QueryAsync<ListItem>("SIMS.GetReportSchedule", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ProcessingRuleSetup>> GetProcessingRuleSetupList(long PRS_RSD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PRS_RSD_ID", PRS_RSD_ID, DbType.Int64);
                return await conn.QueryAsync<ProcessingRuleSetup>("SIMS.GradeBook_GetProcessingRuleSetupList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<GradeBookDetail>> GetGradebookDetail(long RSD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSD_ID", RSD_ID, DbType.Int64);
                return await conn.QueryAsync<GradeBookDetail>("SIMS.Gradebook_GetGradebookDetail", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        #endregion

        public bool UpdateMarkAttendance(List<MarkAttendance> lstMarkAttendance, long CAS_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                DataTable dt = new DataTable();
                dt.Columns.Add("STA_ID", typeof(long));
                dt.Columns.Add("STU_ID", typeof(long));
                dt.Columns.Add("STU_NAME", typeof(string));
                dt.Columns.Add("bATTENDED", typeof(string));
                dt.Columns.Add("CAS_ID", typeof(long));
                dt.Columns.Add("SlabId", typeof(long));


                foreach (var item in lstMarkAttendance)
                {
                    dt.Rows.Add(
                        item.STA_ID,
                        item.STU_ID,
                        item.STU_NAME,
                        item.bATTENDED,
                        item.CAS_ID

                       );
                }
                parameters.Add("@tblMarkAttendance", dt, DbType.Object);
                parameters.Add("@CAS_ID", CAS_ID, DbType.Int64);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Query<int>("SIMS.SaveMarkAttendance", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        #region Grade Book Entry
        public async Task<int> GradebookCUD(GradeBookEntryListModel gradeBookEntry)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Gradebook_ReportStudent_S_Data", gradeBookEntry.AssessmentDatasDT, DbType.Object);
                parameters.Add("@Gradebook_Details_UDT_Data", gradeBookEntry.GradeBookDetailsDT, DbType.Object);
                parameters.Add("@UserName", gradeBookEntry.Username);
                parameters.Add("@bEdit", gradeBookEntry.bEdit);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryAsync<int>("SIMS.GradebookCUD_bck", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        #endregion

        public async Task<IEnumerable<Subjects>> GetSubjectsForReportWriting(long acdId, long studentId, string IsSuperUser, long employeeId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", acdId);
                parameters.Add("@studentId", studentId);
                parameters.Add("@employeeId", employeeId);
                parameters.Add("@IsSuperUser", IsSuperUser);
                return await conn.QueryAsync<Subjects>("SIMS.GetSubjectsForReportWriting", parameters, commandType: CommandType.StoredProcedure);
            }            
        }
        public async Task<IEnumerable<StudentReportWriting>> GetSavedRecordsOfReportWriting(long rpfId, long studentId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RPF_ID", rpfId);
                parameters.Add("@studentId", studentId);
                return await conn.QueryAsync<StudentReportWriting>("SIMS.GetSavedRecordsOfReportWriting", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<bool> ReportWritingCU(List<AssessmentData> assessmentData)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReportWritingDT", assessmentData.ToCustomDataTable(), DbType.Object);
                parameters.Add("@output", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                await conn.QueryAsync<bool>("[SIMS].[ReportWritingCU]", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<bool>("output");
            }
        }
    }
}