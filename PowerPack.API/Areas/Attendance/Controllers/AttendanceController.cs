using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using PowerPack.Models;

namespace SIMS.API.Areas.Attendance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _AttendanceService;

        public AttendanceController(IAttendanceService Attendance_Service)
        {
            _AttendanceService = Attendance_Service;
        }

        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 27/May/2019
        /// Description: To get the class attendance of the id and date param
        /// <param name="tt_id">TimeTable id </param>
        /// <param name="datetime">date field</param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAttendanceByIdAndDate")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.Attendance>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAttendanceByIdAndDate(long acd_id,int ttm_id, string username, string entrydate, string grade = null, string section = null,string AttendanceType ="")
        {
            var result = await _AttendanceService.GetAttendanceByIdAndDate(acd_id,ttm_id, username, entrydate, grade, section, AttendanceType);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 29/July/2019
        /// Description: To insert/update the attendance details .
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertAttendanceDetails")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        
        public async Task<IActionResult> InsertAttendanceDetails([FromBody] string student_xml, string entry_date, string username, int alg_id, int ttm_id = 0, string sct_id = "", string GRD_ID = "", long ACD_ID = 0, long BSU_ID = 0, long SHF_ID = 0, long STM_ID = 0, string AttendanceType = "")
        {
            var result =  await _AttendanceService.InsertAttendanceDetails(student_xml, entry_date, username, alg_id, ttm_id, sct_id, GRD_ID, ACD_ID, BSU_ID, SHF_ID, STM_ID, AttendanceType);
            return Ok(result);
        }



        /// <summary>
        /// Created By: HRushikesh
        /// Created On: 08/AUG/2019
        /// Description: To get attendence analysis by stu id
        /// <param name="STU_ID">STU_ID </param> 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get_ATTENDENCE_ANALYSIS")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.ATTENDENCE_ANALYSIS>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get_ATTENDENCE_ANALYSIS(string STU_ID)
        {
            var result = await _AttendanceService.Get_ATTENDENCE_ANALYSIS(STU_ID);
            return Ok(result);
        }

        /// <summary>
        /// Created By: HRushikesh
        /// Created On: 14/AUG/2019
        /// Description: To get Attendence By Session and stu id
        /// <param name="STU_ID">STU_ID </param> 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get_AttendenceBySession")]
        [ProducesResponseType(typeof(IEnumerable<AttendenceBySession>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get_AttendenceBySession(string STU_ID,DateTime EndDate)
        {
            var result = await _AttendanceService.Get_AttendenceBySession(STU_ID, EndDate);
            return Ok(result);
        }


        /// <summary>
        /// Created By: HRushikesh
        /// Created On: 15/AUG/2019
        /// Description: To Get_Attendence Session Code
        /// <param name="STU_ID">STU_ID </param> 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get_AttendenceSessionCode")]
        [ProducesResponseType(typeof(IEnumerable<AttendenceSessionCode>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get_AttendenceSessionCode(string STU_ID,DateTime EndDate)
        {
            var result = await _AttendanceService.Get_AttendenceSessionCode(STU_ID, EndDate);
            return Ok(result);
        }

        /// <summary>
        /// Created By: HRushikesh
        /// Created On: 10/SEP/2019
        /// Description: To Get_Attendence for last 3 years
        /// <param name="STU_ID">STU_ID </param> 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get_AttendanceChartMain")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceChart>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get_AttendanceChartMain(string STU_ID)
        {
            var result = await _AttendanceService.Get_AttendanceChartMain(STU_ID);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetRoomAttendanceDetails")]
        [ProducesResponseType(typeof(IEnumerable<RoomAttendance>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRoomAttendanceDetails(string USER_NAME, long TTM_ID, string GRD_ID, string SCT_ID, int ACD_ID,string entryDate)
        {
            var result = await _AttendanceService.GetRoomAttendanceDetails(USER_NAME, TTM_ID, GRD_ID, SCT_ID, ACD_ID, entryDate);
            return Ok(result);
        }



        [HttpGet]
        [Route("GetRoomAttendanceHeader")]
        [ProducesResponseType(typeof(IEnumerable<RoomAttendanceHeader>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRoomAttendanceHeader(long SGR_ID, DateTime ENTRY_DATE)
        {
            var result = await _AttendanceService.GetRoomAttendanceHeader( SGR_ID,  ENTRY_DATE);
            return Ok(result);
        }


        [HttpPost]
        [Route("InsertUpdateRoomAttendance")]
        [ProducesResponseType((int)HttpStatusCode.Created)]

        public async Task<IActionResult> InsertUpdateRoomAttendance(string SchoolId, string UserId, string Acd_Id, StudentLogAttendance objStudentAttendanceLog)
        {
            var result =  _AttendanceService.InsertUpdateRoomAttendance(SchoolId, UserId, Acd_Id, objStudentAttendanceLog.objStudentLog, objStudentAttendanceLog.objStudentAttendance); 
            return Ok(result);
        }




        [HttpGet]
        [Route("GetRoomAttendanceRemarksList")]
        [ProducesResponseType(typeof(IEnumerable<StudentRoomAttendance>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRoomAttendanceRemarksList(string entryDate, string schoolId, string UserId, string GroupId)
        {
            var result = await _AttendanceService.GetRoomAttendanceRemarksList( entryDate,  schoolId,  UserId, Convert.ToInt32(GroupId));
            return Ok(result);
        }

        [HttpGet]
        [Route("GetGradeSectionAccesses")]
        [ProducesResponseType(typeof(IEnumerable<GradeSectionAccess>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradeSectionAccesses(long schoolId, long academicYear, string userName, string IsSuperUser, int gradeAccess, string gradeId)
        {
            var result = await _AttendanceService.GetGradeSectionAccesses(schoolId, academicYear, userName,IsSuperUser, gradeAccess, gradeId ?? "");
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAttendanceTypeByEntryDate")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceSessionType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAttendanceTypeByEntryDate(int acdId, string schoolId, DateTime AttendanceDt, string GrdId)
        {
            var result = await _AttendanceService.GetAttendanceTypeByEntryDate(acdId, schoolId, AttendanceDt, GrdId);
            return Ok(result);
        }

    }
} 