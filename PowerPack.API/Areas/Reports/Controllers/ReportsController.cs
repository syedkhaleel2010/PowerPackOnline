using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Areas.Reports.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }


        [HttpPost]
        [Route("BindReportFilters")]
        [ProducesResponseType(typeof(IEnumerable<ReportBinder>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindReportFilters(long RDSR_ID, string RDF_FILTER_CODE, [FromBody] string FILTER_PARAMS ="")
        {
            var result = await _reportsService.BindReportFilters(RDSR_ID, RDF_FILTER_CODE, FILTER_PARAMS);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetReportFiltersType")]
        [ProducesResponseType(typeof(IEnumerable<ReportFilterControls>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportFiltersType()
        {
            var result = await _reportsService.GetReportFiltersType();
            return Ok(result);
        }


        [HttpGet]
        [Route("GetReportLayoutById")]
        [ProducesResponseType(typeof(SIMS.API.Models.Reports), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportLayoutById(string Dev_Id)
        {
            var result = await _reportsService.GetReportLayoutById(Dev_Id);
            return Ok(result);
        }


        [HttpGet]
        [Route("LoadDesignedReports")]
        [ProducesResponseType(typeof(IEnumerable<ReportDesigner>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoadDesignedReports(string BSU_ID, string ModuleId)
        {
            var result = await _reportsService.LoadDesignedReports(BSU_ID, ModuleId);
            return Ok(result);
        }



        [HttpGet]
        [Route("GetReportTypes")]
        [ProducesResponseType(typeof(IEnumerable<ReportTypes>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportTypes()
        {
            var result = await _reportsService.GetReportTypes();
            return Ok(result);
        }


        [HttpPost]
        [Route("GetDatasetForSp")]
    
        [ProducesResponseType(typeof(IEnumerable<dynamic>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDatasetForSp(string sp_Name, string loadType, [FromBody] string filterparam)
        {
            var result = await _reportsService.GetDatasetForSp(sp_Name, filterparam, loadType);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDevIdFromRSM_ID")]
        [ProducesResponseType(typeof(ReportSetup), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDevIdFromRSM_ID(int RSM_ID)
        {
            var result = await _reportsService.GetDevIdFromRSM_ID(RSM_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetReportTopHeaders")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.ReportTopHeader>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportTopHeaders(string IMG_BSU_ID, string IMG_TYPE)
        {
            var result = await _reportsService.GetReportTopHeaders(IMG_BSU_ID, IMG_TYPE);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetReportDesignerDbSet")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.ReportDesignerDBDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportDesignerDbSet(string MODULE_ID, long AcademicYearId, string SchoolId)
        {
            var result = await _reportsService.GetReportDesignerDbSet(MODULE_ID,  AcademicYearId,  SchoolId);
            return Ok(result);
        }


        [HttpPost]
        [Route("SaveReportDesigner")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveReportDesigner(string RDSR_MODULE, string RDSR_DATASET_ID, string RDSR_BSU_ID,[FromBody]ReportLayoutBody objReportLayout )
        {
            var result =  _reportsService.SaveReportDesigner( RDSR_MODULE,  RDSR_DATASET_ID, objReportLayout.RDSR_FILTER_TYPES,  RDSR_BSU_ID, objReportLayout.DevId, objReportLayout.REPORT_NAME, objReportLayout.REPORT_LAYOUT);
            return Ok(result);
        }

        #region Curriculum

        [HttpGet]
        [Route("LoadReportsList")]
        [ProducesResponseType(typeof(IEnumerable<ReportDesigner>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoadReportsList(int UserID, int RoleID, long schoolID)
        {
            var result = await _reportsService.LoadReportsList(UserID, RoleID,  schoolID);
            return Ok(result);
        }

        [HttpGet]
        [Route("LoadCurriculumReportFormControls")]
        [ProducesResponseType(typeof(IEnumerable<CrystalReportDesigner>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoadCurriculumReportFormControls(int ReportID)
        {
            var result = await _reportsService.LoadCurriculumReportFormControls(ReportID);
            return Ok(result);
        }

        [HttpGet]
        [Route("LoadCrystalDesignerFitlers")]
        [ProducesResponseType(typeof(IEnumerable<CrystalReportDesigner>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoadCrystalDesignerFitlers(string FilterArray)
        {
            var result = await _reportsService.LoadCrystalDesignerFitlers(FilterArray);
            return Ok(result);
        }

        [HttpPost]
        [Route("BindCrystalReportFilters")]
        [ProducesResponseType(typeof(IEnumerable<ReportBinder>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindCrystalReportFilters(long RDSR_ID, string RDF_FILTER_CODE, [FromBody] string FILTER_PARAMS = "",string Is_SuperUser="")
        {
            var result = await _reportsService.BindCrystalReportFilters(RDSR_ID, RDF_FILTER_CODE, FILTER_PARAMS,Is_SuperUser);
            return Ok(result);
        }
        //GetCrystalReportPath
        [HttpPost]
        [Route("GetCrystalReportPath")]
        [ProducesResponseType(typeof(ReportPathModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCrystalReportPath(long RPT_ID, string Fetch_SP,string BSU_ID="", [FromBody] CurriculumModel CurriculumModel=null)
        {
            var result = await _reportsService.GetCrystalReportPath(RPT_ID, Fetch_SP, BSU_ID,CurriculumModel);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetConsolidatedReportExcel")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetConsolidatedReportExcel(long RPT_ID, string Fetch_SP, string BSU_ID = "", [FromBody] CurriculumModel CurriculumModel = null)
        {
            var result = await _reportsService.GetConsolidatedReportExcel(RPT_ID, Fetch_SP, BSU_ID, CurriculumModel);
            return Ok(result);
        }
        #endregion


    }
}