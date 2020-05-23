using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerPack.Common;
using SIMS.API.Models.CertificateBuilder;
using SIMS.API.Services.CertificateBuilder.Contracts;

namespace SIMS.API.Areas.CertificateBuilder.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CertificateBuilderController : ControllerBase
    {
        private readonly ICertificateBuilderService certificateBuilderService;

        public CertificateBuilderController(ICertificateBuilderService certificateBuilderService)
        {
            this.certificateBuilderService = certificateBuilderService;
        }

        [HttpGet]
        [Route("GetTemplatesBySchoolId")]
        [ProducesResponseType(typeof(IEnumerable<Template>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTemplatesBySchoolId(long schoolId, string userId, bool isActive, string TemplateType, int? status, int divisionId = 0)
        {
            var result = await certificateBuilderService.GetTemplatesBySchoolId(schoolId, userId, isActive, TemplateType, status,divisionId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetTemplateFieldData")]
        [ProducesResponseType(typeof(IEnumerable<TemplateFieldMapping>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTemplateFieldData(int templateId, long studentId)
        {
            var result = await certificateBuilderService.GetTemplateFieldData(templateId, studentId);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetTemplateFieldData")]
        [ProducesResponseType(typeof(IEnumerable<TemplateFieldMapping>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetTemplateFieldData(int templateId, List<long> studentId)
        {
            List<TemplateFieldMapping> result = new List<TemplateFieldMapping>();
            studentId.ForEach(student =>
            {
                var list = certificateBuilderService.GetTemplateFieldData(templateId, student).Result;
                list.ToList().ForEach(a => a.UserId = student);
                result.AddRange(list);
            });
            return Ok(result);
        }

        [HttpGet]
        [Route("GetTemplateDetail")]
        [ProducesResponseType(typeof(Template), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTemplateDetail(int? templateId, int? schoolId, string templateType, string period, string userId, bool? isActive, bool? includeTemplateField, int divisionId)
        {
            var result = await certificateBuilderService.GetTemplateDetail(templateId, schoolId, templateType, period, userId, isActive, includeTemplateField, divisionId);
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveTemplateImageData")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SaveTemplateImageData([FromBody]Template templateModel)
        {
            bool result = await certificateBuilderService.SaveTemplateImageData(templateModel);
            return Ok(result);
        }


        [HttpPost]
        [Route("AddTemplate")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddTemplate([FromBody]Template template)
        {
            var result = await certificateBuilderService.Insert(template);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateTemplate")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateTemplate([FromBody]Template template)
        {
            var result = await certificateBuilderService.Update(template);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteTemplate")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteTemplate(int id, string deletedBy)
        {
            var result = await certificateBuilderService.Delete(id, deletedBy);
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveCertificateAssignedColumns")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SaveCertificateAssignedColumns([FromBody]IEnumerable<TemplateField> fieldList)
        {
            bool result = await certificateBuilderService.SaveCertificateAssignedColumns(fieldList);
            return Ok(result);
        }
    }
}