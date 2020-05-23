using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using PowerPack.Models;

namespace SIMS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ModuleStructureController : ControllerBase
    {
        private readonly IModuleStructureService _moduleStructureService;

        public ModuleStructureController(IModuleStructureService moduleStructureService)
        {
            _moduleStructureService = moduleStructureService;
        }

        /// <summary>
        /// Created By: Rohit Patil
        /// Created On: 07/May/2019
        /// Description: To get select list to bind the dropdown list
        /// </summary>       
        /// <returns></returns>
        [HttpGet]
        [Route("getPowerPackmodulestructure")]
        [ProducesResponseType(typeof(IEnumerable<ModuleStructure>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPowerPackModuleStructure(int systemLanguageId,
            int userId, string applicationCode, string traverseDirection, string moduleUrl, string moduleCode, bool excludeParent,
            string excludeModuleCodes, bool? showInMenu)
        {
            var result = await _moduleStructureService.GetPowerPackModuleStructure(systemLanguageId, userId, applicationCode, traverseDirection, moduleUrl,
                moduleCode, excludeParent, excludeModuleCodes, showInMenu);
            return Ok(result);
        }
    }
}