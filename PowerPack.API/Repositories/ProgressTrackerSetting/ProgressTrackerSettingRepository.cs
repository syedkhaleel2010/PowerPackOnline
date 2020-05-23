using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Repositories
{
    public class ProgressTrackerSettingRepository : SqlRepository<UploadObjectiveModel>, IProgressTrackerSettingRepository
    {
        private readonly IConfiguration _config;

        public ProgressTrackerSettingRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        #region Made By Dhanaji
        #region Upload Objective
        public async Task<int> BulkUploadObjective(UploadObjectiveModel uploadObjectiveModel)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", uploadObjectiveModel.ACD_ID, DbType.Int64);
                parameters.Add("@BSU_ID", uploadObjectiveModel.BSU_ID, DbType.Int64);
                parameters.Add("@TRM_ID", uploadObjectiveModel.TRM_ID, DbType.Int64);
                parameters.Add("@GRD_ID", uploadObjectiveModel.GRD_ID, DbType.String);
                parameters.Add("@SBG_ID", uploadObjectiveModel.SBG_ID, DbType.Int64);
                parameters.Add("@AGEBAND_ID", uploadObjectiveModel.AGEBAND_ID, DbType.Int32);
                parameters.Add("@Objectives_Data", uploadObjectiveModel.ObjectiveExcelDT, DbType.Object);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.BulkUploadObjectives", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<TopicDetail>> GetTopicDetailList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID, long SYD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@TRM_ID", TRM_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                parameters.Add("@SYD_ID", SYD_ID, DbType.Int64);
                return await conn.QueryAsync<TopicDetail>("SIMS.BindTopicAndSubTopicList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<TopicObjective>> GetTopicObjectiveList(long SYD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SYD_ID", SYD_ID, DbType.Int64);
                return await conn.QueryAsync<TopicObjective>("SIMS.GetObjectivesByTopicId", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<TopicParent>> GetTopicParentList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@TRM_ID", TRM_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                return await conn.QueryAsync<TopicParent>("SIMS.BindTopicParentList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> AddEditTopicDetails(TopicDetail topicDetail, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SYD_ID", topicDetail.SYD_ID, DbType.Int64);
                parameters.Add("@ACD_ID", topicDetail.ACD_ID, DbType.Int64);
                parameters.Add("@BSU_ID", topicDetail.SchoolId, DbType.Int64);
                parameters.Add("@GRD_ID", topicDetail.GradeId, DbType.String);
                parameters.Add("@SBG_ID", topicDetail.SubjectId, DbType.Int64);
                parameters.Add("@TRM_ID", topicDetail.TermId, DbType.Int64);
                parameters.Add("@SYM_ID", topicDetail.Syllabus_ID, DbType.Int64);
                parameters.Add("@Topic_ParentId", topicDetail.ParentID, DbType.Int64);
                parameters.Add("@Topic_Description", topicDetail.Topic_Name, DbType.String);
                parameters.Add("@Topic_StartDate", topicDetail.Topic_Start_Date, DbType.DateTime);
                parameters.Add("@Topic_EndDate", topicDetail.Topic_End_Date, DbType.DateTime);
                parameters.Add("@Topic_Lesson", topicDetail.Topic_Hours, DbType.Int64);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.ProgressTrackerTopicsCUD", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<int> AddEditTopicObjective(TopicObjective topicObjective, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OBJ_ID", topicObjective.ObjectiveId, DbType.Int64);
                parameters.Add("@ACD_ID", topicObjective.ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", topicObjective.GradeId, DbType.String);
                parameters.Add("@SBG_ID", topicObjective.SubjectGradeId, DbType.Int64);
                parameters.Add("@SYD_ID", topicObjective.SYD_ID, DbType.Int64);
                parameters.Add("@OBJ_DESC", topicObjective.Objective_Description, DbType.String);
                parameters.Add("@OBJ_START_DATE", topicObjective.Objective_Start_Date, DbType.DateTime);
                parameters.Add("@OBJ_END_DATE", topicObjective.Objective_End_Date, DbType.DateTime);
                parameters.Add("@OBJ_LESSON", topicObjective.Objective_Lesson, DbType.Int32);
                parameters.Add("@OBJ_AGEBAND", topicObjective.AgeBand, DbType.Int64);
                parameters.Add("@OBJ_STEP", topicObjective.Objective_Step, DbType.String);
                parameters.Add("@SYC_CODE", topicObjective.Objective_Code, DbType.String);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.ProgressTrackerObjectiveCUD", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        #endregion
        #endregion

        #region Built In functions
        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<UploadObjectiveModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<UploadObjectiveModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(UploadObjectiveModel entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(UploadObjectiveModel entityToUpdate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
