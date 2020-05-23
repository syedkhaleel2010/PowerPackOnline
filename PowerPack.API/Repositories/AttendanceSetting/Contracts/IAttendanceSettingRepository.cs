using DbConnection;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace SIMS.API.Repositories
{
    public interface IAttendanceSettingRepository
    {
        #region Attendance Permission
        Task<IEnumerable<AttendancePermission>> GetPermissionList(int academicYearId);
        Task<IEnumerable<StaffDetails>> GetStaffDetails(string schoolId);

        Task<IEnumerable<AttendanceStaff>> GetStaffList(long SCT_ID, string gradeId, string streamId, string shiftId, int academicYearId);

        bool AddUpdatePermission(string schoolId, AttendancePermission objAttendancePermission);
        #endregion

        #region Parameter Setting
        Task<int> SaveParameterSetting(ParameterSetting parameterSetting, string DATAMODE);
        Task<IEnumerable<ParameterSetting>> GetParameterSettingList(long ACD_ID, long BSU_ID, int divisionId);
        #endregion
        Task<IEnumerable<GradeDetails>> GetGradeDetails();
        Task<int> SaveVerticalAttendanceGroup(VerticalAttendanceGroup VerticalAttendanceGroup, string DATAMODE);
        Task<IEnumerable<VerticalAttendanceGroup>> GetVerticalAttendanceGroup(long AVG_ID);

        Task<IEnumerable<AttendanceType>> GetAttendanceType(long BSU_ID, int divisionId);

        Task<VerticalAttendanceGroupSetting> GetVerticalAttendanceGroupSetting(long ASU_ID);

        Task<int> SaveGradeDetails(GradeDetails GradeDetails, string DATAMODE);
        Task<int> SaveAttendanceType(AttendanceType AttendanceType, string DATAMODE);
        Task<IEnumerable<AutomateAttendance>> GetAutomateAttendance(long BSU_ID, long ACD_ID, int divisionId);

        Task<string> SaveVerticalAttendanceGroupSetting(VerticalAttendanceGroupSetting VerticalAttendanceGroupSetting);
        Task<int> SaveCalendarEvent(AttendanceCalendar attendanceCalendar, string DATAMODE);

        #region Attendance Calendar
        Task<IEnumerable<GradeAndSection>> GetGradeAndSectionList(long ACD_ID);

        Task<SchoolWeekEnd> GetSchoolWeekEnd(long BSU_ID);
        Task<int> SaveAutomateAttendance(AutomateAttendance AutomateAttendance, string DATAMODE);
        Task<IEnumerable<AttendanceCalendar>> GetCalendarDetail(long BSU_ID, long ACD_ID, long SCH_ID, bool IsListView);
        Task<IEnumerable<AcademicYearDetail>> GetAcademicYearDetail(long ACD_ID);
        #endregion Attendance Calendar

        #region Leave approval permission
        Task<IEnumerable<LeaveApprovalPermissionModel>> GetLeaveApprovalPermission(long AcdId, long schoolId, int divisionId);
        Task<int> LeaveApprovalPermissionCU(LeaveApprovalPermissionModel leaveApproval);
        #endregion

        #region Schedule Attendance Email
        Task<IEnumerable<ScheduleAttendanceEmail>> GetScheduleAttendanceEmailList(long schoolId, int divisionId);
        Task<int> SaveScheduleAttendanceEmail(ScheduleAttendanceEmail scheduleAttendanceEmail, string DATAMODE);
        #endregion Schedule Attendance Email


        #region Attendance Period

        Task<IEnumerable<AttendacePeriodSetting>> GetAttendancePeriod(string schoolId, int acadamicYearId, string gradeId);

        bool AddUpdateAttendancePeriod(long schoolId, long academicId, string gradeId, long CreatedBy, List<AttendacePeriodSetting> objAttendancePeriod);


        #endregion
        IEnumerable<AttendanceBulkUploadValidationModel> ValidateAttendanceBulkUpload(AttendanceBulkUpload attendanceBulk);
        Task<int> SaveAttendanceBulkUpload(AttendanceBulkUpload attendanceBulk);
    }
}
