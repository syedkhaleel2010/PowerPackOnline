using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using PowerPack.Common.Enums;
using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SIMS.API.Repositories
{
    public class SubjectSettingRepository : SqlRepository<SubjectMaster>, ISubjectSettingRepository
    {
        private readonly IConfiguration _config;

        public SubjectSettingRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }


        #region Made By Dhanaji

        #region Subject Master
        public async Task<IEnumerable<SubjectMaster>> GetSubjectMasterList(int CLM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CLM_ID", CLM_ID, DbType.Int32);
                return await conn.QueryAsync<SubjectMaster>("SIMS.BindSubjectMaster", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SubjectMasterCUD(SubjectMaster subjectMaster, string mode)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SubjectId", subjectMaster.SubjectId, DbType.Int64);
                parameters.Add("@SyllabusId", subjectMaster.SyllabusId, DbType.Int64);
                parameters.Add("@Subject_Descr", subjectMaster.Subject_Description, DbType.String);
                parameters.Add("@SBM_LANG", subjectMaster.IsLanguage, DbType.Boolean);
                parameters.Add("@Subject_ShortCode", subjectMaster.Subject_ShortCode, DbType.String);
                parameters.Add("@BoardCode", subjectMaster.Subject_BoardCode, DbType.String);
                parameters.Add("@CLM_ID", subjectMaster.CurriculumId, DbType.Int64);
                parameters.Add("@DATAMODE", mode, DbType.String);

                parameters.Add("@OUTPUT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.SubjectMaster_CUD", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("OUTPUT");
            }
        }
        public async Task<IEnumerable<SubjectMaster>> GetSubjectMastersByCurriculum(long curriculumId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CLM_ID", curriculumId, DbType.Int64);
                return await conn.QueryAsync<SubjectMaster>("[SIMS].[BindSubjectsByCurriculum]", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        #endregion

        #region Subject Group
        public async Task<IEnumerable<SubjectGroup>> GetSubjectGroupList(long ACD_ID, string IsSuperUser, string Username, bool IsOptional,int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@IsSuperUser", IsSuperUser, DbType.String);
                parameters.Add("@Username", Username, DbType.String);
                parameters.Add("@IsOptional", IsOptional, DbType.Boolean);
                parameters.Add("@DivisionId", divisionId, DbType.Int32);
                return await conn.QueryAsync<SubjectGroup>("SIMS.BindSubjectGroupList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ShiftModel>> GetShiftListById(long ACD_ID, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                return await conn.QueryAsync<ShiftModel>("SIMS.BindShift", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<SubjectGroupTeacherDdl>> GetSubjectGroupTeachers(long BSU_ID, string IsSuperUser, string Username)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@IsSuperUser", IsSuperUser, DbType.String);
                parameters.Add("@Username", Username, DbType.String);
                return await conn.QueryAsync<SubjectGroupTeacherDdl>("SIMS.BindSubjectGroupTeachers", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<SubjectGroupTeacher>> GetSubjectGroupTeachersGrid(long SGR_ID, string IsSuperUser, string Username)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SGR_ID", SGR_ID, DbType.Int64);
                parameters.Add("@IsSuperUser", IsSuperUser, DbType.String);
                parameters.Add("@Username", Username, DbType.String);
                return await conn.QueryAsync<SubjectGroupTeacher>("SIMS.BindSubjectGroupTeachers_Grid", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveUpdateSubjectGroup(SubjectGroup subjectGroup, string mode)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SGR_ID", subjectGroup.GroupId, DbType.Int64);
                parameters.Add("@BSU_ID", subjectGroup.SchoolId, DbType.Int64);
                parameters.Add("@ACD_ID", subjectGroup.ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", subjectGroup.GradeId, DbType.String);
                parameters.Add("@GRD_DISPLAY", subjectGroup.Grade_Display, DbType.String);
                parameters.Add("@SHF_ID", subjectGroup.ShiftId, DbType.Int32);
                parameters.Add("@SHF_DESCR", subjectGroup.Shift_Description, DbType.String);
                parameters.Add("@STM_ID", subjectGroup.StreamId, DbType.Int32);
                parameters.Add("@STM_DESCR", subjectGroup.Stream_Description, DbType.String);
                parameters.Add("@SBG_ID", subjectGroup.SubjectGradeId, DbType.Int64);
                parameters.Add("@SGR_DESCR", subjectGroup.Group_Description, DbType.String);
                parameters.Add("@SGR_UNTIS_GRP", string.Empty, DbType.String);
                parameters.Add("@DATAMODE", mode, DbType.String);
                var result = await conn.QueryFirstOrDefaultAsync<int>("SIMS.SubjectGroupCUD", parameters, null, null, CommandType.StoredProcedure);
                int teacherResult;
                if (result > 0)
                {
                    if (subjectGroup.GroupId == 0)
                        subjectGroup.GroupId = result;
                    if (!string.IsNullOrEmpty(subjectGroup.SelectedStudentListXML))
                    {
                        await SubjectGroupStudentAssign(subjectGroup, subjectGroup.SchoolId, "ADD");
                    }
                    if (!string.IsNullOrEmpty(subjectGroup.RemovedStudentListXML))
                    {
                        await SubjectGroupStudentAssign(subjectGroup, subjectGroup.SchoolId, "DELETE");
                    }

                    if (subjectGroup.SubjectGroupTeacher.TeacherId > 0)
                        teacherResult = await SaveUpdateGroupTeacher(subjectGroup, subjectGroup.Username, subjectGroup.SubjectGroupTeacher.GroupTeacherId > 0 ? "UPDATE" : "ADD");
                }
                if (result > 0)
                    return 1;
                else
                    return 0;

            }
        }
        public async Task SubjectGroupStudentAssign(SubjectGroup subjectGroup, long SchoolId, string mode)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", Convert.ToInt32(subjectGroup.ACD_ID), DbType.Int32);
                parameters.Add("@GRD_ID", subjectGroup.GradeId, DbType.String);
                parameters.Add("@SCT_ID", subjectGroup.SectionId, DbType.Int32);
                parameters.Add("@SGR_ID", subjectGroup.GroupId, DbType.Int32);
                parameters.Add("@SBG_ID", subjectGroup.SubjectGradeId, DbType.Int32);

                parameters.Add("@START_DATE", subjectGroup.StartDate, DbType.DateTime);
                parameters.Add("@END_DATE", subjectGroup.EndDate, DbType.DateTime);

                parameters.Add("@STU_DATA", mode == "ADD" ? subjectGroup.SelectedStudentListXML : subjectGroup.RemovedStudentListXML, DbType.Xml);
                parameters.Add("@DATAMODE", mode, DbType.String);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.SubjectGroupStudentAssign", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveUpdateGroupTeacher(SubjectGroup subjectGroupTeacher, string UserName, string mode)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SGS_ID", subjectGroupTeacher.SubjectGroupTeacher.GroupTeacherId, DbType.Int64);
                parameters.Add("@SGS_SGR_ID", subjectGroupTeacher.GroupId, DbType.Int64);
                parameters.Add("@SGS_EMP_ID", subjectGroupTeacher.SubjectGroupTeacher.TeacherId, DbType.Int64);
                parameters.Add("@SGS_FROMDATE", subjectGroupTeacher.SubjectGroupTeacher.FromDate, DbType.DateTime);
                parameters.Add("@SGS_SCHEDULE", string.IsNullOrEmpty(subjectGroupTeacher.SubjectGroupTeacher.GroupTeacherSchedule) ? "" : subjectGroupTeacher.SubjectGroupTeacher.GroupTeacherSchedule, DbType.String);
                parameters.Add("@SGS_ROOMNO", string.IsNullOrEmpty(subjectGroupTeacher.SubjectGroupTeacher.GroupTeacherRoom) ? "" : subjectGroupTeacher.SubjectGroupTeacher.GroupTeacherRoom, DbType.String);
                parameters.Add("@USERNAME", UserName, DbType.String);
                parameters.Add("@DATAMODE", mode, DbType.String);
                parameters.Add("@OUTPUT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.GroupTeacherCUD", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("OUTPUT");
            }
        }
        public async Task<IEnumerable<SubjectGroupStudent>> GetSubjectGroupStudentList(long ACD_ID, string GRD_ID, int SHF_ID, int STM_ID, long SBG_ID, long SGR_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SHF_ID", SHF_ID, DbType.Int32);
                parameters.Add("@STM_ID", STM_ID, DbType.Int32);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                parameters.Add("@SGR_ID", SGR_ID, DbType.Int64);
                return await conn.QueryAsync<SubjectGroupStudent>("SIMS.BindSubjectGroupStudent_Grid", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        #endregion

        #region Change Group
        public async Task<IEnumerable<SubjectGroupDdl>> GetSubjectGroupDdl(long ACD_ID, string GRD_ID, int SHF_ID, int STM_ID, long SBG_ID, long EMP_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SHF_ID", SHF_ID, DbType.Int32);
                parameters.Add("@STM_ID", STM_ID, DbType.Int32);
                parameters.Add("@SBG_ID", SBG_ID, DbType.Int64);
                parameters.Add("@EMP_ID", EMP_ID, DbType.Int64);
                return await conn.QueryAsync<SubjectGroupDdl>("SIMS.BindGroups_ChangeGroup", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<BindMandatorySubject>> BindMandatorySubject(long ACD_ID, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                return await conn.QueryAsync<BindMandatorySubject>("SIMS.BindMandatorySubject", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<BindOptionalSubject>> BindOptionalSubject(long ACD_ID, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                return await conn.QueryAsync<BindOptionalSubject>("SIMS.BindOptionalSubject", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveChangeGroupData(DataTable dt)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ChangeGroup_Data", dt, DbType.Object);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.SaveStudentGroup_ChangeGroup", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<SelectedOptionByStudent>> GetSelectedOptionListByStudent(long ACD_ID, long STU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@STU_ID", STU_ID, DbType.Int64);
                return await conn.QueryAsync<SelectedOptionByStudent>("SIMS.GetAllocatedGroupsByStudentId", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> ChangeSelectedStudentGroup(ChangeSelectedStudentGroup changeSelectedStudentGroup)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SGR_ID_NEW", changeSelectedStudentGroup.MoveToGroupId, DbType.Int64);
                parameters.Add("@SSD_IDS", changeSelectedStudentGroup.StudentGroupIds, DbType.Xml);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.SaveStudent_ChangeGroup", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        #endregion

        #region Upload Objective
        public async Task<int> BulkUploadObjective(UploadObjectiveModel uploadObjectiveModel, DataTable dt)
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
                parameters.Add("@Objectives_Data", dt, DbType.Object);
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
                parameters.Add("@Topic_Description", topicDetail.Topic_Description, DbType.String);
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

        public override Task<IEnumerable<SubjectMaster>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<SubjectMaster> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(SubjectMaster entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(SubjectMaster entityToUpdate)
        {
            throw new NotImplementedException();
        }
        #endregion

        public async Task<IEnumerable<SubjectByGradeParent>> BindGradesForSubject(long ACD_ID,int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@DivisionId", divisionId, DbType.Int32);
                return await conn.QueryAsync<SubjectByGradeParent>("SIMS.BindGradesForSubject", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<SubjectByGradeChild>> BindSubjectsByGrade(long ACD_ID, string GRD_ID, int STM_ID, int SBG_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@STM_ID", STM_ID, DbType.Int32);
                parameters.Add("@SBG_ID", Convert.ToInt64(SBG_ID), DbType.Int64);
                return await conn.QueryAsync<SubjectByGradeChild>("SIMS.BindSubjectsByGrade", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ParentSubject>> GetParentSubjects(long ACD_ID, int STM_ID, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@STM_ID", STM_ID, DbType.Int32);
                return await conn.QueryAsync<ParentSubject>("SIMS.BindParentSubject", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<SubjectByGradeParent>> GetGradeForSubjectCopy(long ACD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                return await conn.QueryAsync<SubjectByGradeParent>("SIMS.BindGradeForSubjectCopy", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<FromStream>> GetStreamForSubjectCopy(long ACD_ID, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                return await conn.QueryAsync<FromStream>("SIMS.BindStreamForSubjectCopy", parameters, null, null, CommandType.StoredProcedure);
            }
        }



        public async Task<int> AddOptionName(long schoolId, string optionName)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", schoolId, DbType.Int64);
                parameters.Add("@Description", optionName, DbType.String);
                return await conn.ExecuteAsync("SIMS.InsertSubjectOptions", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<string> SubjectGrade(DataTable dt, string mode)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DATAMODE", mode, DbType.String);
                parameters.Add("@SubjectGrade_Data", dt, DbType.Object);
                parameters.Add("@Output", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                await conn.QueryAsync<string>("SIMS.SubjectGradeCUD", parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<string>("Output");
            }
        }
    }
}
