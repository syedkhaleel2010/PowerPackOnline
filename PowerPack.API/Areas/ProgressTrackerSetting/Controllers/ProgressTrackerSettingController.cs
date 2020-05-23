using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Xml.Linq;
using PowerPack.Common.Enums;
using System.Data;

namespace SIMS.API.Areas.ProgressTrackerSetting.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProgressTrackerSettingController : ControllerBase
    {
        private readonly IProgressTrackerSettingService _ProgressTrackerSettingService;
        private const string Add = "ADD";
        private const string Edit = "EDIT";
        private const string Delete = "DELETE";
        public ProgressTrackerSettingController(IProgressTrackerSettingService ProgressTrackerSettingService)
        {
            _ProgressTrackerSettingService = ProgressTrackerSettingService;
        }

        #region Made By Dhanaji
        #region Upload Objective
        [HttpPost]
        [Route("BulkUploadObjective")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> BulkUploadObjective(UploadObjectiveModel uploadObjectiveModel)
        {
            var result = await _ProgressTrackerSettingService.BulkUploadObjective(uploadObjectiveModel);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetTopicDetailList")]
        [ProducesResponseType(typeof(IEnumerable<TopicDetail>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTopicDetailList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID, long SYD_ID)
        {
            var result = await _ProgressTrackerSettingService.GetTopicDetailList(BSU_ID, ACD_ID, TRM_ID, GRD_ID, SBG_ID, SYD_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetTopicObjectiveList")]
        [ProducesResponseType(typeof(IEnumerable<TopicObjective>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTopicObjectiveList(long SYD_ID)
        {
            var result = await _ProgressTrackerSettingService.GetTopicObjectiveList(SYD_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetTopicParentList")]
        [ProducesResponseType(typeof(IEnumerable<TopicParent>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTopicParentList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID)
        {
            var result = await _ProgressTrackerSettingService.GetTopicParentList(BSU_ID, ACD_ID, TRM_ID, GRD_ID, SBG_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddEditTopicDetails")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddEditTopicDetails(TopicDetail topicDetail, string DATAMODE)
        {
            var result = await _ProgressTrackerSettingService.AddEditTopicDetails(topicDetail, DATAMODE);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddEditTopicObjective")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddEditTopicObjective(TopicObjective topicObjective, string DATAMODE)
        {
            var result = await _ProgressTrackerSettingService.AddEditTopicObjective(topicObjective, DATAMODE);
            return Ok(result);
        }
        #endregion 
        #endregion
    }
}