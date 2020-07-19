using Microsoft.AspNetCore.Mvc;
using PowerPack.API.Services;
using PowerPack.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;


namespace PowerPack.API.Areas.Sample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _SampleService;
        public SampleController(ISampleService SampleService)
        {
            _SampleService = SampleService;
        }
        //[HttpPost]
        //[Route("SaveSampleDetails")]
        //[ProducesResponseType((int)HttpStatusCode.Created)]
        //public async Task<IActionResult> SaveSampleDetails(SampleDetails SampleDetails, string DATAMODE)
        //{
        //    var result = await _SampleService.SaveSampleDetails(SampleDetails, DATAMODE);
        //    return Ok(result);
        //}
        [HttpGet]
        [Route("GetSampleDetails")]
        [ProducesResponseType(typeof(IEnumerable<PowerPack.API.Models.SampleDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSampleDetails(long BSU_ID)
        {
            var result = await _SampleService.GetSampleDetails(BSU_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetSampleDetailsDropDown")]
        [ProducesResponseType(typeof(IEnumerable<PowerPack.API.Models.SampleDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSampleDetails(long BSU_ID, long acdId, string isSuperUser, string username)
        {
            var result = await _SampleService.GetSampleDetails(BSU_ID, acdId, isSuperUser, username);
            return Ok(result);
        }
    }
}