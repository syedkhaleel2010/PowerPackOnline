using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using PowerPack.Common.Models;
using PowerPack.Common.ViewModels;
using PowerPack.Models;
using SIMS.API.Models;

namespace SIMS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IEmailSettingsService _emailSettingsService;
        private readonly ICommonSettingService commonSettingService;

        public CommonController(IEmailSettingsService EmailSettingsService, ICommonSettingService commonSettingService)
        {
            _emailSettingsService = EmailSettingsService;
            this.commonSettingService = commonSettingService;
        }
        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 11 june 2019
        /// Description - To get email settings.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getEmailSettings")]
        [ProducesResponseType(typeof(EmailSettingsView), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetEmailSettings()
        {
            var modelList = await _emailSettingsService.GetEmailSettings();
            return Ok(modelList);
        }
        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 11 june 2019
        /// Description - To Get School Current Language settings.
        /// </summary>
        /// <param name="SchoolId">School Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getSchoolCurrentLanguage")]
        [ProducesResponseType(typeof(SystemLanguage), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSchoolCurrentLanguage(int SchoolId)
        {
            var modelList = await _emailSettingsService.GetSchoolCurrentLanguage(SchoolId);
            return Ok(modelList);
        }
        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 11 june 2019
        /// Description - To set School Current Language settings.
        /// </summary>
        /// <param name="languageId">language Id</param>
        /// <param name="schoolId">school Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("setSchoolCurrentLanguage")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult SetSchoolCurrentLanguage(int languageId,int schoolId)
        {
            var modelList = _emailSettingsService.SetSchoolCurrentLanguage(languageId,schoolId);
            return Ok(modelList);
        }

        [HttpPost]
        [Route("OperationAuditCU")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult OperatioAuditCU(OperationAudit operationAudit)
        {
            var result = commonSettingService.OperationDetailsCU(operationAudit);
            return Ok(result);
        }
    }
}