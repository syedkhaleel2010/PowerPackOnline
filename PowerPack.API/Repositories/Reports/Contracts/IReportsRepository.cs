using DbConnection;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace SIMS.API.Repositories
{
    public interface IReportsRepository
    {
        Task<IEnumerable<ReportDesigner>> LoadDesignedReports(string BSU_ID, string ModuleId);
        Task<Reports> GetReportLayoutById(string Dev_Id);

        Task<IEnumerable<ReportBinder>> BindReportFilters(long RDSR_ID, string RDF_FILTER_CODE, string FILTER_PARAMS);

        Task<IEnumerable<ReportFilterControls>> GetReportFiltersType();

        Task<IEnumerable<ReportTypes>> GetReportTypes();

        Task<IEnumerable<dynamic>> GetDatasetForSp(string sp_Name,string filterparam,string loadType);
        Task<ReportSetup> GetDevIdFromRSM_ID(int RSM_ID);

        Task<IEnumerable<ReportTopHeader>> GetReportTopHeaders(string IMG_BSU_ID, string IMG_TYPE);


        Task<IEnumerable<ReportDesignerDBDetails>> GetReportDesignerDbSet(string MODULE_ID, long AcademicYearId, string SchoolId);

       bool SaveReportDesigner(string RDSR_MODULE, string RDSR_DATASET_ID, string RDSR_FILTER_TYPES, string RDSR_BSU_ID, int Id, string REPORT_NAME, Byte[] REPORT_LAYOUT);

       Task<IEnumerable<Report>> LoadReportsList(int UserID,int RoleID,long schoolID);
        Task<IEnumerable<CrystalReportDesigner>> LoadCurriculumReportFormControls(int ReportID);

        Task<IEnumerable<CrystalDesignerFilters>> LoadCrystalDesignerFitlers(string FilterArray);
        Task<IEnumerable<ReportBinderModel>> BindCrystalReportFilters(long RDSR_ID, string RDF_FILTER_CODE, string FILTER_PARAMS,string Is_SuperUser="");
        Task<ReportPathModel> GetCrystalReportPath(long RPT_ID, string Fetch_SP, string BSU_ID, CurriculumModel CurriculumModel);
        Task<string> GetConsolidatedReportExcel(long RPT_ID, string Fetch_SP, string BSU_ID, CurriculumModel CurriculumModel);


    }
}
