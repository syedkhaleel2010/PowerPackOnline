using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Areas.SEN.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SENController : ControllerBase
    {
        private readonly ISENService _SENService;
        

        public SENController(ISENService SEN_Service)
        {
            _SENService = SEN_Service;
        }


        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 27/Aug-2019
        /// Description: To get the student Inclusion List
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get_studentInclusionList")]
        [ProducesResponseType(typeof(BasicDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get_studentInclusionList(string BSU_ID, string ACD_ID, string GRD_ID, string SCT_ID)
        {
            var result = await _SENService.Get_studentInclusionList(BSU_ID, ACD_ID, GRD_ID, SCT_ID);
            return Ok(result);
        }


        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 27/Aug-2019
        /// Description: To get the student Inclusion List
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get_studentInclusionAll")]
        [ProducesResponseType(typeof(BasicDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get_studentInclusionAll(string BSU_ID, string ACD_ID, string GRD_ID, string SCT_ID)
        {
            var result = await _SENService.Get_studentInclusionAll(BSU_ID, ACD_ID, GRD_ID, SCT_ID);
            return Ok(result);
        }

        // <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 27/Aug-2019
        /// Description: To insert the student Inclusion List
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>
        
        [HttpPost]
        [Route("InsertBulkSEN")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> InsertBulkSEN([FromBody] string stuIds)
        {
            var result = _SENService.InsertBulkSEN(stuIds);
            return Ok(result);
        }

        // <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 27/Aug-2019
        /// Description: To update the student Inclusion List
        /// <param name="stu_id">Student Id </param>
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("updateSenStudent")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> updateSenStudent(string stuId)
        {
            var result = _SENService.updateSenStudent(stuId);
            return Ok(result);
        }



        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 28/Aug-2019
        /// Description: To Get SEN_KHDA_MASTER LIST 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get_SEN_KHDA_MASTER")]
        [ProducesResponseType(typeof(SEN_KHDA_MASTER), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get_SEN_KHDA_MASTER()
        {
            var result = await _SENService.Get_SEN_KHDA_MASTER();
            return Ok(result);
        }

        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 28/Aug-2019
        /// Description: To Get Get_KHDA_STUDENT 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get_KHDA_STUDENT")]
        [ProducesResponseType(typeof(KHDA_STUDENT), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get_KHDA_STUDENT(string stuId)
        {
            var result = await _SENService.Get_KHDA_STUDENT(stuId);
            return Ok(result);
        }

        /// <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 28/Aug-2019
        /// Description: To Get Get_KHDA_STUDENT 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get_SEN_KHDA_TRANS_LIST")]
        [ProducesResponseType(typeof(SEN_KHDA_TRANS), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get_SEN_KHDA_TRANS_LIST(string stuId)
        {
            var result = await _SENService.Get_SEN_KHDA_TRANS_LIST(stuId);
            return Ok(result);
        }



        // <summary>
        /// Created By: Hrushikesh Phapale
        /// Created On: 31/Aug-2019
        /// Description: To insert the student KHDA form
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        [Route("SaveSENKHDA")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveSENKHDA([FromBody]KHDA mainModel, string uGUID,string filePath)
        {
            var result = _SENService.SaveSENKHDA(mainModel, uGUID, filePath);
            return Ok(result);
        }
    }
}