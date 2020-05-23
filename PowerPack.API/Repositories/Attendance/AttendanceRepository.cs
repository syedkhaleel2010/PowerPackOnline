using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PowerPack.Models;

namespace SIMS.API.Repositories
{
    public class AttendanceRepository : SqlRepository<Attendance>, IAttendanceRepository
    {
        private readonly IConfiguration _config;

        public AttendanceRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override  Task<IEnumerable<Attendance>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override  Task<Attendance> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Attendance>> GetAttendanceByIdAndDate(long acd_id,int ttm_id,string username, string entrydate, string grade = null, string section = null, string AttendanceType = "Session1")
        {
            
            List<Attendance> Objattendances = new List<Attendance>();
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", acd_id, DbType.Int32);
                parameters.Add("@TTM_ID", ttm_id, DbType.Int32);
                parameters.Add("@GRD_ID", grade, DbType.String);
                parameters.Add("@SCT_ID", section, DbType.String);
                parameters.Add("@USR_NAME", username, DbType.String);
                parameters.Add("@DTE", entrydate, DbType.String);
                parameters.Add("@AttendanceType", AttendanceType, DbType.String);
                var result = await conn.QueryMultipleAsync("SIMS.GET_ATTENDANCE_DETS", parameters, null, null, CommandType.StoredProcedure);
                var arrOfSection = section.Split(',');
               
                foreach(var arr in arrOfSection)
                {
                    var listOfAddendance = await result.ReadAsync<Attendance>();

                    Objattendances.AddRange(listOfAddendance);
                }
                
                return Objattendances;
            }
        }
        public async Task<int> InsertAttendanceDetails(string student_xml, string entry_date, string username, int alg_id, int ttm_id = 0 , string sct_id = "", string GRD_ID="",long ACD_ID=0, long BSU_ID=0,long SHF_ID=0,long STM_ID=0, string AttendanceType="")
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STUDENT_XML", student_xml, DbType.String);
                parameters.Add("@ENTRY_DATE", entry_date, DbType.String);
                parameters.Add("@TTM_ID", ttm_id, DbType.Int32);
                parameters.Add("@SCT_ID", sct_id, DbType.String);
                parameters.Add("@USR_NAME", username, DbType.String);
                parameters.Add("@ALG_ID", alg_id, DbType.Int32);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int32);
                parameters.Add("@SHF_ID", SHF_ID, DbType.Int32);
                parameters.Add("@STM_ID", STM_ID, DbType.Int32);
                parameters.Add("@AttendanceType", AttendanceType, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.InsertAttendanceDetails", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }


        public async Task<IEnumerable<ATTENDENCE_ANALYSIS>> Get_ATTENDENCE_ANALYSIS(String STU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String); 
                return await conn.QueryAsync<ATTENDENCE_ANALYSIS>("SIMS.GET_ATTENDENCE_ANALYSIS", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<AttendenceBySession>> Get_AttendenceBySession(String STU_ID, DateTime EndDate)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String);
                 parameters.Add("@END_DT", EndDate, DbType.String);
                
                return await conn.QueryAsync<AttendenceBySession>("SIMS.GET_AttendenceBySession", parameters, null, null, CommandType.StoredProcedure);
            }
        }


        public async Task<IEnumerable<AttendenceSessionCode>> Get_AttendenceSessionCode(String STU_ID, DateTime EndDate)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String);
                parameters.Add("@END_DT", EndDate, DbType.String);
                return await conn.QueryAsync<AttendenceSessionCode>("SIMS.GET_ATENDENCESESSIONCODE", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<AttendanceChart>> Get_AttendanceChartMain(String STU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String); 
                return await conn.QueryAsync<AttendanceChart>("SIMS.GET_ATTENDENCE_BY_ACD_ID", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public override void InsertAsync(Attendance entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(Attendance entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoomAttendance>> GetRoomAttendanceDetails(string USER_NAME, long TTM_ID, string GRD_ID, string SCT_ID, int ACD_ID, string entryDate)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@USER_NAME", USER_NAME, DbType.String);
                parameters.Add("@TTM_ID", TTM_ID, DbType.Int64);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SCT_ID", SCT_ID, DbType.String);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
                parameters.Add("@ENTRY_DATE",Convert.ToDateTime(entryDate), DbType.DateTime);
                return await conn.QueryAsync<RoomAttendance>("SIMS.GetRoomAttendanceDetails", parameters, null, null, CommandType.StoredProcedure);
               
            }
        }

        public async Task<IEnumerable<RoomAttendanceHeader>> GetRoomAttendanceHeader(long SGR_ID, DateTime ENTRY_DATE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SGR_ID", SGR_ID, DbType.Int64);
                parameters.Add("@ENTRY_DATE", ENTRY_DATE, DbType.DateTime);
              
                return await conn.QueryAsync<RoomAttendanceHeader>("SIMS.GetRoomAttendanceHeader", parameters, null, null, CommandType.StoredProcedure);

            }
        }

        public bool InsertUpdateRoomAttendance(string SchoolId, string UserId,string Acd_Id, List<StudentRoomAttendance> objStudentRoomLog, List<StudentRoomAttendance> objStudentRoomAttendance)
        {
            
            DataTable dtRoomAttendanceLog = new DataTable();
            dtRoomAttendanceLog.Columns.Add("Id", typeof(long));
            dtRoomAttendanceLog.Columns.Add("RoomDate", typeof(DateTime));
            dtRoomAttendanceLog.Columns.Add("GroupId", typeof(int));
            dtRoomAttendanceLog.Columns.Add("UserId", typeof(string));
            dtRoomAttendanceLog.Columns.Add("AcdId", typeof(string));
            dtRoomAttendanceLog.Columns.Add("SchoolId", typeof(string));
            dtRoomAttendanceLog.Columns.Add("PeriodId", typeof(int));
            foreach (var item in objStudentRoomLog)
            {
                dtRoomAttendanceLog.Rows.Add(item.logId, Convert.ToDateTime(item.RoomDate), item.SGR_ID, UserId, Acd_Id, SchoolId,item.PeriodNo);
            }

            DataTable dtRoomAttendanceDetails = new DataTable();
            dtRoomAttendanceDetails.Columns.Add("Id", typeof(long));
            dtRoomAttendanceDetails.Columns.Add("StudentId", typeof(long));
            dtRoomAttendanceDetails.Columns.Add("StatusId", typeof(string));
            dtRoomAttendanceDetails.Columns.Add("Remarks", typeof(string));
            dtRoomAttendanceDetails.Columns.Add("PeriodId", typeof(int));
            dtRoomAttendanceDetails.Columns.Add("GroupId", typeof(int));
         
            foreach (var item in objStudentRoomAttendance)
            {
                dtRoomAttendanceDetails.Rows.Add(item.DetailId, item.StudentId,item.Status,item.Remark, item.PeriodNo,item.SGR_ID);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@tblRoomAttendanceLog", dtRoomAttendanceLog, DbType.Object);
            parameters.Add("@tblRoomAttendanceDetails", dtRoomAttendanceDetails, DbType.Object);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.RoomAttendanceDetailsCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        public async Task<IEnumerable<StudentRoomAttendance>> GetRoomAttendanceRemarksList(string entryDate, string schoolId, string UserId, int GroupId)
        {
         
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@entryDate", Convert.ToDateTime(entryDate), DbType.DateTime);
                parameters.Add("@schoolId", schoolId, DbType.String);
                parameters.Add("@UserId", UserId, DbType.String);
                parameters.Add("@GroupId", GroupId, DbType.Int32);
                return await conn.QueryAsync<StudentRoomAttendance>("SIMS.GetRoomAttendanceRemarksList", parameters, null, null, CommandType.StoredProcedure);

            }
        }

        public async Task<IEnumerable<GradeSectionAccess>> GetGradeSectionAccesses(long schoolId, long academicYear, string userName, string IsSuperUser, int gradeAccess, string gradeId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", schoolId);
                parameters.Add("@ACD_ID", academicYear);
                parameters.Add("@UserName", userName);
                parameters.Add("@IsSuperUser", IsSuperUser);
                parameters.Add("@GRD_ACCESS", gradeAccess);
                parameters.Add("@GRD_ID", gradeId);
                return await conn.QueryAsync<GradeSectionAccess>("[SIMS].GradeSectionAccessForAttendance", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<AttendanceSessionType>> GetAttendanceTypeByEntryDate(int acdId, string schoolId, DateTime AttendanceDt, string GrdId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@acdId", acdId, DbType.Int32);
                parameters.Add("@schoolId", schoolId, DbType.String);
                parameters.Add("@AttendanceDt", AttendanceDt, DbType.DateTime);
                parameters.Add("@GrdId", GrdId, DbType.String);
              
                
                return await conn.QueryAsync<AttendanceSessionType>("SIMS.GetAttendanceTypeByEntryDate", parameters, null, null, CommandType.StoredProcedure);

            }
        }
    }
}
