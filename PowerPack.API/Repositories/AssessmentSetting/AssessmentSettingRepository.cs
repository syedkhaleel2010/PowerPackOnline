using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using SIMS.API.Helpers;

namespace SIMS.API.Repositories
{
    public class AssessmentSettingRepository : SqlRepository<AbsenteeSettingModel>, IAssessmentSettingRepository
    {
        private readonly IConfiguration _config;

        public AssessmentSettingRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        #region  Other Configuration Setting

        #region Dhanaji Patil
        public async Task<AbsenteeSettingModel> GetAbsenteeSetting(long BSU_ID, long ACD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                return await conn.QueryFirstOrDefaultAsync<AbsenteeSettingModel>("SIMS.OtherSettings_GetAbsenteeDetails", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveAbsenteeSetting(AbsenteeSettingModel absenteeSettingModel)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", absenteeSettingModel.BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", absenteeSettingModel.AbsenteeACD_ID, DbType.Int64);
                parameters.Add("@RAT_ID", absenteeSettingModel.AbsenteeId, DbType.Int64);
                parameters.Add("@RAT_ABSENT", absenteeSettingModel.Absent_Description, DbType.String);
                parameters.Add("@RAT_APRLEAVE", absenteeSettingModel.ApprovedLeave_Description, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.OtherSettings_SaveAbsenteeSetting", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<ReportDesignName>> GetReportDesignNameList(long BSU_ID, long ACD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                return await conn.QueryAsync<ReportDesignName>("SIMS.OtherSettings_GetDesignedReportsList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ReportDesignLink>> GetReportDesignLinkList(long BSU_ID, long ACD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSM_BSU_ID", BSU_ID, DbType.String);
                parameters.Add("@RSM_ACD_ID", ACD_ID, DbType.Int64);
                return await conn.QueryAsync<ReportDesignLink>("SIMS.OtherSettings_GetReportDesignLinkList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveReportDesignLink(ReportDesignLink reportDesignLink, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", reportDesignLink.RSM_BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", reportDesignLink.RSM_ACD_ID, DbType.Int64);
                parameters.Add("@RSM_ID", reportDesignLink.RSM_ID, DbType.Int64);
                parameters.Add("@DEV_ID", reportDesignLink.RSM_DEV_ID, DbType.Int64);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.OtherSettings_ReportDesignLinkCUD", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<RuleSetupModel>> GetReportRuleList(long ACD_ID, string GRD_ID, long STM_ID, long SBG_ID, long TRM_ID, long RRM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", string.IsNullOrEmpty(GRD_ID) ? string.Empty : GRD_ID, DbType.String);
                parameters.Add("@STM_ID", STM_ID, DbType.Int64);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                parameters.Add("@TRM_ID", TRM_ID, DbType.Int64);
                parameters.Add("@RRM_ID", RRM_ID, DbType.Int64);
                return await conn.QueryAsync<RuleSetupModel>("SIMS.OtherSettings_GetReportRuleList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveRuleSetup(RuleSetupModel ruleSetupModel)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RRM_ID", ruleSetupModel.RRM_ID, DbType.Int64);
                parameters.Add("@RSM_ID", ruleSetupModel.RSM_ID, DbType.Int64);
                parameters.Add("@SBG_IDs", ruleSetupModel.SBG_IDs, DbType.String);
                parameters.Add("@ACD_ID", ruleSetupModel.ACD_ID, DbType.Int64);
                parameters.Add("@GRD_IDs", ruleSetupModel.GRD_IDs, DbType.String);
                parameters.Add("@RRM_DESCR", ruleSetupModel.RRM_DESCR, DbType.String);
                parameters.Add("@RPF_ID", ruleSetupModel.RPF_ID, DbType.Int64);
                parameters.Add("@RSD_ID", ruleSetupModel.RSD_ID, DbType.Int64);
                parameters.Add("@TRM_ID", ruleSetupModel.TRM_ID, DbType.Int64);
                parameters.Add("@RRM_TYPE", ruleSetupModel.RRM_TYPE, DbType.String);
                parameters.Add("@GSM_SLAB_ID", ruleSetupModel.SLAB_ID, DbType.Int64);
                parameters.Add("@PASSMARK", ruleSetupModel.PASSMARK, DbType.Decimal);
                parameters.Add("@MAXMARK", ruleSetupModel.MAXMARK, DbType.Decimal);
                parameters.Add("@ENTRYTYPE", ruleSetupModel.ENTRYTYPE, DbType.String);
                parameters.Add("@GRADE_WEIGTAGE", ruleSetupModel.GRADE_WEIGTAGE, DbType.Decimal);
                parameters.Add("@ReportScheduleDT", ruleSetupModel.ReportScheduleDT, DbType.Object);
                parameters.Add("@DATAMODE", ruleSetupModel.DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.OtherSettings_SaveRuleSetup", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<int> DeleteAppliedReportRule(long RSS_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSS_ID", RSS_ID, DbType.Int64);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.OtherSettings_DeleteRule", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<AssesmentWithType>> GetAssesmentWithTypeList(long ACD_ID, long TRM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@TRM_ID", TRM_ID, DbType.Int64);
                return await conn.QueryAsync<AssesmentWithType>("SIMS.RuleSetup_GetAssesmentWithTypeList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<AssesmentWithType>> GetReportScheduleDetail(long RRM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RRM_ID", RRM_ID, DbType.Int64);
                return await conn.QueryAsync<AssesmentWithType>("SIMS.OtherSettings_GetReportScheduleDetail", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<PublishedReportModel>> GePublishedReportList(long ACD_ID, string GRD_ID, long TRM_ID, long RSM_ID, long RPF_ID, int GRADE_ACCESS, string USERNAME)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@TRM_ID", TRM_ID, DbType.Int64);
                parameters.Add("@RSM_ID", RSM_ID, DbType.Int64);
                parameters.Add("@RPF_ID", RPF_ID, DbType.Int64);
                parameters.Add("@GRADE_ACCESS", GRADE_ACCESS, DbType.Int32);
                parameters.Add("@USERNAME", USERNAME, DbType.String);
                return await conn.QueryAsync<PublishedReportModel>("SIMS.OtherSettings_BindPublishedReportList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveUnpublishedReport(UnpublishedReportData objUnpublishedReport, string userName)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", objUnpublishedReport.ACD_ID, DbType.Int64);
                parameters.Add("@TRM_ID", objUnpublishedReport.TRM_ID, DbType.Int64);
                parameters.Add("@RSM_ID", objUnpublishedReport.RSM_ID, DbType.Int64);
                parameters.Add("@RPF_ID", objUnpublishedReport.RPF_ID, DbType.Int64);
                parameters.Add("@ReportPublish_Data", objUnpublishedReport.UnpublishedReportDT, DbType.Object);
                parameters.Add("@USERNAME", userName, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.OtherSettings_SavePublishedReport", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<SubjectSpecificCriteria>> GetSubjectSpecificList(long RSM_ID, long SBG_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSM_ID", RSM_ID, DbType.Int64);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                return await conn.QueryAsync<SubjectSpecificCriteria>("SIMS.OtherSettings_SubjectSpecificHeaderList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveSubjectSpecificCriteria(SubjectSpecificCriteriaData ObjSubjectSpecificCriteria)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSM_ID", ObjSubjectSpecificCriteria.RSM_ID, DbType.Int64);
                parameters.Add("@SBG_ID", ObjSubjectSpecificCriteria.SBG_ID, DbType.Int64);
                parameters.Add("@SubjectSpecificHeader_Data", ObjSubjectSpecificCriteria.SubjectSpecificCriteriaDT, DbType.Object);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.OtherSettings_SubjectSpecificHeaderCUD", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        #endregion

        public async Task<IEnumerable<AssessmentDescriptor>> GetDefaultListById(long RDM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RDM_ID", RDM_ID, DbType.Int64);
                return await conn.QueryAsync<AssessmentDescriptor>("[SIMS].[OtherSettings_GetDefaultListById]", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public bool OtherSettings_DefaultListCUD(long RDM_ID, long BSU_ID, string DEFAULT_DESCR, string DATAMODE, List<AssessmentDescriptor> objAssessmentDescriptor)
        {

            var parameters = new DynamicParameters();

            DataTable dtt = new DataTable();
            dtt.Columns.Add("RDD_ID", typeof(long));
            dtt.Columns.Add("RDD_DESCR", typeof(string));
            dtt.Columns.Add("RDD_ORDER", typeof(int));
            dtt.Columns.Add("RDD_DATAMODE", typeof(string));

            foreach (var item in objAssessmentDescriptor)
            {
                dtt.Rows.Add(item.RDD_ID, item.RDD_DESCR, item.RDD_ORDER, item.DataMode);
            }

            parameters.Add("@RDM_ID", RDM_ID, DbType.Int64);
            parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
            parameters.Add("@DEFAULT_DESCR", DEFAULT_DESCR);
            parameters.Add("@DefaultList_Data", dtt, DbType.Object);
            parameters.Add("@DATAMODE", DATAMODE, DbType.String);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.OtherSettings_DefaultListCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }

        }

        public async Task<IEnumerable<SubjectCategoryModel>> GetSubjectCategory(long SBG_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                return await conn.QueryAsync<SubjectCategoryModel>("[SIMS].[OtherSettings_GetSubjectCategoryBySBG]", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<string> OtherSettings_SubjectCategoryCUD(SubjectCategoryModel SubjectCategoryModel)
        {
            using (var conn = GetOpenConnection())
            {
                var parameter = new DynamicParameters();

                parameter.Add("@ACD_ID", SubjectCategoryModel.ACD_ID);
                parameter.Add("@GRD_ID", SubjectCategoryModel.GRD_ID);
                parameter.Add("@SBG_ID", SubjectCategoryModel.SBG_ID);
                parameter.Add("@SubjectCategory_Data", SubjectCategoryModel.SubjectCategory_DataDT, DbType.Object);
                //parameter.Add("@DATAMODE", SubjectCategoryModel.DataMode);
                parameter.Add("@output", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
                await conn.QueryAsync("[SIMS].[OtherSettings_SubjectCategoryCUD]", parameter, null, null, CommandType.StoredProcedure);
                return parameter.Get<string>("output");
            }
        }


        public async Task<int> SaveDefaultValues(DefaultValues defaultValues)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSM_ID", defaultValues.RSM_ID);
                parameters.Add("@RSD_ID", defaultValues.RSD_ID);
                parameters.Add("@SBG_IDS", defaultValues.SBG_IDS);
                parameters.Add("@RDM_ID", defaultValues.RDM_ID);
                return await conn.ExecuteAsync("[SIMS].[OtherSettings_AssignDefaultValueCUD]", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<DefaultValues>> GetDefaultValues(long RSM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSM_ID", RSM_ID, DbType.Int64);
                return await conn.QueryAsync<DefaultValues>("SIMS.OtherSettings_GetDefaultValue", parameters, null, null, CommandType.StoredProcedure);
            }
        }


        public async Task<CourseContent> GetCourseContent(CourseContentParameter courseContentParameter)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSM_ID", courseContentParameter.RSM_ID);
                parameters.Add("@RSD_ID", courseContentParameter.RSD_ID);
                parameters.Add("@RPF_ID", courseContentParameter.RPF_ID);
                parameters.Add("@SBG_ID", courseContentParameter.SBG_ID);
                return await conn.QueryFirstOrDefaultAsync<CourseContent>("[SIMS].[OtherSettings_GetCourseContent]", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<int> SaveCourseContent(CourseContent courseContent)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", courseContent.RCP_ACD_ID);
                parameters.Add("@RSM_ID", courseContent.RCP_RSM_ID);
                parameters.Add("@RSD_ID", courseContent.RCP_RSD_ID);
                parameters.Add("@RPF_ID", courseContent.RCP_RPF_ID);
                parameters.Add("@GRD_ID", courseContent.RCP_GRD_ID);
                parameters.Add("@SBG_ID", courseContent.RCP_SBG_ID);
                parameters.Add("@RCP_DESCR", courseContent.RCP_DESCR);
                parameters.Add("@DATAMODE", courseContent.DataMode);
                return await conn.ExecuteAsync("[SIMS].[OtherSettings_CourseContentCUD]", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        #endregion

        #region Built In Function

        public override Task<IEnumerable<AbsenteeSettingModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<AbsenteeSettingModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(AbsenteeSettingModel entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(AbsenteeSettingModel entityToUpdate)
        {
            throw new NotImplementedException();
        }
        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Assessment Configuration
        public async Task<IEnumerable<AssessmentSettings>> GetAssessmentSettings(long AcdId, long schoolId, int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ACD_ID", AcdId);
                parameter.Add("@BSU_ID", schoolId);
                parameter.Add("@DivisionId", divisionId);
                return await conn.QueryAsync<AssessmentSettings>("[SIMS].[BindAssessmentSettingList]", parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<AssessmentConfig> GetAssessmentConfigs(long rsmId, long AcdId, long schoolId)
        {
            AssessmentConfig assessmentConfig = new AssessmentConfig();
            using (var conn = GetOpenConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@RSM_ID", rsmId);
                parameter.Add("@BSU_ID", schoolId);
                parameter.Add("@ACD_ID", AcdId);
                var result = await conn.QueryMultipleAsync("[SIMS].[GetAssessmentConfigById]", parameter, commandType: CommandType.StoredProcedure);
                assessmentConfig.AssessmentGrades = await result.ReadAsync<AssessmentGrade>();
                assessmentConfig.AssessmentConfigurations = await result.ReadAsync<AssessmentConfiguration>();
                assessmentConfig.ReportSchedules = await result.ReadAsync<ReportSchedule>();
                return assessmentConfig;
            }
        }

        public async Task<string> AssessmentConfigCUD(AssessmentConfig assessmentConfig)
        {
            using (var conn = GetOpenConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@BSU_ID", assessmentConfig.SchoolId);
                parameter.Add("@ACD_ID", assessmentConfig.ACD_ID);
                parameter.Add("@RSM_ID", assessmentConfig.RSM_ID);
                parameter.Add("@HEADER_NAME", assessmentConfig.Header);
                parameter.Add("@bISSUMMATIVE", assessmentConfig.IsSummative);
                parameter.Add("@DATAMODE", assessmentConfig.DataMode);
                parameter.Add("@ReportGrade_Data", assessmentConfig.AssessmentGradesDT, DbType.Object);
                parameter.Add("@ReportSchedule_Data", assessmentConfig.ReportSchedulesDT, DbType.Object);
                parameter.Add("@ReportSetupDetail_Data", assessmentConfig.AssessmentConfigurationsDT, DbType.Object);
                parameter.Add("@SubjectSpecificHeader_Data", assessmentConfig.SubjectSpecificCriteriaDT, DbType.Object);
                parameter.Add("@SBG_ID", assessmentConfig.SBG_ID);
                parameter.Add("@output", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
                await conn.QueryAsync("SIMS.AssessmentConfigCUD", parameter, null, null, CommandType.StoredProcedure);
                return parameter.Get<string>("output");
            }
        }
        #endregion

        #region Reflection Setup
        public async Task<IEnumerable<OutComeModel>> GetOutComeList(long ACD_ID, long BSU_ID, long TRM_ID, string GRD_ID, long SBG_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@TRM_ID", TRM_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                return await conn.QueryAsync<OutComeModel>("SIMS.GetOutComeList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveReflectionSetup(ReflectionSetupModel reflectionSetupModel, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RFL_ID", reflectionSetupModel.RFL_ID, DbType.Int64);
                parameters.Add("@ACD_ID", reflectionSetupModel.ACD_ID, DbType.Int64);
                parameters.Add("@BSU_ID", reflectionSetupModel.BSU_ID, DbType.Int64);
                parameters.Add("@TRM_ID", reflectionSetupModel.TRM_ID, DbType.Int64);
                parameters.Add("@GRD_ID", reflectionSetupModel.GRD_ID, DbType.String);
                parameters.Add("@SBG_ID", reflectionSetupModel.SBG_ID, DbType.Int64);
                parameters.Add("@OTC_IDS", reflectionSetupModel.OTC_IDS, DbType.String);
                parameters.Add("@RFL_DECRIPTION", reflectionSetupModel.RFL_DECRIPTION, DbType.String);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.ReflectionSetupCUD", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<ReflectionSetupModel>> GetReflectionSetupList(long ACD_ID, long BSU_ID, long TRM_ID, string GRD_ID, long SBG_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@TRM_ID", TRM_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                return await conn.QueryAsync<ReflectionSetupModel>("SIMS.GetReflectionSetupList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        #endregion

        #region Course Selection Setup
        public async Task<long> CourseSelectionPrerequisiteCu(CourseSelectionPrerequisite prerequisite)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PRQ_ID", prerequisite.PrerequisiteId);
                parameters.Add("@PRQ_ACD_ID", prerequisite.PrerequisiteAcdId);
                parameters.Add("@PRQ_GRD_ID", prerequisite.PrerequisiteGradeId);
                parameters.Add("@PRQ_SBG_ID", prerequisite.PrerequisiteSubjectId);
                parameters.Add("@PRQ_FUT_SBG_ID", prerequisite.PrerequisiteFutureSubjectId);
                parameters.Add("@PRQ_MIN_PERC", prerequisite.PrerequisiteMinimumPercent);
                parameters.Add("@IsActive", prerequisite.IsActive);
                return await conn.QueryFirstOrDefaultAsync<long>("SIMS.CourseSelectionPrerequisiteCU", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CourseSelectionPrerequisite>> GetCourseSelectionPrerequisite(long subjectId, long acdId, string grdId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SBG_ID", subjectId);
                parameters.Add("@ACD_ID", acdId);
                parameters.Add("@GRD_ID", grdId);
                return await conn.QueryAsync<CourseSelectionPrerequisite>("SIMS.GetCourseSelectionPrerequisite", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CouseSelectionValidationType>> GetValidationType()
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                return await conn.QueryAsync<CouseSelectionValidationType>("SIMS.GetCourseSelectionValidationType", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CourseSelectionDetailsCUDResponse>> CourseSelectionDetailsCUD(CourseSelectionDetailsCUD courseSelection)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", courseSelection.CSM_ACD_ID);
                parameters.Add("@GRD_ID", courseSelection.CSM_GRD_ID);
                parameters.Add("@STM_ID", courseSelection.CSM_STM_ID);
                parameters.Add("@BSU_ID", courseSelection.CSM_BSU_ID);
                parameters.Add("@CSM_ID", courseSelection.CSM_ID);
                parameters.Add("@CourseSelectionDetailsDT", courseSelection.CouserSelectionsDT, DbType.Object);
                return await conn.QueryAsync<CourseSelectionDetailsCUDResponse>("SIMS.CourseSelectionSetupCUD", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CouserSelectionSubjectCriteria>> GetSelectionSubjectCriterias(long ACD_ID, long BSU_ID, string GRD_ID, long STM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID);
                parameters.Add("@GRD_ID", GRD_ID);
                parameters.Add("@STM_ID", STM_ID);
                parameters.Add("@BSU_ID", BSU_ID);
                return await conn.QueryAsync<CouserSelectionSubjectCriteria>("SIMS.GetCourseSelectionSetupDetails", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<bool> CourseSelectionStudentSubjectsCD(List<CourseSelectedStudent> courseSelected)
        {
            using (var conn = GetOpenConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@course", courseSelected.ToCustomDataTable(), DbType.Object);
                parameter.Add("@output", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                await conn.QueryAsync("SIMS.CourseSelectionStudentSubjectsCD", parameter, null, null, CommandType.StoredProcedure);
                return parameter.Get<bool>("output");
            }
        }
        public async Task<IEnumerable<CourseSelectedStudent>> GetCourseSelectedStudents(long userId, long schoolId, long academicYearId, long nextAcademicYearId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@userid", userId);
                parameter.Add("@schooldId", schoolId);
                parameter.Add("@academicyearid", academicYearId);
                parameter.Add("@nextAcademicYear", nextAcademicYearId);
                return await conn.QueryAsync<CourseSelectedStudent>("SIMS.GetCourseSelectionStudentSubjects", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion
    }
}
