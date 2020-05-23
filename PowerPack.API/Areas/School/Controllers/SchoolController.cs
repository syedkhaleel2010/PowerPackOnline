using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using PowerPack.Models;

namespace SIMS.API.Areas.School.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
       
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
          
        }

    
     
        [HttpGet]
        [Route("getschoollist")]
        [ProducesResponseType(typeof(IEnumerable<SchoolInformation>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSchoolList()
        {
            var schoolList = await _schoolService.GetSchoolList();
            return Ok(schoolList);
        }


    
        [HttpGet]
        [Route("getadminschoollist")]
        [ProducesResponseType(typeof(IEnumerable<SchoolInformation>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAdminSchoolList()
        {
            var schoolList = await _schoolService.GetAdminSchoolList();
            return Ok(schoolList);
        }

     
        [HttpGet]
        [Route("getschoolbyid/{id:int}")]
        [ProducesResponseType(typeof(SchoolInformation), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSchoolById(int id)
        {
            var school = await _schoolService.GetSchoolById(id);
            return Ok(school);
        }
    }
}