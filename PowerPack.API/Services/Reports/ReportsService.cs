using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMS.API.Models;
using SIMS.API.Repositories;

namespace SIMS.API.Services
{
    public class ReportsService : IReportsService
    {
        private IReportsRepository _reportsRepository;

        public ReportsService(IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;


        }
        public async Task<IEnumerable<ReportBinder>> BindReportFilters(long RDSR_ID, string RDF_FILTER_CODE, string FILTER_PARAMS)
        {
            return await _reportsRepository.BindReportFilters(RDSR_ID, RDF_FILTER_CODE, FILTER_PARAMS);
        }

        public async Task<IEnumerable<ReportFilterControls>> GetReportFiltersType()
        {
            return await _reportsRepository.GetReportFiltersType();
        }

        public async Task<Reports> GetReportLayoutById(string Dev_Id)
        {
            return await _reportsRepository.GetReportLayoutById(Dev_Id);
        }

     

        public async Task<IEnumerable<ReportDesigner>> LoadDesignedReports(string BSU_ID, string ModuleId)
        {

            return await _reportsRepository.LoadDesignedReports(BSU_ID, ModuleId);
        }

        public async Task<IEnumerable<ReportTypes>> GetReportTypes()
        {
            return await _reportsRepository.GetReportTypes();
        }

        public async Task<IEnumerable<dynamic>> GetDatasetForSp(string sp_Name, string filterparam, string loadType)
        {
            return await _reportsRepository.GetDatasetForSp(sp_Name, filterparam, loadType);
        }

        public async Task<ReportSetup> GetDevIdFromRSM_ID(int RSM_ID)
        {
             return await _reportsRepository.GetDevIdFromRSM_ID(RSM_ID);
        }

        public async Task<IEnumerable<ReportTopHeader>> GetReportTopHeaders(string IMG_BSU_ID, string IMG_TYPE)
        {
            return await _reportsRepository.GetReportTopHeaders(IMG_BSU_ID, IMG_TYPE);
        }

        public async Task<IEnumerable<ReportDesignerDBDetails>> GetReportDesignerDbSet(string MODULE_ID, long AcademicYearId, string SchoolId)
        {
            return await _reportsRepository.GetReportDesignerDbSet(MODULE_ID, AcademicYearId, SchoolId);
        }

        public bool SaveReportDesigner(string RDSR_MODULE, string RDSR_DATASET_ID, string RDSR_FILTER_TYPES, string RDSR_BSU_ID, int Id, string REPORT_NAME, byte[] REPORT_LAYOUT)
        {
            return  _reportsRepository.SaveReportDesigner(RDSR_MODULE, RDSR_DATASET_ID, RDSR_FILTER_TYPES, RDSR_BSU_ID, Id, REPORT_NAME, REPORT_LAYOUT);
        }

        #region Curriculum
        public async Task<IEnumerable<Report>> LoadReportsList(int UserID, int RoleID,long schoolID)
        {
            return await _reportsRepository.LoadReportsList(UserID, RoleID,schoolID);
        }

        public async Task<IEnumerable<CrystalReportDesigner>> LoadCurriculumReportFormControls(int ReportID)
        {

            return await _reportsRepository.LoadCurriculumReportFormControls(ReportID);
        }

            public async Task<IEnumerable<CrystalDesignerFilters>> LoadCrystalDesignerFitlers(string FilterArray)
            {
                return await _reportsRepository.LoadCrystalDesignerFitlers(FilterArray);
            }

        public async Task<IEnumerable<ReportBinderModel>> BindCrystalReportFilters(long RDSR_ID, string RDF_FILTER_CODE, string FILTER_PARAMS,string Is_SuperUser="")
        {
            return await _reportsRepository.BindCrystalReportFilters(RDSR_ID, RDF_FILTER_CODE, FILTER_PARAMS,Is_SuperUser);
        }
        public async Task<ReportPathModel> GetCrystalReportPath(long RPT_ID, string Fetch_SP,string BSU_ID, CurriculumModel CurriculumModel)
        {
            return await _reportsRepository.GetCrystalReportPath(RPT_ID, Fetch_SP,BSU_ID,CurriculumModel);
        }
        public async Task<string> GetConsolidatedReportExcel(long RPT_ID, string Fetch_SP, string BSU_ID, CurriculumModel CurriculumModel)
        {
            return await _reportsRepository.GetConsolidatedReportExcel(RPT_ID, Fetch_SP, BSU_ID, CurriculumModel);
        }


        #endregion
    }
}
