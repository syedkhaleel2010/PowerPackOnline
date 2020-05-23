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
using System.Data.SqlClient;

namespace SIMS.API.Repositories
{
    public class AttendanceSettingRepository : SqlRepository<AttendancePermission>, IAttendanceSettingRepository
    {
        private readonly IConfiguration _config;

        public AttendanceSettingRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }
        #region Attendance Permission
        public async Task<IEnumerable<AttendancePermission>> GetPermissionList(int academicYearId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AcademicYearId", academicYearId, DbType.Int32);

                return await conn.QueryAsync<AttendancePermission>("SIMS.AttendanceSettings_GetPermissionList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<StaffDetails>> GetStaffDetails(string schoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@schoolId", schoolId, DbType.Int32);

                return await conn.QueryAsync<StaffDetails>("SIMS.AttendanceSettings_GetStaffDetails", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<AttendanceStaff>> GetStaffList(long SCT_ID, string gradeId, string streamId, string shiftId, int academicYearId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SCT_ID", SCT_ID, DbType.Int64);
                parameters.Add("@gradeId", gradeId, DbType.String);
                parameters.Add("@streamId", streamId, DbType.String);
                parameters.Add("@shiftId", shiftId, DbType.String);
                parameters.Add("@academicYearId", academicYearId, DbType.Int32);
                return await conn.QueryAsync<AttendanceStaff>("SIMS.AttendanceSettings_GetStaffList", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public bool AddUpdatePermission(string schoolId, AttendancePermission objAttendancePermission)
        {
            var gradearr = objAttendancePermission.Grade.Split('|');
            var parameters = new DynamicParameters();
            parameters.Add("@PermissionId", objAttendancePermission.PermissionId, DbType.Int32);
            parameters.Add("@AcademicId", objAttendancePermission.AcademicYearId, DbType.Int32);
            parameters.Add("@GradeId", gradearr[0], DbType.String);
            parameters.Add("@SectionId", Convert.ToInt64(objAttendancePermission.SectionId), DbType.Int64);
            parameters.Add("@StreamId", objAttendancePermission.StreamId, DbType.Int32);
            parameters.Add("@ShiftId", objAttendancePermission.ShiftId, DbType.Int32);
            parameters.Add("@SchoolId", schoolId, DbType.String);
            parameters.Add("@EmployeeId", objAttendancePermission.AuthorizedStaffId, DbType.String);
            parameters.Add("@DivisionId", objAttendancePermission.DivisionId, DbType.Int32);
            parameters.Add("@FromDate", objAttendancePermission.FromDate, DbType.DateTime);
            parameters.Add("@ToDate", objAttendancePermission.ToDate, DbType.DateTime);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.AttendanceSettings_PermissionCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }
        #endregion
        public async Task<IEnumerable<GradeDetails>> GetGradeDetails()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<GradeDetails>("SIMS.AttendanceSettings_GetGradeDetails", null, null, null, CommandType.StoredProcedure);
            }
        }


        public async Task<int> SaveGradeDetails(GradeDetails Grade, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {

                var parameters = new DynamicParameters();
                parameters.Add("@FAD_ID", Grade.fad_id, DbType.Int64);
                parameters.Add("@FAD_ACD_ID", Grade.FAD_ACD_ID, DbType.Int64);
                parameters.Add("@FAD_GRD_IDS", Grade.Grades, DbType.String);
                parameters.Add("@FAD_DT", Grade.FAD_DT, DbType.String);
                parameters.Add("@FAD_CREATED_BY", Grade.FAD_CREATED_BY, DbType.String);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.AttendanceSettings_SaveEditGrade", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<string> SaveVerticalAttendanceGroupSetting(VerticalAttendanceGroupSetting VerticalAttendanceGroupSetting)
        {
            using (var conn = GetOpenConnection())
            {

                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", VerticalAttendanceGroupSetting.ACD_ID, DbType.Int64);
                parameters.Add("@AVG_ID", VerticalAttendanceGroupSetting.AVG_ID, DbType.Int64);
                parameters.Add("@GroupName", VerticalAttendanceGroupSetting.GroupName, DbType.String);
                parameters.Add("@EmployeeDT", VerticalAttendanceGroupSetting.EmployeeVerticalAttendanceGroupSettingDT, DbType.Object);
                parameters.Add("@StudentDT", VerticalAttendanceGroupSetting.StudentVerticalAttendanceGroupSettingDT, DbType.Object);
                parameters.Add("@DataMode", VerticalAttendanceGroupSetting.DataMode, DbType.String);
                parameters.Add("@output", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.SaveVerticalAttendanceGroupSetting", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<string>("output");
            }
        }

        public async Task<int> SaveAttendanceType(AttendanceType AttendanceType, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {

                var parameters = new DynamicParameters();
                parameters.Add("@ATT_ID", AttendanceType.ATT_ID, DbType.Int64);
                parameters.Add("@ATT_ACD_ID", AttendanceType.ACD_ID, DbType.Int64);
                parameters.Add("@ATT_GRD_ID", AttendanceType.GRD_ID, DbType.String);
                parameters.Add("@ATT_BSU_ID", AttendanceType.BSU_ID, DbType.String);
                if (DATAMODE != "Delete")
                {
                    parameters.Add("@ATT_FROMDT", Convert.ToDateTime(AttendanceType.FROMDT), DbType.DateTime);
                    parameters.Add("@ATT_TODT", Convert.ToDateTime(AttendanceType.TODT), DbType.DateTime);
                }
                parameters.Add("@ATT_TYPE", AttendanceType.ATT_TYPE, DbType.String);
                parameters.Add("@DivisionId", AttendanceType.DivisionId, DbType.String);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.AttendanceSettings_SaveAttendanceType", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<AttendanceType>> GetAttendanceType(long BSU_ID,int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int32);
                parameters.Add("@DivisionId", divisionId, DbType.Int32);
                return await conn.QueryAsync<AttendanceType>("SIMS.AttendanceSettings_AttendanceType", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<VerticalAttendanceGroupSetting> GetVerticalAttendanceGroupSetting(long AVG_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AVG_ID", AVG_ID, DbType.Int32);

                var Obj = await conn.QueryMultipleAsync("SIMS.AttendanceSettings_VerticalAttendanceGroupSetting", parameters, null, null, CommandType.StoredProcedure);
                return new VerticalAttendanceGroupSetting
                {
                    EmployeeVerticalAttendanceGroupSettingList = await Obj.ReadAsync<EmployeeVerticalAttendance>(),
                    StudentVerticalAttendanceGroupSettingList = await Obj.ReadAsync<StudentVerticalAttendance>()
                };
            }
        }

        #region Attendance Calendar
        public async Task<IEnumerable<GradeAndSection>> GetGradeAndSectionList(long ACD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                return await conn.QueryAsync<GradeAndSection>("SIMS.AttendanceSettings_GetGradeAndSectionList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<SchoolWeekEnd> GetSchoolWeekEnd(long BSU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                return await conn.QueryFirstOrDefaultAsync<SchoolWeekEnd>("SIMS.AttendanceSettings_GetSchoolWeekEnd", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveCalendarEvent(AttendanceCalendar attendanceCalendar, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SCH_ID", attendanceCalendar.SCH_ID, DbType.Int64);
                parameters.Add("@SCH_BSU_ID", attendanceCalendar.SCH_BSU_ID, DbType.Int64);
                parameters.Add("@SCH_ACD_ID", attendanceCalendar.SCH_ACD_ID, DbType.Int64);
                parameters.Add("@SCH_DTFROM", attendanceCalendar.SCH_DTFROM, DbType.DateTime);
                parameters.Add("@SCH_DTTO", attendanceCalendar.SCH_DTTO, DbType.DateTime);
                parameters.Add("@SCH_REMARKS", attendanceCalendar.SCH_REMARKS, DbType.String);
                parameters.Add("@SCH_TYPE", attendanceCalendar.SCH_TYPE, DbType.String);
                parameters.Add("@SCH_bGRADEALL", attendanceCalendar.SCH_bGRADEALL, DbType.Boolean);
                parameters.Add("@SCH_WEEKEND1_WORK", attendanceCalendar.SCH_WEEKEND1_WORK, DbType.String);
                parameters.Add("@SCH_bWEEKEND1_LOG_BOOK", attendanceCalendar.SCH_bWEEKEND1_LOG_BOOK, DbType.Boolean);
                parameters.Add("@SCH_WEEKEND2_WORK", attendanceCalendar.SCH_WEEKEND2_WORK, DbType.String);
                parameters.Add("@SCH_bWEEKEND2_LOG_BOOK", attendanceCalendar.SCH_bWEEKEND2_LOG_BOOK, DbType.Boolean);
                parameters.Add("@Att_GradeSectionDT", attendanceCalendar.selectedSectionListDT, DbType.Object);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.AttendanceSettings_SaveCalendarDetail", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<AttendanceCalendar>> GetCalendarDetail(long BSU_ID, long ACD_ID, long SCH_ID, bool IsListView)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@SCH_ID", SCH_ID, DbType.Int64);
                parameters.Add("@IsListView", IsListView, DbType.Boolean);
                return await conn.QueryAsync<AttendanceCalendar>("SIMS.AttendanceSettings_GetCalendarDetail", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<AcademicYearDetail>> GetAcademicYearDetail(long ACD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                return await conn.QueryAsync<AcademicYearDetail>("SIMS.GetAcademicYearDetail", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        #endregion Attendance Calendar

        public async Task<IEnumerable<AutomateAttendance>> GetAutomateAttendance(long BSU_ID, long ACD_ID, int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int32);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
                parameters.Add("@DivisionId", divisionId, DbType.Int32);

                return await conn.QueryAsync<AutomateAttendance>("SIMS.AttendanceSettings_AutomateAttendance", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveAutomateAttendance(AutomateAttendance AutomateAttendance, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AAM_ID", AutomateAttendance.AAM_ID, DbType.Int64);
                parameters.Add("@AAM_BSU_ID", AutomateAttendance.BSU_ID, DbType.String);
                parameters.Add("@AAM_ACD_ID", AutomateAttendance.AAM_ACD_ID, DbType.Int64);
                parameters.Add("@AAM_FROMDT", AutomateAttendance.FROMDATE, DbType.DateTime);
                parameters.Add("@AAM_TODT", AutomateAttendance.TODATE, DbType.DateTime);
                parameters.Add("@AAM_DESCR", AutomateAttendance.AAM_DESCR, DbType.String);
                parameters.Add("@ATD_APD_ID", AutomateAttendance.APD_ID, DbType.Int32);
                parameters.Add("@AAM_bACTIVE", AutomateAttendance.AAM_bACTIVE, DbType.Boolean);
                parameters.Add("@AAM_SCHEDULE", AutomateAttendance.AAM_SCHEDULE, DbType.Int32);
                parameters.Add("@DivisionId", AutomateAttendance.DivisionId, DbType.Int32);
                parameters.Add("@Att_GradeSectionDT", AutomateAttendance.selectedSectionListDT, DbType.Object);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.AttendanceSettings_SaveAutomateAttendance", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }

        public async Task<int> SaveVerticalAttendanceGroup(VerticalAttendanceGroup VerticalAttendanceGroup, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", VerticalAttendanceGroup.ACD_ID, DbType.Int64);

                parameters.Add("@AVT_EMP_ID", VerticalAttendanceGroup.Teachers, DbType.String);
                parameters.Add("@AVG_Group_Name", VerticalAttendanceGroup.AVG_GROUP_NAME, DbType.String);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.SaveVerticalAttendanceGroup", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<VerticalAttendanceGroup>> GetVerticalAttendanceGroup(long ACD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                return await conn.QueryAsync<VerticalAttendanceGroup>("SIMS.AttendanceSettings_GetVerticalAttendanceGroup", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        //public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        //{
        //    PropertyDescriptorCollection props =
        //        TypeDescriptor.GetProperties(typeof(T));
        //    var table = new DataTable();
        //    for (int i = 0; i < props.Count; i++)
        //    {
        //        PropertyDescriptor prop = props[i];
        //        var col = (ColumnAttribute)typeof(T).GetProperty(prop.Name).GetCustomAttributes(typeof(ColumnAttribute), false).Single();
        //        table.Columns.Add(col.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        //    }
        //    var values = new object[props.Count];
        //    foreach (T item in data)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = props[i].GetValue(item);
        //        }
        //        table.Rows.Add(values);
        //    }
        //    table.TableName = typeof(T).Name;
        //    return table;
        //}
        #region Parameter Setting
        public async Task<int> SaveParameterSetting(ParameterSetting parameterSetting, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@APD_ID", parameterSetting.APD_ID, DbType.Int64);
                parameters.Add("@APD_BSU_ID", parameterSetting.APD_BSU_ID, DbType.String);
                parameters.Add("@APD_ACD_ID", parameterSetting.APD_ACD_ID, DbType.Int64);
                parameters.Add("@APD_PARAM_DESCR", parameterSetting.APD_PARAM_DESCR, DbType.String);
                parameters.Add("@APD_APM_ID", parameterSetting.APD_APM_ID, DbType.Int64);
                parameters.Add("@APD_bSHOW", parameterSetting.APD_bSHOW, DbType.Boolean);
                parameters.Add("@APD_bPHY_ABS", parameterSetting.APD_bPHY_ABS, DbType.Boolean);
                parameters.Add("@ARP_ID", parameterSetting.ARP_ID, DbType.Int64);
                parameters.Add("@ARP_DESCR", parameterSetting.ARP_DESCR, DbType.String);
                parameters.Add("@ARP_DISP", parameterSetting.ARP_DISP, DbType.String);
                parameters.Add("@DivisionId", parameterSetting.DivisionId, DbType.Int32);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.AttendanceSettings_SaveParameterSetting", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        public async Task<IEnumerable<ParameterSetting>> GetParameterSettingList(long ACD_ID, long BSU_ID,int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int32);
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int32);
                parameters.Add("@DivisionId", divisionId, DbType.Int32);
                return await conn.QueryAsync<ParameterSetting>("SIMS.AttendanceSettings_GetParameterSettingList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        #endregion

        #region Buil In
        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<AttendancePermission>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<AttendancePermission> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(AttendancePermission entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(AttendancePermission entityToUpdate)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Leave approval permission
        public async Task<IEnumerable<LeaveApprovalPermissionModel>> GetLeaveApprovalPermission(long AcdId,long schoolId,int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", AcdId);
                parameters.Add("@BSU_ID", schoolId);
                parameters.Add("@DivisionId", divisionId);

                return await conn.QueryAsync<LeaveApprovalPermissionModel>("SIMS.AttendanceSettings_GetLeaveApprovalPermissionByAcdId", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<int> LeaveApprovalPermissionCU(LeaveApprovalPermissionModel leaveApproval)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SAL_ID", leaveApproval.SalId);
                parameters.Add("@SAL_ACD_ID", leaveApproval.SAL_ACD_ID);
                parameters.Add("@SAL_GRD_ID", leaveApproval.GradeId);
                parameters.Add("@SAL_BSU_ID", leaveApproval.SchoolId);
                parameters.Add("@SAL_EMP_ID", leaveApproval.EmployeeId);
                parameters.Add("@SAL_FROMDT", leaveApproval.FromDate);
                parameters.Add("@SAL_TODT", leaveApproval.ToDate);
                parameters.Add("@SAL_NDAYS", leaveApproval.SAL_NDAYS);
                parameters.Add("@SAL_DivisionId", leaveApproval.DivisionId);
                parameters.Add("@bEdit", leaveApproval.SalId > 0);
                return await conn.ExecuteAsync("SIMS.LeaveApprovalPermissionCU", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        #endregion

        #region Schedule Attendance Email
        public async Task<IEnumerable<ScheduleAttendanceEmail>> GetScheduleAttendanceEmailList(long schoolId, int divisionId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@schoolId", schoolId, DbType.Int64);
                parameters.Add("@DivisionId", divisionId, DbType.Int32);
                return await conn.QueryAsync<ScheduleAttendanceEmail>("SIMS.GetScheduleAttendanceEmailList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveScheduleAttendanceEmail(ScheduleAttendanceEmail scheduleAttendanceEmail, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SAE_ID", scheduleAttendanceEmail.SAE_ID, DbType.Int64);
                parameters.Add("@SAE_BSU_ID", scheduleAttendanceEmail.SAE_BSU_ID, DbType.String);
                parameters.Add("@SAE_GRD_IDS", scheduleAttendanceEmail.SAE_GRD_IDS, DbType.String);
                parameters.Add("@SAE_FROMDT", scheduleAttendanceEmail.SAE_FROMDT, DbType.DateTime);
                parameters.Add("@SAE_TODT", scheduleAttendanceEmail.SAE_TODT, DbType.DateTime);
                parameters.Add("@SAE_bENABLED", scheduleAttendanceEmail.SAE_bENABLED, DbType.Boolean);
                parameters.Add("@SAE_TIME", scheduleAttendanceEmail.SAE_TIME, DbType.String);
                parameters.Add("@SAE_PARAMETERS", scheduleAttendanceEmail.SAE_PARAMETERS, DbType.String);
                parameters.Add("@SAE_EMAILCONTENT", scheduleAttendanceEmail.SAE_EMAILCONTENT, DbType.String);
                parameters.Add("@SAE_USR_ID", scheduleAttendanceEmail.SAE_USR_ID, DbType.String);
                parameters.Add("@SAE_DivisionId", scheduleAttendanceEmail.DivisionId, DbType.Int32);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.SaveScheduleAttendanceEmail", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }


        #endregion Schedule Attendance Email


        #region Attendance Period

        public async Task<IEnumerable<AttendacePeriodSetting>> GetAttendancePeriod(string schoolId, int acadamicYearId, string gradeId)
        {

            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@schoolId", schoolId);
                parameters.Add("@acadamicYearId", acadamicYearId);
                parameters.Add("@gradeId", gradeId);

                return await conn.QueryAsync<AttendacePeriodSetting>("SIMS.AttendanceSetting_GetAttendancePeriod", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public bool AddUpdateAttendancePeriod(long schoolId, long academicId, string gradeId, long CreatedBy, List<AttendacePeriodSetting> objAttendancePeriod)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(long));
            dt.Columns.Add("SchoolId", typeof(long));
            dt.Columns.Add("AcademicId", typeof(long));
            dt.Columns.Add("PeriodNumber", typeof(int));
            dt.Columns.Add("Weightage", typeof(decimal));
            dt.Columns.Add("Remark", typeof(string));
            dt.Columns.Add("GradeId", typeof(string));
            foreach (var item in objAttendancePeriod)
            {
                dt.Rows.Add(item.AttendancePeriodId, schoolId, academicId, item.PeriodNo, item.Weightage, item.Comment, gradeId);
            }
            var parameters = new DynamicParameters();
            parameters.Add("@tblAttendancePeriod", dt, DbType.Object);
            parameters.Add("@CreatedBy", CreatedBy);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.AttendanceSetting_AttendancePeriodCUD", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        #endregion
        public IEnumerable<AttendanceBulkUploadValidationModel> ValidateAttendanceBulkUpload(AttendanceBulkUpload attendanceBulk)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                var Object = attendanceBulk.UploadDataModelsDT;
                parameters.Add("@AttendanceType", attendanceBulk.AttendanceType, DbType.String);
                parameters.Add("@StudentList", Object, DbType.Object);                
                return conn.Query<AttendanceBulkUploadValidationModel>("[SIMS].[fn_BulkAttendanceValidation]", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveAttendanceBulkUpload(AttendanceBulkUpload attendanceBulk)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EntryDate", DateTime.Now.ToString("dd-MMM-yyyy"));
                parameters.Add("@AttendanceDetails_Bulk_UDT", attendanceBulk.UploadDataModelsDT, DbType.Object);
                parameters.Add("@Username", attendanceBulk.Username);
                parameters.Add("@BSU_ID", attendanceBulk.BSU_ID);
                parameters.Add("@ACD_ID", attendanceBulk.ACD_ID);
                parameters.Add("@AttendanceType", attendanceBulk.AttendanceType);
                parameters.Add("@APD_ID", attendanceBulk.APD_ID);
                parameters.Add("@output", DbType.String, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("[SIMS].[InsertAttendanceDetails_Bulk]", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
    }
}
