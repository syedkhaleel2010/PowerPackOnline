using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;


namespace SIMS.API.Areas.Division.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IDivisionService _divisionService;
        public DivisionController(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }
        [HttpPost]
        [Route("SaveDivisionDetails")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveDivisionDetails(DivisionDetails DivisionDetails, string DATAMODE)
        {
            var result = await _divisionService.SaveDivisionDetails(DivisionDetails, DATAMODE);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetDivisionDetails")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.DivisionDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDivisionDetails(long BSU_ID)
        {
            var result = await _divisionService.GetDivisionDetails(BSU_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetDivisionDetailsDropDown")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.DivisionDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDivisionDetails(long BSU_ID, long acdId, string isSuperUser, string username)
        {
            var result = await _divisionService.GetDivisionDetails(BSU_ID, acdId, isSuperUser, username);
            return Ok(result);
        }
    }
}