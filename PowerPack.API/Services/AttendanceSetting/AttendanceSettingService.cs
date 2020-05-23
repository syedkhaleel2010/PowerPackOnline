using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Services
{
    public class AttendanceSettingService : IAttendanceSettingService
    {
        private readonly IAttendanceSettingRepository _IAttendancSettingRepository;
        public AttendanceSettingService(IAttendanceSettingRepository IAttendancSettingRepository)
        {

            _IAttendancSettingRepository = IAttendancSettingRepository;

        }
        #region Attendance Permission

        public async Task<IEnumerable<AttendancePermission>> GetPermissionList(int academicYearId)
        {
            return await _IAttendancSettingRepository.GetPermissionList(academicYearId);
        }
        public async Task<IEnumerable<StaffDetails>> GetStaffDetails(string schoolId)
        {
            return await _IAttendancSettingRepository.GetStaffDetails(schoolId);
        }
        public async Task<IEnumerable<AttendanceStaff>> GetStaffList(long SCT_ID, string gradeId, string streamId, string shiftId, int academicYearId)
        {
            return await _IAttendancSettingRepository.GetStaffList(SCT_ID, gradeId, streamId, shiftId, academicYearId);
        }

        public bool AddUpdatePermission(string schoolId, AttendancePermission objAttendancePermission)
        {
            return _IAttendancSettingRepository.AddUpdatePermission(schoolId, objAttendancePermission);
        }
        #endregion



        #region Parameter Setting
        public async Task<int> SaveParameterSetting(ParameterSetting parameterSetting, string DATAMODE)
        {
            return await _IAttendancSettingRepository.SaveParameterSetting(parameterSetting, DATAMODE);
        }
        public async Task<IEnumerable<ParameterSetting>> GetParameterSettingList(long ACD_ID, long BSU_ID, int divisionId)
        {
            return await _IAttendancSettingRepository.GetParameterSettingList(ACD_ID, BSU_ID, divisionId);
        }
        #endregion
        public async Task<IEnumerable<GradeDetails>> GetGradeDetails()
        {
            return await _IAttendancSettingRepository.GetGradeDetails();
        }

        public async Task<VerticalAttendanceGroupSetting> GetVerticalAttendanceGroupSetting(long ASU_ID)
        {
            return await _IAttendancSettingRepository.GetVerticalAttendanceGroupSetting(ASU_ID);
        }
        public async Task<IEnumerable<VerticalAttendanceGroup>> GetVerticalAttendanceGroup(long AVG_ID)
        {
            return await _IAttendancSettingRepository.GetVerticalAttendanceGroup(AVG_ID);
        }

        public async Task<IEnumerable<AttendanceType>> GetAttendanceType(long BSU_ID, int divisionId)
        {
            return await _IAttendancSettingRepository.GetAttendanceType(BSU_ID,divisionId);
        }

        public async Task<int> SaveGradeDetails(GradeDetails GradeDetails, string DATAMODE)
        {
            return await _IAttendancSettingRepository.SaveGradeDetails(GradeDetails, DATAMODE);
        }

        public async Task<int> SaveVerticalAttendanceGroup(VerticalAttendanceGroup SaveVerticalAttendanceGroup, string DATAMODE)
        {
            return await _IAttendancSettingRepository.SaveVerticalAttendanceGroup(SaveVerticalAttendanceGroup, DATAMODE);
        }
        public async Task<string> SaveVerticalAttendanceGroupSetting(VerticalAttendanceGroupSetting VerticalAttendanceGroupSetting)
        {
            return await _IAttendancSettingRepository.SaveVerticalAttendanceGroupSetting(VerticalAttendanceGroupSetting);
        }

        public async Task<IEnumerable<AutomateAttendance>> GetAutomateAttendance(long BSU_ID, long ACD_ID, int divisionId)
        {
            return await _IAttendancSettingRepository.GetAutomateAttendance(BSU_ID, ACD_ID, divisionId);
        }
        public async Task<int> SaveAutomateAttendance(AutomateAttendance AutomateAttendance, string DATAMODE)
        {
            return await _IAttendancSettingRepository.SaveAutomateAttendance(AutomateAttendance, DATAMODE);
        }
        public async Task<int> SaveAttendanceType(AttendanceType AttendanceType, string DATAMODE)
        {
            return await _IAttendancSettingRepository.SaveAttendanceType(AttendanceType, DATAMODE);
        }
        #region Attendance Calendar
        public async Task<IEnumerable<GradeAndSection>> GetGradeAndSectionList(long ACD_ID)
        {
            return await _IAttendancSettingRepository.GetGradeAndSectionList(ACD_ID);
        }
        public async Task<SchoolWeekEnd> GetSchoolWeekEnd(long BSU_ID)
        {
            return await _IAttendancSettingRepository.GetSchoolWeekEnd(BSU_ID);
        }
        public async Task<int> SaveCalendarEvent(AttendanceCalendar attendanceCalendar, string DATAMODE)
        {
            return await _IAttendancSettingRepository.SaveCalendarEvent(attendanceCalendar, DATAMODE);
        }
        public async Task<IEnumerable<AttendanceCalendar>> GetCalendarDetail(long BSU_ID, long ACD_ID, long SCH_ID, bool IsListView)
        {
            return await _IAttendancSettingRepository.GetCalendarDetail(BSU_ID, ACD_ID, SCH_ID, IsListView);
        }
        public async Task<IEnumerable<AcademicYearDetail>> GetAcademicYearDetail(long ACD_ID)
        {
            return await _IAttendancSettingRepository.GetAcademicYearDetail(ACD_ID);
        }
        #endregion Attendance Calendar

        #region Leave approval permission
        public async Task<IEnumerable<LeaveApprovalPermissionModel>> GetLeaveApprovalPermission(long AcdId, long schoolId, int divisionId)
        {
            return await _IAttendancSettingRepository.GetLeaveApprovalPermission(AcdId,schoolId,divisionId);
        }
        public async Task<int> LeaveApprovalPermissionCU(LeaveApprovalPermissionModel leaveApproval)
        {
            return await _IAttendancSettingRepository.LeaveApprovalPermissionCU(leaveApproval);
        }
        #endregion

        #region Schedule Attendance Email
        public async Task<IEnumerable<ScheduleAttendanceEmail>> GetScheduleAttendanceEmailList(long schoolId, int divisionId)
        {
            return await _IAttendancSettingRepository.GetScheduleAttendanceEmailList( schoolId, divisionId);
        }
        public async Task<int> SaveScheduleAttendanceEmail(ScheduleAttendanceEmail scheduleAttendanceEmail, string DATAMODE)
        {
            return await _IAttendancSettingRepository.SaveScheduleAttendanceEmail(scheduleAttendanceEmail, DATAMODE);
        }


        #endregion Schedule Attendance Email

        #region Attendance Period

        public async Task<IEnumerable<AttendacePeriodSetting>> GetAttendancePeriod(string schoolId, int acadamicYearId, string gradeId)
        {
            return await _IAttendancSettingRepository.GetAttendancePeriod(schoolId, acadamicYearId, gradeId);
        }

        public bool AddUpdateAttendancePeriod(long schoolId, long academicId, string gradeId, long CreatedBy, List<AttendacePeriodSetting> objAttendancePeriod)
        {
            return _IAttendancSettingRepository.AddUpdateAttendancePeriod( schoolId,  academicId,  gradeId, CreatedBy, objAttendancePeriod);
        }
        #endregion

        public async Task<int> SaveAttendanceBulkUpload(AttendanceBulkUpload attendanceBulk) => await _IAttendancSettingRepository.SaveAttendanceBulkUpload(attendanceBulk);
        public  IEnumerable<AttendanceBulkUploadValidationModel> ValidateAttendanceBulkUpload(AttendanceBulkUpload attendanceBulk) =>
             _IAttendancSettingRepository.ValidateAttendanceBulkUpload(attendanceBulk);
    }
}
