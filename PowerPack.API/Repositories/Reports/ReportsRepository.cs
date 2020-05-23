using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
namespace SIMS.API.Repositories
{
    public class ReportsRepository : SqlRepository<Reports>, IReportsRepository
    {
        private readonly IConfiguration _config;

        public ReportsRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }
        public async Task<IEnumerable<ReportBinder>> BindReportFilters(long RDSR_ID, string RDF_FILTER_CODE, string FILTER_PARAMS)
        {

            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RDSR_ID", RDSR_ID, DbType.Int64);
                parameters.Add("@RDF_FILTER_CODE", RDF_FILTER_CODE, DbType.String);
                parameters.Add("@FILTER_PARAMS", FILTER_PARAMS, DbType.String);
                return await conn.QueryAsync<ReportBinder>("SIMS.BindReportFilters", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ReportFilterControls>> GetReportFiltersType()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<ReportFilterControls>("SIMS.GetReportFiltersType", null, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<Reports> GetReportLayoutById(string Dev_Id)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DEV_ID", Dev_Id, DbType.String);
                return await conn.QueryFirstOrDefaultAsync<Reports>("SIMS.GetReportLayoutById", parameters, null, null, CommandType.StoredProcedure);
            }
        }



        public async Task<IEnumerable<ReportDesigner>> LoadDesignedReports(string BSU_ID, string ModuleId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.String);
                parameters.Add("@MODULE_ID", ModuleId, DbType.String);
                return await conn.QueryAsync<ReportDesigner>("SIMS.LoadDesignedReports", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ReportTypes>> GetReportTypes()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<ReportTypes>("SIMS.GetSIMSReportType", null, null, null, CommandType.StoredProcedure);
            }
        }




        public override void InsertAsync(Reports entity)
        {
            throw new NotImplementedException();
        }
        public override void UpdateAsync(Reports entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Reports>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Reports> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<dynamic>> GetDatasetForSp(string sp_Name, string filterparam, string loadType)
        {
            var sproc = sp_Name;
            var LoadType = loadType;//"Viewer";
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@LOAD_TYPE", LoadType, DbType.String);
                parameters.Add("@PARAMS", filterparam, DbType.String);
                return await conn.QueryAsync<dynamic>(sproc, parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<ReportSetup> GetDevIdFromRSM_ID(int RSM_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RSM_ID", RSM_ID, DbType.Int32);
                return await conn.QueryFirstOrDefaultAsync<ReportSetup>("SIMS.GetDevIdFromRSM_ID", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ReportTopHeader>> GetReportTopHeaders(string IMG_BSU_ID, string IMG_TYPE)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IMG_BSU_ID", IMG_BSU_ID, DbType.String);
                parameters.Add("@IMG_TYPE", IMG_TYPE, DbType.String);
                return await conn.QueryAsync<ReportTopHeader>("OASIS..ReportHeader_Subreport", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ReportDesignerDBDetails>> GetReportDesignerDbSet(string MODULE_ID,long AcademicYearId,string SchoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MODULE_ID", MODULE_ID, DbType.String);
                parameters.Add("@AcademicYearId", AcademicYearId, DbType.Int64);
                parameters.Add("@SchoolId", SchoolId, DbType.String);
                return await conn.QueryAsync<ReportDesignerDBDetails>("SIMS.GetReportDesignerDbSet", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public bool SaveReportDesigner(string RDSR_MODULE, string RDSR_DATASET_ID, string RDSR_FILTER_TYPES, string RDSR_BSU_ID, int Id, string REPORT_NAME, Byte[] REPORT_LAYOUT)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RDSR_MODULE", RDSR_MODULE, DbType.String);
            parameters.Add("@RDSR_DATASET_ID", Convert.ToInt32(RDSR_DATASET_ID), DbType.Int32);
            parameters.Add("@RDSR_FILTER_TYPES", RDSR_FILTER_TYPES, DbType.String);
            parameters.Add("@RDSR_BSU_ID", RDSR_BSU_ID.ToString(), DbType.String);
            parameters.Add("@REPORT_NAME", REPORT_NAME, DbType.String);
            parameters.Add("@REPORT_LAYOUT", REPORT_LAYOUT, DbType.Binary);
            parameters.Add("@devId", Id, DbType.Int32);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.SaveReportDesignerDetails", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        #region curriculum

        public async Task<IEnumerable<Report>> LoadReportsList(int UserID, int RoleID, long schoolID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", UserID, DbType.Int32);
                parameters.Add("@RoleID", Convert.ToInt32(RoleID), DbType.Int32);
                parameters.Add("@schoolID", schoolID, DbType.Int64);
                return await conn.QueryAsync<Report>("[SIMS].[LoadReportsList]", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CrystalReportDesigner>> LoadCurriculumReportFormControls(int ReportID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RPT_ID", ReportID, DbType.String);
                return await conn.QueryAsync<CrystalReportDesigner>("SIMS.LoadCurriculumReportFormControls", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CrystalDesignerFilters>> LoadCrystalDesignerFitlers(string FilterArray)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@FilterArray", FilterArray, DbType.String);
                return await conn.QueryAsync<CrystalDesignerFilters>("SIMS.LoadCrystalDesignerFitlers", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ReportBinderModel>> BindCrystalReportFilters(long RDSR_ID, string RDF_FILTER_CODE, string FILTER_PARAMS,string Is_SuperUser="")
        {

            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RDSR_ID", RDSR_ID, DbType.Int64);
                parameters.Add("@RDF_FILTER_CODE", RDF_FILTER_CODE, DbType.String);
                parameters.Add("@FILTER_PARAMS", FILTER_PARAMS, DbType.String);
                parameters.Add("@isSuperUser", Is_SuperUser, DbType.String);
                return await conn.QueryAsync<ReportBinderModel>("SIMS.GET_REPORTDESIGNER_FILTER_BIND", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<ReportPathModel> GetCrystalReportPath(long RPT_ID, string Fetch_SP,string BSU_ID, CurriculumModel CurriculumModel)
        {

            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RPT_ID", RPT_ID, DbType.Int64);
                parameters.Add("@RPT_PARAM_VALUES", CurriculumModel.REPORT_PARAMS, DbType.String);
                parameters.Add("@FILTER_PARAMS", CurriculumModel.FILTER_PARAMS, DbType.String);
                if (Fetch_SP == "RPT.CRYSTAL_GET_PROGRESS_REPORT_PATH")
                    parameters.Add("@BSU_ID", BSU_ID);
                return await conn.QueryFirstOrDefaultAsync<ReportPathModel>(Fetch_SP, parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<string> GetConsolidatedReportExcel(long RPT_ID, string Fetch_SP, string BSU_ID, CurriculumModel CurriculumModel)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FILTER_PARAMS", CurriculumModel.FILTER_PARAMS, DbType.String);
                parameters.Add("@BSU_ID", BSU_ID);
                return await conn.QueryFirstOrDefaultAsync<string>("RPT.GET_ASSESSMENT_CONSOLIDATED_REPORT", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        #endregion
    }
}
