using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Areas.DashBoard.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _dashBoardService;

        public DashBoardController(IDashBoardService dashBoardService)
        {
            _dashBoardService = dashBoardService;
        }
        [HttpGet]
        [Route("GetDashbardLayoutBySchoolId")]
        [ProducesResponseType(typeof(IEnumerable<Dashboard>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDashbardLayoutBySchoolId(long SchoolId)
        {
            var result = await _dashBoardService.GetDashbardLayoutBySchoolId(SchoolId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDashBoardWidgetByLayoutId")]
        [ProducesResponseType(typeof(IEnumerable<SubCategories>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDashBoardWidgetByLayoutId(long layoutId, long SchoolId, long AcademicYearId, string UserRoleIds)
        {
            var result = await _dashBoardService.GetDashBoardWidgetByLayoutId(layoutId, SchoolId, AcademicYearId, UserRoleIds);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetStudentMetricsCountAttendance")]
        [ProducesResponseType(typeof(IEnumerable<StudentMetricsCountAttendance>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentMetricsCountAttendance(long SchoolId)
        {
            var result = await _dashBoardService.GetStudentMetricsCountAttendance(SchoolId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetBudgetPercentagePhysical")]
        [ProducesResponseType(typeof(IEnumerable<BudgetPercentagePhysical>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBudgetPercentagePhysical(long SchoolId)
        {
            var result = await _dashBoardService.GetBudgetPercentagePhysical(SchoolId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetStudentMetricsCount")]
        [ProducesResponseType(typeof(IEnumerable<StudentMetricsCount>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentMetricsCount(long SchoolId)
        {
            var result = await _dashBoardService.GetStudentMetricsCount(SchoolId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetFormTutorPoints")]
        [ProducesResponseType(typeof(IEnumerable<FormTutorPoints>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFormTutorPoints(long ACD_ID, long OPTION)
        {
            var result = await _dashBoardService.GetFormTutorPoints(ACD_ID, OPTION);
            return Ok(result);
        }
        [HttpPost]
        [Route("SetDashboardLayout")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> SetDashboardLayout( long SchoolId, long AcademicYearId, long UserId, string LayoutName, List<DashBoardLayout> objLayout)
        {
            var result = _dashBoardService.SetDashboardLayout( objLayout,  SchoolId,  AcademicYearId,  UserId,  LayoutName);
            return Ok(result);
        }

        [HttpGet]
        [Route("TotalPositiveNegative")]
        [ProducesResponseType(typeof(IEnumerable<TotalPositiveNegative>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> TotalPositiveNegative(long ACD_ID, long OPTION)
        {
            var result = await _dashBoardService.TotalPositiveNegative(ACD_ID, OPTION);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetGradeDetails")]
        [ProducesResponseType(typeof(IEnumerable<GetGradeDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradeDetails(string GRD_ID,long ACD_ID, long SchoolId)
        {
            var result = await _dashBoardService.GetGradeDetails(GRD_ID, ACD_ID, SchoolId);
            return Ok(result);
        }
        [HttpGet]
        [Route("FeeAgeing")]
        [ProducesResponseType(typeof(IEnumerable<FeeAgeing>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> FeeAgeing(long SchoolId)
        {
            var result = await _dashBoardService.FeeAgeing(SchoolId);
            return Ok(result);
        }
        [HttpGet]
        [Route("FeeOutstanding")]
        [ProducesResponseType(typeof(IEnumerable<FeeOutstanding>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> FeeOutstanding(long SchoolId, long OPTION)
        {
            var result = await _dashBoardService.FeeOutstanding(SchoolId, OPTION);
            return Ok(result);
        }
        [HttpGet]
        [Route("OverallHousePoints")]
        [ProducesResponseType(typeof(IEnumerable<OverallHousePoints>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> OverallHousePoints(long ACD_ID, long SchoolId)
        {
            var result = await _dashBoardService.OverallHousePoints(ACD_ID, SchoolId);
            return Ok(result);
        }
        [HttpGet]
        [Route("ProgressTrackerChart")]
        [ProducesResponseType(typeof(IEnumerable<ProgressTrackerChart>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ProgressTrackerChart(long ACD_ID)
        {
            var result = await _dashBoardService.ProgressTrackerChart(ACD_ID);
            return Ok(result);
        }

        [HttpPost]
        [Route("AssignRoleToDashboard")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AssignRoleToDashboard(long UserId,AssignDashboard objAssignDashboard)
        {
            var result = _dashBoardService.AssignRoleToDashboard(objAssignDashboard, UserId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllDashBoardWidget")]
        [ProducesResponseType(typeof(IEnumerable<DashboardWidgetList>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllDashBoardWidget(long ACD_ID)
        {
            var result = await _dashBoardService.GetAllDashBoardWidget();
            return Ok(result);
        }
        [HttpGet]
        [Route("AttendanceSummary")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceSummary>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AttendanceSummary(long ACD_ID, long SchoolId)
        {
            var result = await _dashBoardService.AttendanceSummary(ACD_ID, SchoolId);
            return Ok(result);
        }
    }
}