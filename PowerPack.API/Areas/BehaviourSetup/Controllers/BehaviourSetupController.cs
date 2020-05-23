using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.API.Models;
using SIMS.API.Services;

namespace SIMS.API.Areas.BehaviourSetup.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BehaviourSetupController : ControllerBase
    {
        private readonly IBehaviourSetupService behaviourSetupService;

        public BehaviourSetupController(IBehaviourSetupService behaviourSetupService)
        {
            this.behaviourSetupService = behaviourSetupService;
        }

        #region Behaviour Setup
        [HttpGet]
        [Route("GetSubCategoryList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.BehaviourSetup>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubCategoryList(long CategoryID, long BSU_ID)
        {
            var result = await behaviourSetupService.GetSubCategoryList(CategoryID, BSU_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveSubCategory")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveSubCategory(SIMS.API.Models.BehaviourSetup behaviourSetup, string DATAMODE)
        {
            var result = await behaviourSetupService.SaveSubCategory(behaviourSetup, DATAMODE);
            return Ok(result);
        }
        #endregion Behaviour Setup

        #region Action Hierarchy
        [HttpGet]
        [Route("GetDesignations")]
        [ProducesResponseType(typeof(IEnumerable<Designations>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDesignations(long schoolId)
        {
            var result = await behaviourSetupService.GetDesignations(schoolId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDesignationsRoutings")]
        [ProducesResponseType(typeof(IEnumerable<DesignationsRouting>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDesignationsRoutings(long schoolId, long? designationFrom = null)
        {
            var result = await behaviourSetupService.GetDesignationsRoutings(schoolId, designationFrom);
            return Ok(result);
        }

        [HttpPost]
        [Route("DesignationBySchoolCUD")]
        [ProducesResponseType(typeof(IEnumerable<DesignationsRouting>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DesignationBySchoolCUD(DesignationsRoutingCUD designationsRouting)
        {
            var result = await behaviourSetupService.DesignationBySchoolCUD(designationsRouting);
            return Ok(result);
        }
        #endregion

        #region Category Level
        [HttpGet]
        [Route("GetCategoryLevel")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.CategoryLevel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCategoryLevel(long SubCategoryID)
        {
            var result = await behaviourSetupService.GetCategoryLevel(SubCategoryID);
            return Ok(result);
        }
        #endregion
    }
}