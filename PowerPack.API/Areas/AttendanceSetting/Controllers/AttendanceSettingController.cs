using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using PowerPack.Models;
namespace SIMS.API.Areas.AttendanceSetting.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AttendanceSettingController : ControllerBase
    {
        private readonly IAttendanceSettingService _attendanceService;

        public AttendanceSettingController(IAttendanceSettingService attendanceService)
        {
            _attendanceService = attendanceService;

        }

        #region Attendance Permission
        [HttpGet]
        [Route("GetPermissionList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AttendancePermission>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPermissionList(int academicYearId)
        {
            var result = await _attendanceService.GetPermissionList(academicYearId);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetStaffDetails")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.StaffDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStaffDetails(string schoolId)
        {
            var result = await _attendanceService.GetStaffDetails(schoolId);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetStaffList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AttendanceStaff>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStaffList(long SCT_ID, string gradeId, string streamId, string shiftId, int academicYearId)
        {
            var result = await _attendanceService.GetStaffList(SCT_ID, gradeId, streamId, shiftId, academicYearId);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddUpdatePermission")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddUpdatePermission(string schoolId, AttendancePermission objAttendancePermission)
        {
            var result = _attendanceService.AddUpdatePermission(schoolId, objAttendancePermission);
            return Ok(result);
        }

        #endregion

        #region Parameter Setting
        [HttpPost]
        [Route("SaveParameterSetting")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveParameterSetting(ParameterSetting parameterSetting, string DATAMODE)
        {
            var result = await _attendanceService.SaveParameterSetting(parameterSetting, DATAMODE);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetParameterSettingList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.ParameterSetting>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetParameterSettingList(long ACD_ID, long BSU_ID, int divisionId)
        {
            var result = await _attendanceService.GetParameterSettingList(ACD_ID, BSU_ID, divisionId);
            return Ok(result);
        }
        #endregion

        [HttpGet]
        [Route("GetGradeDetails")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.GradeDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradeDetails()
        {
            var result = await _attendanceService.GetGradeDetails();
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveVerticalAttendanceGroup")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveVerticalAttendanceGroup(VerticalAttendanceGroup VerticalAttendance, string DATAMODE)
        {
            var result = await _attendanceService.SaveVerticalAttendanceGroup(VerticalAttendance, DATAMODE);
            return Ok(result);
        }


        [HttpPost]
        [Route("SaveVerticalAttendanceGroupSetting")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveVerticalAttendanceGroupSetting(VerticalAttendanceGroupSetting VerticalAttendanceGroupSetting)
        {
            var result = await _attendanceService.SaveVerticalAttendanceGroupSetting(VerticalAttendanceGroupSetting);
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveAttendanceType")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveAttendanceType(AttendanceType AttendanceType, string DATAMODE)
        {
            var result = await _attendanceService.SaveAttendanceType(AttendanceType, DATAMODE);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveGradeDetails")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveGradeDetails(GradeDetails GradeDetails, string DATAMODE)
        {
            var result = await _attendanceService.SaveGradeDetails(GradeDetails, DATAMODE);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAttendanceType")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AttendanceType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAttendanceType(long BSU_ID, int divisionId)
        {
            var result = await _attendanceService.GetAttendanceType(BSU_ID,divisionId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetVerticalAttendanceGroupSetting")]
        [ProducesResponseType(typeof(VerticalAttendanceGroupSetting), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetVerticalAttendanceGroupSetting(long AVG_ID)
        {
            var result = await _attendanceService.GetVerticalAttendanceGroupSetting(AVG_ID);
            return Ok(result);
        }

        #region Attendance Calendar
        [HttpGet]
        [Route("GetGradeAndSectionList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.GradeAndSection>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradeAndSectionList(long ACD_ID)
        {
            var result = await _attendanceService.GetGradeAndSectionList(ACD_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetSchoolWeekEnd")]
        [ProducesResponseType(typeof(SIMS.API.Models.SchoolWeekEnd), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSchoolWeekEnd(long BSU_ID)
        {
            var result = await _attendanceService.GetSchoolWeekEnd(BSU_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveCalendarEvent")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveCalendarEvent(AttendanceCalendar attendanceCalendar, string DATAMODE)
        {
            var result = await _attendanceService.SaveCalendarEvent(attendanceCalendar, DATAMODE);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetCalendarDetail")]
        [ProducesResponseType(typeof(SIMS.API.Models.AttendanceCalendar), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCalendarDetail(long BSU_ID, long ACD_ID, long SCH_ID, bool IsListView)
        {
            var result = await _attendanceService.GetCalendarDetail(BSU_ID, ACD_ID, SCH_ID, IsListView);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAcademicYearDetail")]
        [ProducesResponseType(typeof(SIMS.API.Models.AcademicYearDetail), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAcademicYearDetail(long ACD_ID)
        {
            var result = await _attendanceService.GetAcademicYearDetail(ACD_ID);
            return Ok(result);
        }
        #endregion Attendance Calendar

        [HttpGet]
        [Route("GetLeaveApprovalPermission")]
        [ProducesResponseType(typeof(IEnumerable<LeaveApprovalPermissionModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetLeaveApprovalPermission(long ACD_ID, long schoolId, int divisionId)
        {
            var result = await _attendanceService.GetLeaveApprovalPermission(ACD_ID,schoolId,divisionId);
            return Ok(result);
        }
        [HttpPost]
        [Route("LeaveApprovalPermissionCU")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LeaveApprovalPermissionCU(LeaveApprovalPermissionModel leaveApproval)
        {
            var result = await _attendanceService.LeaveApprovalPermissionCU(leaveApproval);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAutomateAttendance")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AutomateAttendance>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAutomateAttendance(long BSU_ID, long ACD_ID,int divisionId)
        {
            var result = await _attendanceService.GetAutomateAttendance(BSU_ID, ACD_ID,divisionId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetVerticalAttendanceGroup")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.GradeAndSection>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetVerticalAttendanceGroup(long ACD_ID)
        {
            var result = await _attendanceService.GetVerticalAttendanceGroup(ACD_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveAutomateAttendance")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveAutomateAttendance(AutomateAttendance AutomateAttendance, string DATAMODE)
        {
            var result = await _attendanceService.SaveAutomateAttendance(AutomateAttendance, DATAMODE);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetScheduleAttendanceEmailList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.ScheduleAttendanceEmail>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetScheduleAttendanceEmailList(long schoolId, int divisionId)
        {
            var result = await _attendanceService.GetScheduleAttendanceEmailList(schoolId, divisionId);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveScheduleAttendanceEmail")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveScheduleAttendanceEmail(ScheduleAttendanceEmail scheduleAttendanceEmail, string DATAMODE)
        {
            var result = await _attendanceService.SaveScheduleAttendanceEmail(scheduleAttendanceEmail, DATAMODE);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAttendancePeriod")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AttendacePeriodSetting>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAttendancePeriod(string schoolId, int acadamicYearId, string gradeId)
        {
            var result = await _attendanceService.GetAttendancePeriod(schoolId, acadamicYearId, gradeId);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddUpdateAttendancePeriod")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddUpdateAttendancePeriod(long schoolId, long academicId, string gradeId, long CreatedBy, List<AttendacePeriodSetting> objAttendancePeriod)
        {
            var result =  _attendanceService.AddUpdateAttendancePeriod( schoolId,  academicId,  gradeId, CreatedBy, objAttendancePeriod);
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveAttendanceBulkUpload")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveAttendanceBulkUpload(AttendanceBulkUpload attendanceBulkUpload)
        {
            var result = await _attendanceService.SaveAttendanceBulkUpload(attendanceBulkUpload);
            return Ok(result);
        }

        [HttpPost]
        [Route("ValidateAttendanceBulkUpload")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceBulkUploadValidationModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult ValidateAttendanceBulkUpload(AttendanceBulkUpload attendanceBulkUpload)
        {
            var result = _attendanceService.ValidateAttendanceBulkUpload(attendanceBulkUpload);
            return Ok(result);
        }
    }
}