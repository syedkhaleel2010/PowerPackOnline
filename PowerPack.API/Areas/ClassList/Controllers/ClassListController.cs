using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Areas.CLassList.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClassListController : ControllerBase
    {
        private readonly IClassListService _ClassListService;

        public ClassListController(IClassListService ClassList_Service)
        {
            _ClassListService = ClassList_Service;
        }

        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 20/June/2019
        /// Description: To get the class list from timetable id
        /// <param name="tt_id">TimeTable id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClassList")]
        [ProducesResponseType(typeof(IEnumerable<ClassList>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetClassList(string username, int tt_id = 0, string grade = null, string section = null)
        {
            var result = await _ClassListService.GetClassList(username, tt_id, grade, section);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 23/June/2019
        /// Description: To get the student details for the profile page by id 
        /// <param name="stu_id">Student Id , STUDENT</param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStudentDetails")]
        [ProducesResponseType(typeof(BasicDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentDetails(string stu_id)
        {
            var result = await _ClassListService.GetStudentDetails(stu_id);
            return Ok(result);
        }

        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 23/July/2019
        /// Description: To get the student's parent  details for the profile page by id 
        /// <param name="stu_id">Student Id ,PARENT</param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProfileParentDetails")]
        [ProducesResponseType(typeof(ParentDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProfileParentDetails(string stu_id)
        {
            var result = await _ClassListService.GetProfileParentDetails(stu_id);
            return Ok(result);
        }



        /// <summary>
        /// Created By: Hrushikesh
        /// Created On: 15/Aug/2019
        /// Description: Get Subling details by STU ID
        /// <param name="stu_id">Student Id</param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSiblingDetails")]
        [ProducesResponseType(typeof(IEnumerable<SiblingDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSiblingDetails(string stu_id)
        {
            var result = await _ClassListService.GetSiblingDetails(stu_id);
            return Ok(result);
        }


        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 18/Aug-2019
        /// Description: To get the student Transport details
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTransportDetails")]
        [ProducesResponseType(typeof(TransportDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTransportDetails(string stu_id)
        {
            var result = await _ClassListService.GetTransportDetails(stu_id);
            return Ok(result);
        }


        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 18/Aug-2019
        /// Description: To get the student Health details
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMedicalDetails")]
        [ProducesResponseType(typeof(MedicalDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMedicalDetails(string stu_id)
        {
            var result = await _ClassListService.GetMedicalDetails(stu_id);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("GetBehaviorDetail")]
        [ProducesResponseType(typeof(IEnumerable<BehaviorDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBehaviorDetail(long STU_ID)
        {
            var result = await _ClassListService.GetBehaviorDetail(STU_ID);
            return Ok(result);
        }


        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 20/Aug-2019
        /// Description: To get the student DashboardDetails in Profile
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStudentDashboardDetails")]
        [ProducesResponseType(typeof(StudentDashboardDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentDashboardDetails(string stu_id)
        {
            var result = await _ClassListService.GetStudentDashboardDetails(stu_id);
            return Ok(result);
        }


        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 20/Aug-2019
        /// Description: To get the student Activity list
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetActivitiesDetails")]
        [ProducesResponseType(typeof(ActivitiesDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetActivitiesDetails(string stu_id)
        {
            var result = await _ClassListService.GetActivitiesDetails(stu_id);
            return Ok(result);
        }

        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 20/Aug-2019
        /// Description: To get the student Attendance Chart
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAttendanceChart")]
        [ProducesResponseType(typeof(AttendanceChart), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAttendanceChart(string stu_id)
        {
            var result = await _ClassListService.GetAttendanceChart(stu_id);
            return Ok(result);
        }

        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 21/Aug-2019
        /// Description: To get the student AssessmentDetails
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAssessmentDetails")]
        [ProducesResponseType(typeof(AssessmentDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssessmentDetails(string stu_id)
        {
            var result = await _ClassListService.GetAssessmentDetails(stu_id);
            return Ok(result);
        }

        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 22/Aug-2019
        /// Description: To get the student AttendenceList
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAttendenceList")]
        [ProducesResponseType(typeof(AttendenceList), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAttendenceList(string stu_id,DateTime EndDate)
        {
            var result = await _ClassListService.GetAttendenceList(stu_id, EndDate);
            return Ok(result);
        }

        [HttpPost]
        [Route("StudentOnReportMasterCU")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> StudentOnReportMasterCU(StudentOnReportMaster studentOnReportMaster)
        {
            var result = await _ClassListService.StudentOnReportMasterCU(studentOnReportMaster);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetStudentOnReportMasters")]
        [ProducesResponseType(typeof(IEnumerable<StudentOnReportMaster>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentOnReportMasters(long studentId, long academicYearId, long schoolId)
        {
            var result = await _ClassListService.GetStudentOnReportMasters(studentId, academicYearId, schoolId);
            return Ok(result);
        }

        [HttpPost]
        [Route("StudentOnReportDetailsCU")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> StudentOnReportDetailsCU(StudentOnReportDetail studentOnReportDetail)
        {
            var result = await _ClassListService.StudentOnReportDetailsCU(studentOnReportDetail);
            return Ok(result);
        }


        [HttpPost]
        [Route("GetStudentOnReportDetails")]
        [ProducesResponseType(typeof(IEnumerable<StudentOnReportDetail>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentOnReportDetails(StudentOnReportDetailsParameter detailsParameter)
        {
            var result = await _ClassListService.GetStudentOnReportDetails(detailsParameter);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetStudentPhotoPath")]
        [ProducesResponseType(typeof(IEnumerable<ClassList>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentPhotoPath(string BSU_ID, long RPF_ID,[FromBody] string STU_ID)
        {
            var result = await _ClassListService.GetStudentPhotoPath(BSU_ID,RPF_ID,STU_ID);
            return Ok(result);
        }
    }
}