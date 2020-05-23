using SIMS.API.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class Assessment
    {
        public string Student_No { get; set; }
        public string Student_Name { get; set; }
        public string TDATE { get; set; }
        public string Status { get; set; }
        public string Student_Image_url { get; set; }
        public string AllowEdit { get; set; }
        public string ALG_ID { get; set; }
        public string STU_ID { get; set; }
        public string APD_ID { get; set; }
        public string STATUS_DESCR { get; set; }

    }
    public class StudentList
    {
        public string STU_NO { get; set; }
        public string STU_ID { get; set; }
        public string STU_NAME { get; set; }
        public string Grade { get; set; }
        public string Section { get; set; }
        public string STU_PHOTO { get; set; }



    }
    public class ReportHeader
    {
        public string RSM_ID { get; set; }
        public string CSSCLASS { get; set; }
        public string RSD_RESULT { get; set; }
        public string RSD_SUB_DESC { get; set; }
        public string RSD_HEADER { get; set; }
        public string DISPLAYORDER { get; set; }
        public string RSD_ID { get; set; }
        public string RSP_DESCR { get; set; }
        public bool IS_PREV { get; set; }
        public int RSD_bLock { get; set; }
        public string VALIDATION_TYPE { get; set; }
        public double VALIDATION_MIN { get; set; }
        public double VALIDATION_MAX { get; set; }
        public long SBG_ID { get; set; }
    }
    public class ReportHeaderDropDown
    {
        public string RSP_ID { get; set; }
        public string RSP_DESCR { get; set; }
        public string RSP_DISPLAYORDER { get; set; }

    }
    public class AssessmentData
    {
        [DataTableField("RST_ID", 1, typeof(long))]
        public string RST_ID { get; set; }
        [DataTableField("RST_RSD_ID", 3, typeof(long))]
        public string RSD_ID { get; set; }
        [DataTableField("RST_RPF_ID", 2,typeof(long))]
        public string RPF_ID { get; set; }
        public string RSD_RESULT { get; set; }
        [DataTableField("RST_SBG_ID", 9, typeof(long))]
        public string SBG_ID { get; set; }
        public string RSD_HEADER { get; set; }
        [DataTableField("RST_MARK", 11, typeof(decimal))]
        public string MARK { get; set; }
        [DataTableField("RST_COMMENTS",12, typeof(string))]
        public string COMMENTS { get; set; }
        [DataTableField("RST_GRADING", 13,typeof(string))]
        public string GRADING { get; set; }
        public string RRM_ID { get; set; }
        public string RSM_ID { get; set; }
        [DataTableField("RST_STU_ID", 6, typeof(long))]
        public string STU_ID { get; set; }
        [DataTableField("RST_GRD_ID", 5, typeof(string))]
        public string GRD_ID { get; set; }
        [DataTableField("RST_RSS_ID", 7, typeof(long))]
        public long RSS_ID { get; set; }
        [DataTableField("RST_SGR_ID", 8, typeof(long))]
        public long SGR_ID { get; set; }
        [DataTableField("RST_ACD_ID", 4, typeof(long))]
        public long ACD_ID { get; set; }
        public long SCT_ID { get; set; }
        [DataTableField("RST_TYPE_LEVEL", 10, typeof(string))]
        public string TYPE_LEVEL { get; set; }
        public bool bABSENT { get; set; }
        public int bEdit { get; set; }
        [DataTableField("RST_USER", 14, typeof(string))]
        public string RST_USER { get; set; }
        public string Status { get; set; }
    }

    public class MarkEntry
    {
        public long CAS_ID { get; set; }
        public long SLAB_ID { get; set; }
        public long SGR_ID { get; set; }
        public long SBG_ID { get; set; }
        public DateTime? CAS_DATE { get; set; }
        public DateTime? CAS_TIME { get; set; }
        public string CAS_DESC { get; set; }
        public string SBG_DESCR { get; set; }
        public string SGR_DESCR { get; set; }
        public string MARKS { get; set; }
        public string ATT { get; set; }
        public string bMARKS { get; set; }
        public string CAS_TYPE_LEVEL { get; set; }
        public int CAS_GSM_SLAB_ID { get; set; }
        public double CAS_MIN_MARK { get; set; }
        public double CAS_MAX_MARK { get; set; }
        public string SBG_ENTRYTYPE { get; set; }
        public bool CAS_bHasAOLEXAM { get; set; }
        public bool CAS_bWITHOUTSKILLS { get; set; }
        public bool CAS_bSKILLS { get; set; }
        public int GRD_ID { get; set; }

    }
    public class MarkEntryData
    {
        public long STA_ID { get; set; }
        public long STU_ID { get; set; }
        public long STU_NO { get; set; }
        public string STU_NAME { get; set; }
        public double MARKS { get; set; }
        public string MARK_GRADE { get; set; }
        public double MIN_MARK { get; set; }
        public double MAX_MARK { get; set; }
        public string IS_ENABLED { get; set; }
        public string STU_STATUS { get; set; }
        public string bATTENDED { get; set; }
    }

    public class MarkEntryAOLData
    {
        public long STA_ID { get; set; }
        public long STU_ID { get; set; }
        public long STU_NO { get; set; }
        public string STU_NAME { get; set; }
        public string SKILL_NAME { get; set; }
        public double SKILL_MARK { get; set; }
        public string SKILL_GRADE { get; set; }
        public double SKILL_MAX_MARK { get; set; }
        public double MARKS { get; set; }
        public string STA_GRADE { get; set; }
        public string IS_ENABLED { get; set; }
        public string WITHOUTSKILLS_MARKS { get; set; }
        public string WITHOUTSKILLS_GRADE { get; set; }
        public string WITHOUTSKILLS_MAXMARKS { get; set; }
        public string CHAPTER { get; set; }
        public string FEEDBACK { get; set; }
        public string WOT { get; set; }
        public string TARGET { get; set; }
        public string bATTENDED { get; set; }
        public string STU_STATUS { get; set; }

        public int SKILL_ORDER { get; set; }
    }



    public class AssessmentComments
    {
        public long CMT_ID { get; set; }
        public string CMT_COMMENTS { get; set; }


    }
    public class GetHeaderBySubjectCategory
    {
        public string SGR_GRD_ID { get; set; }
        public long SGR_SBG_ID { get; set; }
        public long SGR_ACD_ID { get; set; }
    }


    public class AssessmentCategory
    {
        public long CAT_ID { get; set; }

        public string CAT_DESC { get; set; }


    }
    public class SectionAccess
    {
        public long SCT_ID { get; set; }

        public string SCT_DESCR { get; set; }


    }
    public class HeaderOptional
    {
        public long AOM_ID { get; set; }

        public string AOM_DESCR { get; set; }
        public string AOM_TYPE { get; set; }
        public long AOD_ID { get; set; }
        public long AOD_BSU_ID { get; set; }
        public long AOD_ACD_ID { get; set; }


    }
    public class AssessmentDataOptional
    {
        public long AOM_ID { get; set; }
        public long STU_ID { get; set; }
        public string OPTIONAL_VALUE { get; set; }

    }

    public class AssessmentOptionalList
    {
        public string AOM_ID { get; set; }
        public string AOM_DESCR { get; set; }
        public string AOM_TYPE { get; set; }
        public int AOD_ID { get; set; }
        public int AOD_AOM_ID { get; set; }
        public int AOD_BSU_ID { get; set; }
        public int AOD_ACD_ID { get; set; }



    }


    public class AssessmentPreviousSchedule
    {
        public long RSM_ID { get; set; }
        public string RSM_DESCR { get; set; }
        public int RPF_ID { get; set; }
        public string RPF_DESCR { get; set; }
        public string DISPLAY_TEXT { get; set; }

    }

    public class MarkAttendance
    {
        public long STA_ID { get; set; }
        public long STU_ID { get; set; }
        public long STU_NO { get; set; }
        public string STU_NAME { get; set; }
        public string bATTENDED { get; set; }

        public long CAS_ID { get; set; }
        public long SlabId { get; set; }

    }
    #region Grade Book Setup
    public class GradeBookSetup
    {
        public long GBM_ID { set; get; }
        public long GBM_BSU_ID { set; get; }
        public long GBM_ACD_ID { set; get; }
        public long GBM_TRM_ID { set; get; }
        public string GBM_GRD_ID { set; get; }
        public long GBM_SBG_ID { set; get; }
        public long GBM_SGR_ID { set; get; }
        public long GBM_RSM_ID { set; get; }
        public long GBM_RSD_ID { set; get; }
        public long GBM_RPF_ID { set; get; }
        public string GBM_SHORT_CODE { set; get; }
        public string GBM_DESCR { set; get; }
        public DateTime GBM_DUE_DATE { set; get; }
        public bool GBM_bON_PORTAL { set; get; }
        public DateTime? GBM_PUBLISH_DATE { set; get; }
        public string GBM_ENTRY_MODE { set; get; }
        public string GBM_MARK_TYPE { set; get; }
        public double GBM_MAX_MARK { set; get; }
        public double GBM_MIN_MARK { set; get; }
        public long GBM_GSM_ID { set; get; }
        public long GBM_TEACHER_ID { set; get; }
        public string GBM_CREATED_BY { set; get; }
        public string GradeScale { get; set; }
    }
    public class GradeBookGradeScale
    {
        public GradeBookGradeScale()
        {
            GradeBookGradeScaleDetailList = new List<GradeBookGradeScaleDetail>();
        }
        public long GSM_ID { set; get; }
        public string GSM_DESCRIPTION { set; get; }
        public long GSM_BSU_ID { set; get; }
        public long GSM_ACD_ID { set; get; }
        public long GSM_TEACHER_ID { set; get; }
        public bool IsCommon { set; get; }
        public List<GradeBookGradeScaleDetail> GradeBookGradeScaleDetailList { get; set; }
        public DataTable GradeBookGradeScaleDetailDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("GSD_ID", typeof(Int64));
                dt.Columns.Add("GSD_GSM_ID", typeof(Int64));
                dt.Columns.Add("RANGEFROM", typeof(double));
                dt.Columns.Add("RANGETO", typeof(double));
                dt.Columns.Add("GRADE_DESCRIPTION", typeof(string));
                dt.Columns.Add("DATAMODE", typeof(string));
                GradeBookGradeScaleDetailList.ToList().ForEach(item =>
                {
                    string DATAMODE = string.Empty;

                    if (item.GSD_ID > 0 && !item.IsDeleted)
                        DATAMODE = "EDIT";
                    else if (item.GSD_ID > 0 && item.IsDeleted)
                        DATAMODE = "DELETE";
                    else if (item.GSD_ID == 0)
                        DATAMODE = "ADD";

                    dt.Rows.Add(
                                   item.GSD_ID,
                                   item.GSD_GSM_ID,
                                   item.RANGEFROM,
                                   item.RANGETO,
                                   item.GRADE_DESCRIPTION,
                                   DATAMODE
                                );
                });
                return dt;
            }
        }
    }
    public class GradeBookGradeScaleDetail
    {
        public long GSD_ID { set; get; }
        public long GSD_GSM_ID { set; get; }
        public double RANGEFROM { set; get; }
        public double RANGETO { set; get; }
        public string GRADE_DESCRIPTION { set; get; }
        public int DISPLAY_ORDER { set; get; }
        public bool IsDeleted { get; set; }
    }
    public class ReportHeaderModel
    {
        public long RSM_ID { get; set; }
        public long RSD_ID { set; get; }
        public string Header_Description { set; get; }
        public bool IsDirectEntry { set; get; }
        public bool IsAllSubject { set; get; }
        public bool IsRuleRequired { set; get; }
        public bool IsPerformanceIndicator { set; get; }
        public string RSD_CssClass { set; get; }
        public string RSD_DisplayType { set; get; }
        public string RSD_ResultType { set; get; }
        public bool IsLocked { set; get; }
        public string MarkType { set; get; }
        public double MinMarks { set; get; }
        public double MaxMarks { set; get; }
        public long RDM_ID { set; get; }
    }
    public class ProcessingRuleSetup
    {
        public long PRS_ID { get; set; }
        public long PRS_RSD_ID { get; set; }
        public string PRS_GBM_IDS { get; set; }
        public string PRS_CalculationType { get; set; }
        public string PRS_MODIFIED_BY { get; set; }        
    }
    public class GradeBookDetail
    {
        private long _gBD_STU_ID;

        public long GBD_ID { get; set; }
        public long GBD_GBM_ID { get; set; }
        public string GBD_MARK_TYPE { get; set; }
        public string GBD_MARK { get; set; }
        public string GBD_GRADE { get; set; }
        public string GBD_COMMENT { get; set; }
        public string GBD_MODIFIED_BY { get; set; }
        public DateTime GBD_MODIFIED_ON { get; set; }
        public bool GBD_bIS_PRESENT { get; set; }
        public long GBD_STU_ID { get => _gBD_STU_ID; set { _gBD_STU_ID = value; STU_ID = value; } }
        public long STU_ID { get; set; }
        public int bEdit { get; set; }
        public string GBD_Status { get; set; }
    }

    #endregion

    #region Grade Book Entry
    public class GradeBookEntryListModel
    {
        public GradeBookEntryListModel()
        {
            AssessmentDatas = new List<AssessmentData>();
            GradeBookDetails = new List<GradeBookDetail>();
        }
        public IEnumerable<AssessmentData> AssessmentDatas { get; set; }
        public DataTable AssessmentDatasDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RST_ID", typeof(long));
                dt.Columns.Add("RST_RPF_ID", typeof(long));
                dt.Columns.Add("RST_RSD_ID", typeof(long));
                dt.Columns.Add("RST_ACD_ID", typeof(long));
                dt.Columns.Add("RST_GRD_ID", typeof(string));
                dt.Columns.Add("RST_STU_ID", typeof(long));
                dt.Columns.Add("RST_RSS_ID", typeof(long));
                dt.Columns.Add("RST_SGR_ID", typeof(long));
                dt.Columns.Add("RST_SBG_ID", typeof(long));
                dt.Columns.Add("RST_SCT_ID", typeof(long));
                dt.Columns.Add("RST_TYPE_LEVEL", typeof(string));
                dt.Columns.Add("RST_MARK", typeof(double));      
                dt.Columns.Add("RST_COMMENTS", typeof(string));
                dt.Columns.Add("RST_GRADING", typeof(string));
                dt.Columns.Add("RST_STATUS", typeof(string));
                AssessmentDatas.ToList().ForEach(x => {
                    DataRow dr = dt.NewRow();
                    dr["RST_ID"] = x.RST_ID;
                    dr["RST_RPF_ID"] = x.RPF_ID;
                    dr["RST_RSD_ID"] = x.RSD_ID;
                    dr["RST_ACD_ID"] = x.ACD_ID;
                    dr["RST_GRD_ID"] = x.GRD_ID;
                    dr["RST_STU_ID"] = x.STU_ID;
                    dr["RST_RSS_ID"] = x.RSS_ID;
                    dr["RST_SGR_ID"] = x.SGR_ID;
                    dr["RST_SBG_ID"] = x.SBG_ID;
                    dr["RST_SCT_ID"] = x.SCT_ID;
                    dr["RST_TYPE_LEVEL"] = x.TYPE_LEVEL;
                    dr["RST_MARK"] = string.IsNullOrEmpty(x.MARK) ? (object)DBNull.Value : x.MARK;      
                    dr["RST_COMMENTS"] = string.IsNullOrEmpty(x.COMMENTS) ? (object)DBNull.Value : x.COMMENTS;
                    dr["RST_GRADING"] = string.IsNullOrEmpty(x.GRADING) ? (object)DBNull.Value : x.GRADING;
                    dr["RST_STATUS"] = x.Status;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
        public IEnumerable<GradeBookDetail> GradeBookDetails { get; set; }
        public DataTable GradeBookDetailsDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("GBD_ID", typeof(long));
                dt.Columns.Add("GBD_GBM_ID", typeof(long));
                dt.Columns.Add("GBD_MARK_TYPE", typeof(string));
                dt.Columns.Add("GBD_MARK", typeof(decimal));
                dt.Columns.Add("GBD_GRADE", typeof(string));
                dt.Columns.Add("GBD_STU_ID", typeof(long));
                dt.Columns.Add("GBD_COMMENT", typeof(string));
                dt.Columns.Add("GBD_bIS_PRESENT", typeof(bool));
                dt.Columns.Add("GBD_MODIFIED_BY", typeof(string));
                dt.Columns.Add("GBD_MODIFIED_ON", typeof(DateTime));
                dt.Columns.Add("GBD_Status", typeof(string));
                GradeBookDetails.ToList().ForEach(x => {
                    DataRow dr = dt.NewRow();
                    dr["GBD_ID"] = x.GBD_ID;
                    dr["GBD_GBM_ID"] = x.GBD_GBM_ID;
                    dr["GBD_MARK_TYPE"] = string.IsNullOrEmpty(x.GBD_MARK_TYPE) ? (object)DBNull.Value : x.GBD_MARK_TYPE;
                    dr["GBD_MARK"] = string.IsNullOrEmpty(x.GBD_MARK) ? (object)DBNull.Value : x.GBD_MARK;
                    dr["GBD_GRADE"] = string.IsNullOrEmpty(x.GBD_GRADE) ? (object)DBNull.Value : x.GBD_GRADE;
                    dr["GBD_STU_ID"] = x.STU_ID;
                    dr["GBD_COMMENT"] = string.IsNullOrEmpty(x.GBD_COMMENT) ? (object)DBNull.Value: x.GBD_COMMENT;
                    dr["GBD_bIS_PRESENT"] = x.GBD_bIS_PRESENT;
                    dr["GBD_MODIFIED_BY"] = x.GBD_MODIFIED_BY;
                    dr["GBD_MODIFIED_ON"] = x.GBD_MODIFIED_ON;
                    dr["GBD_Status"] = x.GBD_Status;
                    dt.Rows.Add(dr);
                });

                return dt;
            }
        }
        public string Username { get; set; }
        public int bEdit { get; set; }
    }
    #endregion

    #region Report Writing
    public class StudentReportWriting
    {
        public int SubjectId { get; set; }
        public int ReportScheduleId { get; set; }
        public string Record { get; set; }
    }
    #endregion
}

