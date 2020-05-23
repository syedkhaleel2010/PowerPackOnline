using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class Reports
    {
        public int DEV_ID { get; set; }

        public string DEV_REPORT_NAME { get; set; }

        public Byte[] DEV_LAYOUT { get; set; }
        public int DEV_REPORT_FILTER_ID { get; set; }
    }


    public class ReportDesigner
    {
        public int DEV_ID { get; set; }
        public string DEV_REPORT_NAME { get; set; }

        public int RDSR_ID { get; set; }

        public string RDD_TITLE { get; set; }

        public string RDD_DB_NAME { get; set; }

        public string RDD_PROC_NAME { get; set; }

        public string RDSR_FILTER_TYPES { get; set; }

        public long DATASET_ID { get; set; }
    }

    public class ReportBinder
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public string Selected { get; set; }

    }

    public class ReportFilterControls
    {
        public long RDF_ID { get; set; }
        public string RDF_FILTER_CODE { get; set; }
        public string RDF_FILTER_NAME { get; set; }
        public string RDF_FILTER_TYPE { get; set; }
        public int RDF_ORDER { get; set; }
    }

    public class ReportTypes
    {
        public int Id { get; set; }

        public string ReportType { get; set; }

        public string ReportCode { get; set; }

    }


    public class ReportSetup
    {
        public int RSM_ID { get; set; }
        public string RSM_DESCR { get; set; }
        public long RSM_BSU_ID { get; set; }
        public int RSM_ACD_ID { get; set; }
        public int RSM_DEV_ID { get; set; }
    }


    public class ReportTopHeader
    {
        public string BSU_TEL { get; set; }
        public string BSU_FAX { get; set; }
        public string BSU_EMAIL { get; set; }
        public string BSU_ADDRESS { get; set; }
        public string BSU_NAME { get; set; }
        public string BSU_NAME_ARABIC { get; set; }
        public string BSU_POBOX { get; set; }
        public string BSU_URL { get; set; }
        public Byte[] BSU_IMAGE { get; set; }
        public string BSU_CITY { get; set; }
        public string BSU_CITY_AR { get; set; }
        public string ACCOUNTSEMAIL { get; set; }
        public string BUS_RECEIPT_FOOTER { get; set; }
        public string BSU_ID { get; set; }
        public string BSU_ADDRESS_MAIN { get; set; }
        public string BSU_COUNTRY { get; set; }
        public string BUS_TAX_REGN_DETAIL { get; set; }
        public string FONT_COLOR_R { get; set; }
        public string FONT_COLOR_G { get; set; }
        public string FONT_COLOR_B { get; set; }

        public string FONT { get; set; }
        public string HIDE_DETAILS { get; set; }
        public string FOOTER_TEXT { get; set; }
    }

    public class ReportDesignerDBDetails
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string DBName { get; set; }
        public string SPName { get; set; }
        public string Module { get; set; }
        public string FilterType { get; set; }
    }


    public class ReportLayoutBody
    {
        public int DevId { get; set; }
        public Byte[] REPORT_LAYOUT { get; set; }

        public string REPORT_NAME { get; set; }

        public string RDSR_FILTER_TYPES { get; set; }

    }

    public class Report
    {
        public int RM_RPT_ID { get; set; }
        public string RM_REPORT_NAME { get; set; }
        public string GroupName { get; set; }
        public string Report_Type { get; set; }
        public List<CrystalDesignerFilters> CrystalDesignerFilters { get; set; }
    }

    public class CrystalDesignerFilters
    {
        public int RDF_ID { get; set; }
        public string RDF_FILTER_CODE { get; set; }
        public string RDF_FILTER_NAME { get; set; }
        public string RDF_FILTER_TYPE { get; set; }
        public List<ReportBinder> FilterData { get; set; }
    }

    public class CrystalFilterData
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class CrystalReportDesigner
    {

        public int RM_RPT_ID { get; set; }
        public string RM_REPORT_NAME { get; set; }

        public string RM_CONTROL_TYPE { get; set; }

        public string RM_PARAMETER_TYPE { get; set; }

        public string RM_SP_NAME { get; set; }

        public string RM_REPORT_PATH { get; set; }

        public string RM_HAS_LOGO { get; set; }

        public Boolean RM_ISACTIVE { get; set; }

        public string RM_ISMULTIPLE { get; set; }

        public string RM_FETCH_SP { get; set; }

        public string RM_SP_PARAMS { get; set; }

        public string RM_GROUP_ID { get; set; }

        public string RM_ADDITIONAL_PARAMS { get; set; }
        public string RM_REPORT_CODE { get; set; }

    }

    public class ReportBinderModel
    {

        public string Code { get; set; }
        public string Name { get; set; }

        public int Index { get; set; }

        public Boolean Selected { get; set; }

    }

    public class ReportPathModel
    {
        public string Report_Path { get; set; }
        public string Report_Params { get; set; }
        public Boolean HasStudPhoto { get; set; }
    }

    public class ReportList
    {
        public long ReportId { get; set; }
        public string ReportName { get; set; }
        public string ReportCode { get; set; }
        public long GroudId { get; set; }
        public string GroupName { get; set; }
    }




    public class CurriculumModel
    {
        public string REPORT_PARAMS { get; set; }
        public string FILTER_PARAMS { get; set; }
    }
}
