using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Xml.Linq;

namespace SIMS.API.Areas.ProgressTracker.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProgressTrackerController : ControllerBase
    {
        private readonly IProgressTrackerService _progressTrackerService;

        public ProgressTrackerController(IProgressTrackerService progressTrackerService)
        {
            _progressTrackerService = progressTrackerService;

        }

        [HttpGet]
        [Route("HAS_STEPS")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> HAS_STEPS(long BSU_ID, long ACD_ID, string GRD_ID)
        {
            var result = _progressTrackerService.HAS_STEPS(BSU_ID, ACD_ID, GRD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("HAS_AgeBand")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> HAS_AgeBand(long BSU_ID, long ACD_ID, string GRD_ID)
        {
            var result = _progressTrackerService.HAS_AgeBand(BSU_ID, ACD_ID, GRD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("BindSteps")]
        [ProducesResponseType(typeof(IEnumerable<BindSteps>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindSteps(long ACD_ID, string GRD_ID, long SBG_ID, string SYD_ID)
        {
            var result = await _progressTrackerService.BindSteps(ACD_ID, GRD_ID, SBG_ID, SYD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("BindTopicTree")]
        [ProducesResponseType(typeof(IEnumerable<TopicTree>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindTopicTree(long TRM_ID, long SBG_ID)
        {
            var result = await _progressTrackerService.BindTopicTree(TRM_ID, SBG_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("BindSubTerm")]
        [ProducesResponseType(typeof(IEnumerable<SubTerms>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindSubTerm(long BSU_ID, long ACD_ID)
        {
            var result = await _progressTrackerService.BindSubTerm(BSU_ID, ACD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GET_PROGRESS_TRACKER_HEADERS")]
        [ProducesResponseType(typeof(IEnumerable<ProgressTrackerHeader>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GET_PROGRESS_TRACKER_HEADERS(long SBG_ID, string TOPIC_ID, long AGE_BAND_ID, string STEPS, long TSM_ID)
        {
            var result = await _progressTrackerService.GET_PROGRESS_TRACKER_HEADERS(SBG_ID, TOPIC_ID, AGE_BAND_ID, STEPS, TSM_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GET_PROGRESS_TRACKER_DATA")]
        [ProducesResponseType(typeof(IEnumerable<ProgressTrackerData>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GET_PROGRESS_TRACKER_DATA(long SBG_ID, string TOPIC_ID, long TSM_ID, long SGR_ID)
        {
            var result = await _progressTrackerService.GET_PROGRESS_TRACKER_DATA(SBG_ID, TOPIC_ID, TSM_ID, SGR_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("BindProgressTrackerDropdown")]
        [ProducesResponseType(typeof(IEnumerable<ProgressTrackerDropdown>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindProgressTrackerDropdown(long BSU_ID, string GRD_ID)
        {
            var result = await _progressTrackerService.BindProgressTrackerDropdown(BSU_ID, GRD_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveProgressTrackerData")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveProgressTrackerData(XElement STC_XML, int ACD_ID, string GRD_ID, int SBG_ID, DateTime STC_UPDATEDATE, string STC_USER, int SYD_ID)
        {

            var result = _progressTrackerService.SaveProgressTrackerData(ACD_ID, GRD_ID, SBG_ID, STC_XML, STC_UPDATEDATE, STC_USER, SYD_ID);
            return Ok(result);

        }

        [HttpGet]
        [Route("PivotGridList")]
        [ProducesResponseType(typeof(IEnumerable<PivotGrid>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PivotGridList(int acdId)
        {
            var result = await _progressTrackerService.PivotGridList(acdId);
            return Ok(result);
        }



        [HttpPost]
        [Route("SaveProgressAssessmentSetting")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveProgressAssessmentSetting(long DAM_ID, string DAM_DESCR, string DAM_GRD_IDS, string DAM_BSU_ID, long DAM_ACD_ID, string DATAMODE, bool DAM_ShowCodeAsHeader, bool DAM_ShowAsDropdown, List<ProgressTrackerSettingDetails> objDescriptorData)
        {
            var result = _progressTrackerService.SaveProgressAssessmentSetting(DAM_ID, DAM_DESCR, DAM_GRD_IDS, DAM_BSU_ID, DAM_ACD_ID, DATAMODE, DAM_ShowCodeAsHeader, DAM_ShowAsDropdown, objDescriptorData);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetProgressTrackerMasterSetting")]
        [ProducesResponseType(typeof(IEnumerable<ProgressTrackerSettingMaster>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProgressTrackerMasterSetting(string acdId)
        {
            var result = await _progressTrackerService.GetProgressTrackerMasterSetting(acdId);
            return Ok(result);
        }
        [HttpGet]
        [Route("BindProgressTrackerMasterSetting")]
        [ProducesResponseType(typeof(ProgressTrackerSettingMaster), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindProgressTrackerMasterSetting(long ACD_ID, long BSU_ID, string GRD_ID)
        {
            var result = await _progressTrackerService.BindProgressTrackerMasterSetting(ACD_ID, BSU_ID, GRD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProgressTrackerDetailSetting")]
        [ProducesResponseType(typeof(IEnumerable<ProgressTrackerSettingDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProgressTrackerDetailSetting(long DAM_ID, string DAM_TYPE)
        {
            var result = await _progressTrackerService.GetProgressTrackerDetailSetting(DAM_ID, DAM_TYPE);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetPTExceptionSetting")]
        [ProducesResponseType(typeof(IEnumerable<PTExpectationDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPTExceptionSetting(int DAM_ID)
        {
            var result = await _progressTrackerService.GetPTExceptionSetting(DAM_ID);
            return Ok(result);
        }


        [HttpPost]
        [Route("AddEditExpectationDetails")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddEditExpectationDetails(int DAM_ID, [FromBody] PTExpectationSaver objExpectationSaver)
        {

            var result = _progressTrackerService.AddEditExpectationDetails(DAM_ID, objExpectationSaver.objExpectation, objExpectationSaver.objDeleteExpectation);
            return Ok(result);

        }

        [HttpGet]
        [Route("BindSubjectMasterByGrade")]
        [ProducesResponseType(typeof(IEnumerable<PTSubjectMaster>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindSubjectMasterByGrade(int ACD_ID, string BSU_ID, string GRD_ID)
        {
            var result = await _progressTrackerService.BindSubjectMasterByGrade(ACD_ID, BSU_ID, GRD_ID);
            return Ok(result);
        }


    }

}