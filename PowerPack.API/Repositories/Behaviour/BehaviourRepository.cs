using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SIMS.API.Helpers;

namespace SIMS.API.Repositories
{
    public class BehaviourRepository : SqlRepository<Behaviour>, IBehaviourRepository
    {
        private readonly IConfiguration _config;

        public BehaviourRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Behaviour>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Behaviour> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClassList>> GetStudentList(string username, int tt_id = 0, string grade = null, string section = null)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@USER_NAME", username, DbType.String);
                parameters.Add("@TTM_ID", tt_id, DbType.Int32);
                parameters.Add("@GRD_ID", grade, DbType.String);
                parameters.Add("@SCT_ID", section, DbType.String);
                return await conn.QueryAsync<ClassList>("SIMS.GETCLASSLIST", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Behaviour>> LoadBehaviourByStudentId(string stu_id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", stu_id, DbType.String);
                return await conn.QueryAsync<Behaviour>("SIMS.LoadBehaviourByStudentId", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<BehaviourDetails>> GetBehaviourById(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", id, DbType.Int32);
                return await conn.QueryAsync<BehaviourDetails>("SIMS.GetBehaviourByid", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<BehaviourDetails>> InsertBehaviourDetails(BehaviourDetails entity,string bsu_id,string mode = "ADD")
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Behaviour_ID", (mode=="ADD"? 0 :entity.Behaviour_ID), DbType.Int32);
                parameters.Add("@Category_ID", entity.Category_ID, DbType.Int32);
                parameters.Add("@SubCategory_ID", entity.SubCategory_ID, DbType.Int32);
                parameters.Add("@Points", entity.Points, DbType.Int32);
                parameters.Add("@Activity_ID", entity.Activity_ID, DbType.Int32);
                parameters.Add("@Location_ID", entity.Location_ID, DbType.Int32);
                parameters.Add("@Incident_Date", entity.Incident_Date.Value, DbType.DateTime);
                parameters.Add("@Incident_Time", entity.Incident_Time, DbType.String);
                parameters.Add("@Period", entity.Period, DbType.String);
                parameters.Add("@Comments", entity.Comments, DbType.String);
                parameters.Add("@Recorded_Date", entity.Recorded_Date.Value, DbType.DateTime);
                parameters.Add("@Status_ID", entity.Status_ID, DbType.Int32);
                parameters.Add("@Recorded_By", entity.Recorded_By, DbType.String);
                parameters.Add("@DocPath", entity.DocPath, DbType.String);
                parameters.Add("@OtherStaff_ID", entity.OtherStaff_ID, DbType.Int32);
                parameters.Add("@Followup_Date", entity.Followup_Date.Value, DbType.DateTime);
                parameters.Add("@ReferredTo", entity.ReferredTo, DbType.String);
                parameters.Add("@FollowupComments", entity.FollowupComments, DbType.String);
                parameters.Add("@BSU_ID", bsu_id, DbType.String);

                return await conn.QueryAsync<BehaviourDetails>("SIMS.InsertBehaviourDetails", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public override void InsertAsync(Behaviour entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(Behaviour entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentBehaviour>> GetListOfStudentBehaviour()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<StudentBehaviour>("SIMS.GetListOfStudentBehaviourType", null, null, null, CommandType.StoredProcedure);
            }
        }

        public bool InsertUpdateStudentBehavior(List<StudentBehaviourFiles> studentBehaviourFiles,long studentId = 0, int behaviorId = 0, string behaviourComment = "")
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("StudentId", typeof(long));
            dt.Columns.Add("BehaviourId", typeof(int));
            dt.Columns.Add("FileName", typeof(string));
            dt.Columns.Add("UploadedFilePath", typeof(string));
            foreach (var item in studentBehaviourFiles)
            {
                dt.Rows.Add(item.StudentId,item.BehaviourId,item.FileName, item.UploadedFilePath);
            }
            var parameters = new DynamicParameters();
            parameters.Add("@StudentId", studentId, DbType.Int32);
            parameters.Add("@BehaviorId", behaviorId, DbType.Int32);
            parameters.Add("@behaviourComment", behaviourComment, DbType.String);
            parameters.Add("@studentbehaviourfiles", dt, DbType.Object);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.InsertUpdateStudentBehaviorMapping", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        public async Task<IEnumerable<StudentBehaviour>> GetStudentBehaviorByStudentId(long studentId = 0)
        {
            using(var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@studentId", studentId, DbType.Int64);
                return await conn.QueryAsync<StudentBehaviour>("SIMS.GetStudentBehaviorByStudentId", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public bool InsertBulkStudentBehaviour(List<StudentBehaviourFiles> studentBehaviourFiles,string bulkStudentds = "", int behaviourId=0, string behaviourComment = "")
        {
            var parameters = new DynamicParameters();
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentId", typeof(long));
            dt.Columns.Add("BehaviourId", typeof(int));
            dt.Columns.Add("FileName", typeof(string));
            dt.Columns.Add("UploadedFilePath", typeof(string));
            foreach (var item in studentBehaviourFiles)
            {
                dt.Rows.Add(item.StudentId, item.BehaviourId, item.FileName, item.UploadedFilePath);
            }
            parameters.Add("@bulkStudentds", bulkStudentds, DbType.String);
            parameters.Add("@behaviourId", behaviourId, DbType.Int32);
            parameters.Add("@behaviourComment", behaviourComment, DbType.String);
            parameters.Add("@studentbehaviourfiles", dt, DbType.Object);
           
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.InsertBulkStudentBehaviour", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        public bool UpdateBehaviourTypes(int behaviourId = 0, string behaviourType = "", int behaviourPoint = 0, int categoryId = 0)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@behaviourId", behaviourId, DbType.Int32);
            parameters.Add("@strBehaviourType", behaviourType, DbType.String);
            parameters.Add("@behaviourPoint", behaviourPoint, DbType.Int32);
            parameters.Add("@categoryId", categoryId, DbType.Int32);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.AddEditBehaviourtypeList", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        public async Task<IEnumerable<StudentBehaviourMerit>> GetFileDetailsByStudentId(long studentId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@studentId", studentId, DbType.Int64);
                return await conn.QueryAsync<StudentBehaviourMerit>("SIMS.GetFileDetailsByStudentId", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<StudentMeritList>> GetBehaviourClassList(string username, int tt_id = 0, string grade = null, string section = null)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@USER_NAME", username, DbType.String);
                parameters.Add("@TTM_ID", tt_id, DbType.Int32);
                parameters.Add("@GRD_ID", grade, DbType.String);
                parameters.Add("@SCT_ID", section, DbType.String);
                return await conn.QueryAsync<StudentMeritList>("SIMS.GetBehaviourClassList", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public bool DeleteStudentBehaviourMapping(long studentId = 0, int behaviourId = 0)
        {
          
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@studentId", studentId, DbType.Int64);
                parameters.Add("@BehaviourId", behaviourId, DbType.Int64);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Query<int>("SIMS.DeleteStudentBehaviourMapping", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }


        public async Task<IEnumerable<SubCategories>> GetSubCategoriesByCategoryId(long categoryId, string BSU_ID, string GRD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@categoryId", categoryId, DbType.Int64);
                parameters.Add("@BSU_ID", Convert.ToInt64(BSU_ID), DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);

                return await conn.QueryAsync<SubCategories>("SIMS.GetSubCategoriesByCategoryId", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<StudentBehaviourMerit>> GetMeritDetails(int acdId, string schoolId, long studentId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@acdId", acdId, DbType.Int32);
                parameters.Add("@schoolId", schoolId, DbType.String);
                parameters.Add("@studentId", studentId, DbType.Int64);

                return await conn.QueryAsync<StudentBehaviourMerit>("SIMS.GetMeritDetails", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<SubCategories>> GetMeritCategoryByStudent(int acdId, string schoolId, long studentId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@acdId", acdId, DbType.Int32);
                parameters.Add("@schoolId", schoolId, DbType.String);
                parameters.Add("@studentId", studentId, DbType.Int64);

                return await conn.QueryAsync<SubCategories>("SIMS.GetMeritCategoryByStudent", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public bool InsertMeritDemerit(string schoolId, int academicId, StudentBehaviourMerit objBehaviourMerit, List<CategoryDetails> objCategories)
        {
            string[] split = objBehaviourMerit.StudentIds[1].Split(',');

            var parameters = new DynamicParameters();
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentId", typeof(long));
            dt.Columns.Add("CategoryId", typeof(int));
            dt.Columns.Add("SubCategoryId", typeof(int));
            dt.Columns.Add("LevelMappingId", typeof(long));
           
            foreach(var studentId in split)
            {
                foreach (var item in objCategories)
                {
                    dt.Rows.Add(Convert.ToInt64(studentId), item.CategoryId, item.SubcategoryId,item.LevelMappingId);
                }
            }
           
            parameters.Add("@schoolId", schoolId, DbType.String);
            parameters.Add("@acdId", academicId, DbType.Int32);
            parameters.Add("@MeritId", objBehaviourMerit.MeritId, DbType.Int64);
            parameters.Add("@MeritType", objBehaviourMerit.MeritType, DbType.String);
            parameters.Add("@MeritFileName", objBehaviourMerit.MeritUpload, DbType.String);
            parameters.Add("@MeritUploadId", objBehaviourMerit.MeritUploaded, DbType.Int64);
            parameters.Add("@MeritRemark", objBehaviourMerit.MeritRemarks, DbType.String);
            parameters.Add("@tblCategory", dt, DbType.Object);
            parameters.Add("@StudentId", objBehaviourMerit.StudentId, DbType.Int64);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.MeritDemeritCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }


        }


        #region Incident
        public async Task<IEnumerable<IncidentListModel>> GetIncidentList(long schoolId, long academicYearId, int month, long IncidentId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", schoolId, DbType.Int64);
                parameters.Add("@ACD_ID", academicYearId, DbType.Int64);
                parameters.Add("@MONTH_NUMBER", month, DbType.Int32);
                parameters.Add("@BM_ID", IncidentId, DbType.Int64);
                return await conn.QueryAsync<IncidentListModel>("SIMS.BindIncidentList", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<IncidentStudentList>> GetIncidentStudentList(long IncidentId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IncidentId", IncidentId, DbType.Int64);
                return await conn.QueryAsync<IncidentStudentList>("SIMS.GetInvolvedStudentsById", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<IncidentWitness>> GetIncidentWitnesses(long IncidentId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BM_ID", IncidentId, DbType.Int64);
                return await conn.QueryAsync<IncidentWitness>("SIMS.GetIncidentWitnessById", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ChartModel>> GetIncidentChartByCategory(long schoolId, long academicYearId, int month, bool isCategory)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", schoolId, DbType.Int64);
                parameters.Add("@ACD_ID", academicYearId, DbType.Int64);
                parameters.Add("@MONTH_NUMBER", month, DbType.Int32);
                if(isCategory)
                    return await conn.QueryAsync<ChartModel>("SIMS.IncidentChartByCategory", parameters, null, null, CommandType.StoredProcedure);
                else
                    return await conn.QueryAsync<ChartModel>("SIMS.IncidentChartByGrade", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<IncidentStaffList>> GetIncidentStaffLists(long schoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", schoolId, DbType.Int64);
                return await conn.QueryAsync<IncidentStaffList>("SIMS.GetIncidentStaffList", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<string> IncidentEntryCUD(IncidentEntry incidentEntry)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BMID", incidentEntry.BehaviourId, DbType.Int32);
                parameters.Add("@BSU_ID", incidentEntry.SchoolId, DbType.Int32);
                parameters.Add("@ENTRY_DATE", incidentEntry.EntryDate, DbType.DateTime);
                parameters.Add("@INCIDENT_DATE", incidentEntry.IncidentDate, DbType.DateTime);
                parameters.Add("@INCIDENT_TIME", incidentEntry.IncidentTime,DbType.String);
                parameters.Add("@INCIDENT_TYPE", incidentEntry.IncidentType.ToString(), DbType.String);
                parameters.Add("@STAFF_ID", incidentEntry.StaffId, DbType.Int64);
                parameters.Add("@INCIDENT_DESC", incidentEntry.IncidentDesc,DbType.String);
                parameters.Add("@DATAMODE", incidentEntry.DataMode,DbType.String);
                parameters.Add("@CATEGORYID", incidentEntry.CategoryId,DbType.Int32);
                parameters.Add("@WITNESS_DATA", incidentEntry.WitnessDT, DbType.Object);
                parameters.Add("@INVOLVED_DATA", incidentEntry.StudentInvolvedDT, DbType.Object);
                parameters.Add("@LevelMapping_ID", incidentEntry.LevelMapping_ID, DbType.Int64);
                parameters.Add("@Output", dbType: DbType.String, size: int.MaxValue, direction: ParameterDirection.Output);
                await conn.QueryAsync<string>("SIMS.IncidentEntryCUD", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<string>("Output");
            }
        }
        #region IncidentAction
        public async Task<BehaviourAction> GetBehaviourAction(long incidentId, long studentId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BM_ID", incidentId, DbType.Int64);
                parameters.Add("@STU_ID", studentId, DbType.Int64);
                return await conn.QueryFirstOrDefaultAsync<BehaviourAction>("SIMS.GetStudentIncidentAction", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<BehaviourActionFollowup>> GetBehaviourActionFollowups(long incidentId, long actionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BM_ID", incidentId, DbType.Int64);
                parameters.Add("@ACTION_ID", actionId, DbType.Int64);
                return await conn.QueryAsync<BehaviourActionFollowup>("SIMS.GetActionFollowupDetails", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<FollowUpDesignation>> GetFollowUpDesignations(long schoolId, long incidentId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", schoolId, DbType.Int64);
                parameters.Add("@BM_ID", incidentId, DbType.Int64);
                return await conn.QueryAsync<FollowUpDesignation>("SIMS.BindFollowupDesignation", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<FollowUpStaff>> GetFollowUpStaffs(long schoolId, long designationId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", schoolId, DbType.Int64);
                parameters.Add("@DES_ID", designationId, DbType.Int64);
                return await conn.QueryAsync<FollowUpStaff>("SIMS.BindFollowupStaffList", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        private string GetYesNo(bool isTrue) => isTrue ? "Yes" : "No";

        public async Task<int> ActionCUD(BehaviourAction behaviourAction)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACTION_ID", behaviourAction.ActionId);
                parameters.Add("@BM_ID", behaviourAction.IncidentId);
                parameters.Add("@STU_ID", behaviourAction.StudentId);
                parameters.Add("@CATEGORYID", behaviourAction.CategoryId);
                parameters.Add("@PARENT_CALLED", GetYesNo(behaviourAction.ParentCalled));
                parameters.Add("@PARENT_SAID", behaviourAction.ParentCalledComment);
                parameters.Add("@PARENT_CALLDATE", behaviourAction.ParentCalledDate);
                parameters.Add("@PARENT_INTERVIED", GetYesNo(behaviourAction.ParentInterviewed));
                parameters.Add("@PARENT_INTVSAID", behaviourAction.ParentInterviewedComment);
                parameters.Add("@PARENT_INTERVDATE", behaviourAction.ParentInterviewedDate);
                parameters.Add("@NOTES_STUPLANNER", GetYesNo(behaviourAction.NotesInStudentPlanner));
                parameters.Add("@NOTES_STUPLANDATE", behaviourAction.NotesInStudentPlannerDate);
                parameters.Add("@BREAK_DETENTION", GetYesNo(behaviourAction.BreakDetentionGiven));
                parameters.Add("@BREAK_DETENTION_DATE", behaviourAction.BreakDetentionGivenDate);
                parameters.Add("@AFTER_SCH_DETN", GetYesNo(behaviourAction.AfterSchoolDetentionGiven));
                parameters.Add("@AFTER_SCH_DETNDATE", behaviourAction.AfterSchoolDetentionGivenDate);
                parameters.Add("@SUSPENSION", GetYesNo(behaviourAction.Suspension));
                parameters.Add("@SUSPENSION_DATE", behaviourAction.SuspensionDate);
                parameters.Add("@STU_COUNSELLOR", GetYesNo(behaviourAction.ReferredToStudentsCounsellor));
                parameters.Add("@STU_COUNSELLOR_DATE", behaviourAction.ReferredToStudentsCounsellorDate);
                parameters.Add("@ENTRY_DATE", behaviourAction.Entry_Date);
                parameters.Add("@SCORE", behaviourAction.Score);
                parameters.Add("@DATAMODE", behaviourAction.DataMode);
                return await conn.ExecuteAsync("SIMS.SaveActionCUD", parameters, null, null, CommandType.StoredProcedure);
                
            }
        }

        public async Task<int> ActionFollowUpCUD(BehaviourActionFollowup behaviourActionFollowup)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACTION_DETAIL_ID", behaviourActionFollowup.ActionDetailsId);
                parameters.Add("@INCIDENT_ID", behaviourActionFollowup.IncidentId);
                parameters.Add("@ACTION_ID", behaviourActionFollowup.ActionId);
                parameters.Add("@ACTION_DATE", behaviourActionFollowup.ActionDate);
                parameters.Add("@STAFF_ID", behaviourActionFollowup.Action_CurrentUser_DesignationId);
                parameters.Add("@ACTION_DESCR", behaviourActionFollowup.Action_Followup_Remarks);
                parameters.Add("@ACTION_COMMENTS", behaviourActionFollowup.Action_Followup_Remarks);
                parameters.Add("@ACTION_FORWARD_TO", behaviourActionFollowup.Action_FollowupBy_Id);
                parameters.Add("@ACTION_FORWARD_DATE", DateTime.Now);
                parameters.Add("@DESIGNATION_ID", behaviourActionFollowup.Action_FollowupBy_Designation_Id);
                parameters.Add("@DATAMODE", behaviourActionFollowup.DataMode);
                return await conn.ExecuteAsync("SIMS.ActionDetailsCUD", parameters, null, null, CommandType.StoredProcedure);

            }
        }







        #endregion

        #endregion

        #region Student Point Category
        public async Task<IEnumerable<StudentPointCategory>> GetStudentPointCategory(long schoolId, long academicYearId, int scheduleType)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", schoolId, DbType.Int64);
                parameters.Add("@ACD_ID", academicYearId, DbType.Int64);
                parameters.Add("@SCHEDULE_TYPE", scheduleType, DbType.Int32);
                var result = await conn.QueryMultipleAsync("SIMS.CRB_GetStudentPointsCategory", parameters, null, null, CommandType.StoredProcedure);

                var studentPointCategory = await result.ReadAsync<StudentPointCategory>();
                var certificates = await result.ReadAsync<CertificateProcessLog>();
                var studentPoints = new List<StudentPointCategory>();
                studentPoints = studentPointCategory.AsList();
                studentPoints.ForEach(x =>
                {
                    x.Certificates = certificates.AsList().FindAll(y => y.StudentId == x.Student_ID);
                });
                return studentPoints;
            }
        }
        public async Task<int> CertificateProcessLogCU(List<CertificateProcessLog> processLogs)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@tableType", processLogs.ToCustomDataTable(), DbType.Object);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryAsync("SIMS.CertificateProcessLogCU", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        #endregion
    }
}
