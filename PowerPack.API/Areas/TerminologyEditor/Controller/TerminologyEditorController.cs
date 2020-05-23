using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using PowerPack.Common.Models;

namespace SIMS.API.Areas.TerminologyEditor.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TerminologyEditorController : ControllerBase
    {
        private readonly ITerminologyEditorService _terminologyEditorService;

        public TerminologyEditorController(ITerminologyEditorService terminologyEditorService)
        {
            _terminologyEditorService = terminologyEditorService;
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 1 July 2019
        /// Description - To insert TerminologyEditors
        /// </summary>
        /// <param name="terminologyEditorView"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TerminologyEditorInsert")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> TerminologyEditorInsert([FromBody]TerminologyEditorView terminologyEditorView)
        {
            var result = _terminologyEditorService.TerminologyEditorInsert(terminologyEditorView);
            return Ok(result);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 1 July 2019
        /// Description - To Update TerminologyEditors
        /// </summary>
        /// <param name="terminologyEditorView"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TerminologyEditorUpdate")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> TerminologyEditorUpdate([FromBody]TerminologyEditorView terminologyEditorView)
        {
            var result = _terminologyEditorService.TerminologyEditorUpdate(terminologyEditorView);
            return Ok(result);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 1 July 2019
        /// Description - To get all TerminologyEditor.
        /// </summary>
        /// <param name="id"> Id</param>
        /// <param name="schoolId">School Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getTerminologyEditor")]
        [ProducesResponseType(typeof(IEnumerable<TerminologyEditorView>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTerminologyEditor(int? id,long schoolId)
        {
            var terminologyEditorList = await _terminologyEditorService.GetTerminologyEditor(id,schoolId);
            return Ok(terminologyEditorList);
        }
        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 1 July 2019
        /// Description - To get all TerminologyEditor.
        /// </summary>
        /// <param name="schoolId">School Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllTerminologyEditor")]
        [ProducesResponseType(typeof(IEnumerable<TerminologyEditorView>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getAllTerminologyEditor(long schoolId)
        {
            var terminologyEditorList = await _terminologyEditorService.GetAllTerminologyEditor(schoolId);
            return Ok(terminologyEditorList);
        }
        
        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 2 July 2019
        /// Description - To Delete TerminologyEditors
        /// </summary>
        /// <param name="terminologyEditorView"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TerminologyEditorDelete")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> TerminologyEditorDelete([FromBody]TerminologyEditorView terminologyEditorView)
        {
            var result = _terminologyEditorService.TerminologyEditorDelete(terminologyEditorView);
            return Ok(result);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 3 July 2019
        /// Description - To check existance of old term
        /// </summary>
        /// <param name="term"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("checkForTerminology")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CheckForTerminology(string term,int id)
        {
            var result = _terminologyEditorService.CheckForTerminology(term,id);
            return Ok(result);
        }

    }
}