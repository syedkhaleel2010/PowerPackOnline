using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIMS.API.Models;
using SIMS.API.Services;

namespace SIMS.API.Areas.CommonSettings.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchoolSetupsController : ControllerBase
    {
        private readonly ISchoolSetupsServices commonSettingServices;

        public SchoolSetupsController(ISchoolSetupsServices commonSettingServices)
        {
            this.commonSettingServices = commonSettingServices;
        }
        #region Assessment Term
        [HttpPost]
        [Route("AssessmentTermCUD")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AssessmentTermCUD(AssessmentTerm assessmentTerm)
        {
            var result = await commonSettingServices.AssessmentTermCUD(assessmentTerm);
            return Ok(result);
        }
        #endregion

        #region Terminology
        [HttpGet]
        [Route("GetTerminologyLable")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTerminologyLable(long academicId, long schoolId,int CLM_ID, string langCode, int divisionId)
        {
            var result = await commonSettingServices.GetTerminologyLable(academicId, schoolId, CLM_ID, langCode, divisionId);
            return Ok(result);
        }

        [HttpPost]
        [Route("TerminologyCU")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> TerminologyCU(TerminologyCU terminologyCU)
        {
            var result = await commonSettingServices.TerminologyCU(terminologyCU);
            return Ok(result);
        }
        #endregion

        #region Academic Terms
        [HttpGet]
        [Route("GetAcademicTerms")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAcademicTerms(long BSU_ID, long ACD_ID, long BSU_CLM_ID, int? divisionId = null)
        {
            var result = await commonSettingServices.GetAcademicTerms(BSU_ID, ACD_ID, BSU_CLM_ID, divisionId);
            return Ok(result);
        }

        [HttpPost]
        [Route("AcademicTermsCUD")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AcademicTermsCUD(AcademicTerms AcademicTerms)
        {
            var result = await commonSettingServices.AcademicTermsCUD(AcademicTerms);
            return Ok(result);
        }
        #endregion

        #region Grade Display
        [HttpGet]
        [Route("GetGradeDisplay")]
        [ProducesResponseType(typeof(IEnumerable<GradeDisplay>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradeDisplay(long academicId, long schoolId)
        {
            var result = await commonSettingServices.GradeDisplay(academicId, schoolId);
            return Ok(result);
        }

        [HttpPost]
        [Route("GradeDisplayU")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GradeDisplayU(GradeDisplayU gradeDisplayU)
        {
            var result = await commonSettingServices.GradeDisplayU(gradeDisplayU);
            return Ok(result);
        }
        #endregion

    }
}