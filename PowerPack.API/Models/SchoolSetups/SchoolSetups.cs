using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PowerPack.API.Models
{
    public class AssessmentTerm
    {
        public int Id { get; set; }
        public int TermId { get; set; }
        public string Term { get; set; }
        public string Description { get; set; }
        public string Assessment { get; set; }
        public string DisplayOrder { get; set; }
        public bool IsLock { get; set; }
        public string DataMode { get; set; }
    }
    public class TerminologyCU
    {
        public long AcademicId { get; set; }
        public long SchoolId { get; set; }
        public int CurriculumId { get; set; }
        public string LangCode { get; set; }
        public int DivisionId { get; set; }
        public List<Terminology> Terminologies { get; set; }
        public DataTable TerminologiesDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TRD_ID", typeof(long));
                dt.Columns.Add("TRD_KEY", typeof(string));
                dt.Columns.Add("TRD_VALUE", typeof(string));
                dt.Columns.Add("DATAMODE", typeof(string));
                Terminologies.ForEach(x => {
                    DataRow dr = dt.NewRow();
                    dr["TRD_ID"] = x.TrdId;
                    dr["TRD_KEY"] = x.Key;
                    dr["TRD_VALUE"] = x.Lable;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
    }
    public class Terminology
    {
        public long TrdId { get; set; }
        public string Key { get; set; }
        public string Lable { get; set; }
    }
    public class AcademicTerms
    {
        public long BSU_ID { get; set; }
        public long ACD_ID { get; set; }
        public long ACD_CLM_ID { get; set; }
        public int AcademicYearId { get; set; }
        public string AcademicYear_Desription { get; set; }
        public DateTime AcademicYear_StartDate { get; set; }
        public DateTime AcademicYear_EndDate { get; set; }
        public int AcademicYear_CurrentStatus { get; set; }
        public long TermId { get; set; }
        public string Term_Description { get; set; }
        public DateTime Term_StartDate { get; set; }
        public DateTime Term_EndDate { get; set; }
        public int DayDiff { get; set; }
        public string DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool IsLock { get; set; }
        public string Description { get; set; }
        public string Term { get; set; }
        public string Assessment { get; set; }
        public string DataMode { get; set; }
        public long TRM_ID { get; set; }
        public decimal DayDiffByGAP { get; set; }
        public int GAP { get; set; }
        public string AssessmentTitle { get; set; }
        public int? DivisionId { get; set; }
    }

    public class GradeDisplay
    {
        public int GradeDisplayId { get; set; }
        public string GradeId { get; set; }
        public string Grade { get; set; }
    }
    public class GradeDisplayU
    {
        public List<GradeDisplay> GradeDisplays { get; set; }
        public DataTable GradeDisplaysDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("GRM_DISPLAY_ID", typeof(long));
                dt.Columns.Add("GRM_ID", typeof(string));
                dt.Columns.Add("GRM_DISPLAY", typeof(string));
                GradeDisplays.ForEach(x => {
                    DataRow dr = dt.NewRow();
                    dr["GRM_DISPLAY_ID"] = x.GradeDisplayId;
                    dr["GRM_ID"] = x.GradeId;
                    dr["GRM_DISPLAY"] = x.Grade;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
    }
}