using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using PowerPack.Common.Models;

namespace SIMS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _GradeService;
        private readonly ICurriculumRoleService _curriculumRoleService;

        public GradesController(IGradeService Grade_Service, ICurriculumRoleService curriculumRoleService)
        {
            _GradeService = Grade_Service;
            _curriculumRoleService = curriculumRoleService;
        }

        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 27/May/2019
        /// Description: To get Grades list from Grades master table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getGrades")]
        [ProducesResponseType(typeof(IEnumerable<Grades>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGrades()
        {
            var result = await _GradeService.GetGrades();
            return Ok(result);
        }

        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 27/May/2019
        /// Description: To get Grades list from Grades master table
        /// </summary>
        /// <param name="id">acd id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getGradesByAcd")]
        [ProducesResponseType(typeof(Grades), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradesByACD(int id)
        {
            var result = await _GradeService.GetGradesByACD(id);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 28/May/2019
        /// Description: To get Sections list from Sections master table
        /// </summary>
        /// <param name="id">grd id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSectionsByGrade")]
        [ProducesResponseType(typeof(Sections), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSectionsByGrade(int id)
        {
            var result = await _GradeService.GetSectionsByGrade(id);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 05/Aug/2019
        /// Description: To get Grades access for a particular user
        /// </summary>
        /// <param name="id">grd id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetGradesAccess")]
        [ProducesResponseType(typeof(GradesAccess), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradesAccess(string username, string isSuperUser, Int32 acd_id, Int32 bsu_id, int grd_access, Int32 rsm_id, int divisionId = 0)
        {
            var result = await _GradeService.GetGradesAccess(username, isSuperUser, acd_id, bsu_id, grd_access, rsm_id, divisionId);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 05/Aug/2019
        /// Description: To get Subjects for particular grade
        /// </summary>
        /// <param name="id">grd id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSubjectsByGrade")]
        [ProducesResponseType(typeof(GradesAccess), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectsByGrade(Int32 acd_id, string grd_id,string username="",string IsSuperUser="")
        {
            var result = await _GradeService.GetSubjectsByGrade(acd_id,grd_id, username, IsSuperUser);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 05/Aug/2019
        /// Description: To get Subjects for particular grade
        /// </summary>
        /// <param name="id">grd id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSubjectGroupBySubject")]
        [ProducesResponseType(typeof(SubjectGroups), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult>  GetSubjectGroupBySubject(string username, string isSuperUser, Int32 bsu_id, string grd_id, Int32 sbg_id)
        {
            var result = await _GradeService.GetSubjectGroupBySubject(username, isSuperUser, bsu_id, grd_id, sbg_id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUserCurriculumRole")]
        [ProducesResponseType(typeof(SIMS.API.Models.CurriculumRole), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserCurriculumRole(string BSU_ID = "", string UserName = "")
        {
            var result = await _curriculumRoleService.GetUserCurriculumRole(BSU_ID, UserName);
            return Ok(result);
        }

        [HttpGet]
        [Route("getselectlistitems")]
        [ProducesResponseType(typeof(IEnumerable<ListItem>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSelectListItems(string listCode, string whereCondition, string whereConditionParamValues)
        {
            var result = await _GradeService.GetSelectListItems(listCode, whereCondition, whereConditionParamValues);
            return Ok(result);
        }

        [HttpGet]
        [Route("getacademicyearitems")]
        [ProducesResponseType(typeof(IEnumerable<ListItem>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAcademicYearLists(string schoolId, int curriculumId, bool? IsCurrentCurriculum = null)
        {
            var result = await _GradeService.GetAcademicYearLists(schoolId, curriculumId, IsCurrentCurriculum);
            return Ok(result);
        }

        /// <summary>
        /// Created By: Ashwin Dubey
        /// Created On: 19/Nov/2019
        /// Description: To get Curriculum using BSU_ID
        /// </summary>
        /// <param name="BSU_ID">BSU_ID of which curriculum to set</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCurriculum")]
        [ProducesResponseType(typeof(SIMS.API.Models.CurriculumRole), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCurriculum(long schoolId, int? CLM_ID)
        {
            var result = await _curriculumRoleService.GetCurriculum(schoolId, CLM_ID);
            return Ok(result);
        }
    }
  
}