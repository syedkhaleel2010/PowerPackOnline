using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIMS.API.Repositories
{
    public class ProgressTrackerRepository : SqlRepository<ProgressTracker>, IProgressTrackerRepository
    {
        private readonly IConfiguration _config;

        public ProgressTrackerRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }



        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ProgressTracker>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<ProgressTracker> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        public override void InsertAsync(ProgressTracker entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(ProgressTracker entityToUpdate)
        {
            throw new NotImplementedException();
        }
        public bool HAS_AgeBand(long BSU_ID, long ACD_ID, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                return conn.QueryFirstOrDefault<bool>("SIMS.Has_AgeBand", parameters, commandType: CommandType.StoredProcedure);
                //return parameters.Get<int>("output") > 0;
            }
        }

        public bool HAS_STEPS(long BSU_ID, long ACD_ID, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.String);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                return conn.QueryFirstOrDefault<bool>("SIMS.HAS_STEPS", parameters, commandType: CommandType.StoredProcedure);
                //return parameters.Get<int>("output") > 0;
                //return conn.QueryFirstOrDefault<bool>("");
            }
        }
        public async Task<IEnumerable<BindSteps>> BindSteps(long ACD_ID, string GRD_ID, long SBG_ID, string SYD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                parameters.Add("@SYD_ID", SYD_ID, DbType.String);
                return await conn.QueryAsync<BindSteps>("SIMS.BIND_STEPS", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TopicTree>> BindTopicTree(long TRM_ID, long SBG_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TRM_ID", TRM_ID, DbType.Int64);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                return await conn.QueryAsync<TopicTree>("SIMS.BindTopicTree", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<SubTerms>> BindSubTerm(long BSU_ID, long ACD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                return await conn.QueryAsync<SubTerms>("SIMS.BindSubTerm", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ProgressTrackerHeader>> GET_PROGRESS_TRACKER_HEADERS(long SBG_ID, string TOPIC_ID, long AGE_BAND_ID, string STEPS, long TSM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                parameters.Add("@TOPIC_ID", TOPIC_ID, DbType.String);
                parameters.Add("@AGE_BAND_ID", AGE_BAND_ID, DbType.Int64);
                parameters.Add("@STEPS", STEPS, DbType.String);
                parameters.Add("@TSM_ID", TSM_ID, DbType.Int64);
                return await conn.QueryAsync<ProgressTrackerHeader>("SIMS.GET_PROGRESS_TRACKER_HEADERS", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ProgressTrackerData>> GET_PROGRESS_TRACKER_DATA(long SBG_ID, string TOPIC_ID, long TSM_ID, long SGR_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                parameters.Add("@TOPIC_ID", TOPIC_ID, DbType.String);
                parameters.Add("@TSM_ID", TSM_ID, DbType.Int64);
                parameters.Add("@SGR_ID", SGR_ID, DbType.Int64);
                return await conn.QueryAsync<ProgressTrackerData>("SIMS.GET_PROGRESS_TRACKER_DATA", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ProgressTrackerDropdown>> BindProgressTrackerDropdown(long BSU_ID, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                return await conn.QueryAsync<ProgressTrackerDropdown>("SIMS.BindProgressTrackerDropdown", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public bool SaveProgressTrackerData(int ACD_ID, string GRD_ID, int SBG_ID, XElement STC_XML, DateTime STC_UPDATEDATE, string STC_USER, int SYD_ID)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
            parameters.Add("@GRD_ID", GRD_ID, DbType.String);
            parameters.Add("@SBG_ID", SBG_ID, DbType.Int32);
            parameters.Add("@STC_XML", STC_XML.ToString(), DbType.Xml);
            parameters.Add("@STC_UPDATEDATE", STC_UPDATEDATE, DbType.DateTime);
            parameters.Add("@STC_USER", STC_USER, DbType.String);

            parameters.Add("@SYD_ID", SYD_ID, DbType.Int32);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.SaveProgressTrackerData", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        public async Task<IEnumerable<PivotGrid>> PivotGridList(int acdId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@acdId", acdId, DbType.Int32);
            using (var conn = GetOpenConnection())
            {

                return await conn.QueryAsync<PivotGrid>("SIMS.vW_RPT_PUPIL_TRACKER_ATTAINMENT", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public bool SaveProgressAssessmentSetting(long DAM_ID, string DAM_DESCR, string DAM_GRD_IDS, string DAM_BSU_ID, long DAM_ACD_ID, string DATAMODE, bool DAM_ShowCodeAsHeader, bool DAM_ShowAsDropdown, List<ProgressTrackerSettingDetails> objDescriptorData)
        {


            var parameters = new DynamicParameters();
            DataTable dt = new DataTable();
            dt.Columns.Add("DAD_ID", typeof(long));
            dt.Columns.Add("DAD_CODE", typeof(string));
            dt.Columns.Add("DAD_DESCR", typeof(string));
            dt.Columns.Add("DAD_ORDER", typeof(int));
            dt.Columns.Add("DAD_COLOR_CODE", typeof(string));
            dt.Columns.Add("DAD_VALUE", typeof(string));
            dt.Columns.Add("DAD_TYPE", typeof(string));
            dt.Columns.Add("DAD_DATAMODE", typeof(string));
            foreach (var item in objDescriptorData)
            {
                dt.Rows.Add(item.DescriptorId, item.Descriptor_Code, item.Descriptor_Descriptor, item.Descriptor_Order, item.Descriptor_Color_Code, item.Descriptor_Value, item.Descriptor_Type,
                 item.DataMode
                    );
            }

            parameters.Add("@DAM_ID", DAM_ID, DbType.Int64);
            parameters.Add("@DAM_DESCR", DAM_DESCR, DbType.String);
            parameters.Add("@DAM_GRD_IDS", DAM_GRD_IDS, DbType.String);
            parameters.Add("@DAM_BSU_ID", DAM_BSU_ID, DbType.String);
            parameters.Add("@DAM_ACD_ID", DAM_ACD_ID, DbType.Int64);
            parameters.Add("@Descriptor_Data", dt, DbType.Object);
            parameters.Add("@DATAMODE", DATAMODE, DbType.String);
            parameters.Add("@DAM_ShowCodeAsHeader", DAM_ShowCodeAsHeader, DbType.Boolean);
            parameters.Add("@DAM_ShowAsDropdown", DAM_ShowAsDropdown, DbType.Boolean);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.AttainmentDescriptorCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        public async Task<IEnumerable<ProgressTrackerSettingMaster>> GetProgressTrackerMasterSetting(string acdId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACD_ID", acdId, DbType.String);
            using (var conn = GetOpenConnection())
            {

                return await conn.QueryAsync<ProgressTrackerSettingMaster>("SIMS.GetProgressTrackerMasterSetting", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<ProgressTrackerSettingMaster> BindProgressTrackerMasterSetting(long ACD_ID, long BSU_ID, string GRD_ID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DAM_ACD_ID", ACD_ID, DbType.Int64);
            parameters.Add("@DAM_BSU_ID", BSU_ID, DbType.Int64);
            parameters.Add("@DAM_GRD_IDS", GRD_ID, DbType.String);
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<ProgressTrackerSettingMaster>("SIMS.BindProgressTrackerMasterSetting", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ProgressTrackerSettingDetails>> GetProgressTrackerDetailSetting(long DAM_ID, string DAM_TYPE)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DAM_ID", DAM_ID, DbType.Int64);
            parameters.Add("@DAM_TYPE", DAM_TYPE, DbType.String);
            using (var conn = GetOpenConnection())
            {

                return await conn.QueryAsync<ProgressTrackerSettingDetails>("SIMS.GetProgressTrackerDetailSetting", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<PTExpectationDetails>> GetPTExceptionSetting(int DAM_ID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DamId", DAM_ID, DbType.Int32);
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<PTExpectationDetails>("SIMS.GetPTExpectionSettingDetailsByDAMID", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public bool AddEditExpectationDetails(int DAM_ID, List<PTExpectationDetails> objExpectation, List<PTExpectationDetails> objDeleteExpectation)
        {
            var parameters = new DynamicParameters();
            DataTable dtAddEdit = new DataTable();
            dtAddEdit.Columns.Add("AEE_ID", typeof(int));
            dtAddEdit.Columns.Add("AEE_DAM_ID", typeof(int));
            dtAddEdit.Columns.Add("AEE_DESCR", typeof(string));
            dtAddEdit.Columns.Add("AEE_COLOR_CODE", typeof(string));
            dtAddEdit.Columns.Add("AEE_MARK_FROM", typeof(double));
            dtAddEdit.Columns.Add("AEE_MARK_TO", typeof(double));
            dtAddEdit.Columns.Add("AEE_SBG_ID", typeof(int));
            foreach (var item in objExpectation)
            {
                dtAddEdit.Rows.Add(item.Id, DAM_ID, item.Description, item.ColorCode, item.FromRange, item.ToRange, item.SubjectId);
            }


            DataTable dtDelete = new DataTable();
            dtDelete.Columns.Add("AEE_ID", typeof(int));
            dtDelete.Columns.Add("AEE_DAM_ID", typeof(int));
            dtDelete.Columns.Add("AEE_DESCR", typeof(string));
            dtDelete.Columns.Add("AEE_COLOR_CODE", typeof(string));
            dtDelete.Columns.Add("AEE_MARK_FROM", typeof(double));
            dtDelete.Columns.Add("AEE_MARK_TO", typeof(double));
            dtDelete.Columns.Add("AEE_SBG_ID", typeof(int));

            if (objDeleteExpectation != null)
            {
                foreach (var item in objDeleteExpectation)
                {
                    dtDelete.Rows.Add(item.Id, DAM_ID, item.Description, item.ColorCode, item.FromRange, item.ToRange, item.SubjectId);
                }

            }

            parameters.Add("@tblExpectaion", dtAddEdit, DbType.Object);
            parameters.Add("@tbldeleteExpectation", dtDelete, DbType.Object);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.ExpectationSettingsCURD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }

        }

        public async Task<IEnumerable<PTSubjectMaster>> BindSubjectMasterByGrade(int ACD_ID, string BSU_ID, string GRD_ID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
            parameters.Add("@BSU_ID", Convert.ToInt64(BSU_ID), DbType.Int64);
            parameters.Add("@GRD_ID", GRD_ID, DbType.String);
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<PTSubjectMaster>("SIMS.BindSubjectMasterByGrade", parameters, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
