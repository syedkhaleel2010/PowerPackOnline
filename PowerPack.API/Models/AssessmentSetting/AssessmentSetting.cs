using PowerPack.API.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Models
{
    public class AssessmentSetting
    {
    }
    #region Assessment Configuration
    public class AssessmentConfiguration
    {
        public long RSD_ID { get; set; }
        public long AcademicYearId { get; set; }
        public string Header_Description { get; set; }
        public long Grade { get; set; }
        public long Term { get; set; }
        public string ReportHeader { get; set; }
        public string RSD_DisplayType { get; set; }
        public string RSD_CssClass { get; set; }
        public string RSD_ResultType { get; set; }
        public bool IsDirectEntry { get; set; }
        public bool IsAllSubject { get; set; }
        public bool IsRuleRequired { get; set; }
        public bool IsPerformanceIndicator { get; set; }
        public bool IsFinalReport { get; set; }
        public bool IsLocked { get; set; }
        public string MarkType { get; set; }
        public double? MinMarks { get; set; }
        public double? MaxMarks { get; set; }
        public string SBG_ID { get; set; }
        public int? RDM_ID { get; set; }
        public string DataMode { get; set; }
    }
    public class ReportSchedule
    {
        public int RPF_ID { get; set; }
        public string RPF_Description { get; set; }
        public string DataMode { get; set; }
    }
    public class AssessmentGrade
    {
        public long ReportGradeId { get; set; }
        public string GradeId { get; set; }
        public string Grade_Description { get; set; }
        public string DataMode { get; set; }
    }
    public class AssessmentConfig : SubjectSpecificCriteriaData
    {
        public AssessmentConfig()
        {
            AssessmentConfigurations = new List<AssessmentConfiguration>();
            AssessmentGrades = new List<AssessmentGrade>();
            ReportSchedules = new List<ReportSchedule>();
        }
        public long SchoolId { get; set; }
        public long ACD_ID { get; set; }
        public long RSM_ID { get; set; }
        public string Header { get; set; }
        public string DataMode { get; set; }
        public IEnumerable<AssessmentConfiguration> AssessmentConfigurations { get; set; }
        public IEnumerable<AssessmentGrade> AssessmentGrades { get; set; }
        public IEnumerable<ReportSchedule> ReportSchedules { get; set; }
        public DataTable AssessmentConfigurationsDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RSD_ID", typeof(long));
                dt.Columns.Add("RSD_HEADER", typeof(string));
                dt.Columns.Add("RSD_DISPLAYTYPE", typeof(string));
                dt.Columns.Add("RSD_CSSCLASS", typeof(string));
                dt.Columns.Add("RSD_RESULT", typeof(string));
                dt.Columns.Add("RSD_bDIRECTENTRY", typeof(bool));
                dt.Columns.Add("RSD_bALLSUBJECTS", typeof(bool));
                dt.Columns.Add("RSD_bFINALREPORT", typeof(bool));
                dt.Columns.Add("RSD_bRULEREQD", typeof(bool));
                dt.Columns.Add("RSD_bPERFORMANCE_INDICATOR", typeof(bool));
                dt.Columns.Add("RSD_bGRAPH", typeof(bool));
                dt.Columns.Add("RSD_MARKTYPE", typeof(string));
                dt.Columns.Add("RSD_MINMARKS", typeof(decimal));
                dt.Columns.Add("RSD_MAXMARKS", typeof(decimal));
                dt.Columns.Add("RSD_SBG_IDS", typeof(string));
                dt.Columns.Add("RSD_RDM_ID", typeof(long));
                dt.Columns.Add("RSD_bLOCK", typeof(bool));
                dt.Columns.Add("RSD_DATAMODE", typeof(string));
                AssessmentConfigurations.ToList().ForEach(x =>
                {
                    DataRow dr = dt.NewRow();
                    dr["RSD_ID"] = x.RSD_ID;
                    dr["RSD_HEADER"] = x.Header_Description;
                    dr["RSD_DISPLAYTYPE"] = x.RSD_DisplayType;
                    dr["RSD_CSSCLASS"] = x.RSD_CssClass;
                    dr["RSD_RESULT"] = x.RSD_ResultType;
                    dr["RSD_bDIRECTENTRY"] = x.IsDirectEntry;
                    dr["RSD_bALLSUBJECTS"] = x.IsAllSubject;
                    dr["RSD_bFINALREPORT"] = x.IsFinalReport;
                    dr["RSD_bRULEREQD"] = x.IsRuleRequired;
                    dr["RSD_bPERFORMANCE_INDICATOR"] = x.IsPerformanceIndicator;
                    dr["RSD_bGRAPH"] = x.IsPerformanceIndicator;
                    dr["RSD_bLOCK"] = x.IsLocked;
                    dr["RSD_MARKTYPE"] = string.IsNullOrEmpty(x.MarkType) ? (object)DBNull.Value : x.MarkType;
                    dr["RSD_MINMARKS"] = x.MinMarks.HasValue ? x.MinMarks.Value : (object)DBNull.Value;
                    dr["RSD_MAXMARKS"] = x.MaxMarks.HasValue ? x.MaxMarks.Value : (object)DBNull.Value;
                    dr["RSD_SBG_IDS"] = string.IsNullOrEmpty(x.SBG_ID) ? (object)DBNull.Value : x.SBG_ID;
                    dr["RSD_RDM_ID"] = x.RDM_ID.HasValue ? x.RDM_ID.Value : (object)DBNull.Value;
                    dr["RSD_DATAMODE"] = string.IsNullOrEmpty(x.DataMode) ? "" : x.DataMode;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
        public DataTable AssessmentGradesDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RSG_ID", typeof(long));
                dt.Columns.Add("RSG_GRD_ID", typeof(string));
                dt.Columns.Add("RSG_DATAMODE", typeof(string));
                AssessmentGrades.ToList().ForEach(x =>
                {
                    DataRow dr = dt.NewRow();
                    dr["RSG_ID"] = x.ReportGradeId;
                    dr["RSG_GRD_ID"] = x.GradeId;
                    dr["RSG_DATAMODE"] = string.IsNullOrEmpty(x.DataMode) ? "" : x.DataMode;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
        public DataTable ReportSchedulesDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RPF_ID", typeof(long));
                dt.Columns.Add("RPF_DESCR", typeof(string));
                dt.Columns.Add("RPF_DATAMODE", typeof(string));
                ReportSchedules.ToList().ForEach(x =>
                {
                    DataRow dr = dt.NewRow();
                    dr["RPF_ID"] = x.RPF_ID;
                    dr["RPF_DESCR"] = x.RPF_Description;
                    dr["RPF_DATAMODE"] = string.IsNullOrEmpty(x.DataMode) ? "" : x.DataMode;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
        public Boolean IsSummative { get; set; }
    }
    public class AssessmentSettings
    {
        public int ReportSM_Id { get; set; }
        public string ReportSM_Description { get; set; }
        public bool IsFinalReport { get; set; }
        public bool IsAOLProcessing { get; set; }
        public string LinkedReportName { get; set; }
        public Boolean IsSummative { get; set; }
    }
    #endregion

    #region Other Configuration Setting
    public class AbsenteeSettingModel
    {
        public long AbsenteeId { get; set; }
        public long BSU_ID { get; set; }
        public long AbsenteeACD_ID { get; set; }
        public string Absent_Description { get; set; }
        public string ApprovedLeave_Description { get; set; }
    }
    public class ReportDesignName
    {
        public long DEV_ID { get; set; }
        public string DEV_REPORT_NAME { get; set; }
    }
    public class ReportDesignLink
    {
        public long RSM_ID { get; set; }
        public long RSM_BSU_ID { get; set; }
        public long RSM_ACD_ID { get; set; }
        public long RSM_DEV_ID { get; set; }
        public string ReportName { get; set; }
        public string DesignName { get; set; }
    }
    public class RuleDeletionModel
    {
        public long RSM_ID { get; set; }
        public string RSM_Description { get; set; }
        public long ReportScheduleId { get; set; }
        public string ReportSchedule_Description { get; set; }
        public long ReportSetupD_Id { get; set; }
        public string ReportSetupD_Description { get; set; }
        public long SubjectGradeID { get; set; }
        public string SubjectGrade_Description { get; set; }
        public string GRD_ID { get; set; }
        public string GradeDisplay { get; set; }
        public long TermID { get; set; }
        public string Term_Description { get; set; }
        public string RuleType { get; set; }
        public string Rule_Description { get; set; }
        public long RuleId { get; set; }
    }
    public class RuleSetupModel
    {
        public RuleSetupModel()
        {
            AssesmentWithType = new List<AssesmentWithType>();
        }

        public string RSM_Description { get; set; }
        public string ReportSchedule_Description { get; set; }
        public string ReportSetupD_Description { get; set; }
        public long SBG_ID { get; set; }
        public string SubjectGrade_Description { get; set; }
        public string GRD_ID { get; set; }
        public string GradeDisplay { get; set; }
        public string Term_Description { get; set; }
        public string Rule_Description { get; set; }
        public long RRM_ID { set; get; }
        public long RSM_ID { set; get; }
        public string SBG_IDs { set; get; }
        public long ACD_ID { set; get; }
        public string GRD_IDs { set; get; }
        public string RRM_DESCR { set; get; }
        public long RPF_ID { set; get; }
        public long RSD_ID { set; get; }
        public long TRM_ID { set; get; }
        public string RRM_TYPE { set; get; }
        public long SLAB_ID { set; get; }
        public decimal PASSMARK { set; get; }
        public decimal MAXMARK { set; get; }
        public string ENTRYTYPE { set; get; }
        public decimal GRADE_WEIGTAGE { set; get; }
        public string DATAMODE { get; set; }
        public List<AssesmentWithType> AssesmentWithType { get; set; }
        public DataTable ReportScheduleDT
        {
            get
            {
                int ROW_ID = 1;
                DataTable dt = new DataTable();
                dt.Columns.Add("ROW_ID", typeof(int));
                dt.Columns.Add("RSS_ID", typeof(Int64));
                dt.Columns.Add("CAM_ID", typeof(string));
                dt.Columns.Add("CAD_IDS", typeof(string));
                dt.Columns.Add("RSS_WEIGHTAGE", typeof(decimal));
                dt.Columns.Add("RSS_OPERATION", typeof(string));
                dt.Columns.Add("RSS_OPRT_DISPLAY", typeof(string));

                AssesmentWithType.ToList().ForEach(x =>
                {
                    DataRow dr = dt.NewRow();
                    dr["ROW_ID"] = ROW_ID;
                    dr["RSS_ID"] = x.RSS_ID;
                    dr["CAM_ID"] = Convert.ToString(x.CAM_ID);
                    dr["CAD_IDS"] = x.CAD_IDs;
                    dr["RSS_WEIGHTAGE"] = x.WEIGHTAGE;
                    dr["RSS_OPERATION"] = x.OPERATION;
                    dr["RSS_OPRT_DISPLAY"] = x.OPRT_DISPLAY;
                    dt.Rows.Add(dr);
                    ROW_ID++;
                });
                return dt;
            }
        }
    }
    public class AssesmentWithType
    {
        public long CAD_ID { get; set; }
        public string CAD_DESC { get; set; }
        public long CAM_ID { get; set; }
        public string CAM_DESC { get; set; }
        public string CAD_IDs { get; set; }
        public long RSS_ID { get; set; }
        public decimal WEIGHTAGE { get; set; }
        public string OPERATION { get; set; }
        public string OPRT_DISPLAY { get; set; }
    }
    public class PublishedReportModel
    {
        public string Grade_Display { get; set; }
        public string Section { get; set; }
        public long SectionId { get; set; }
        public string GRD_ID { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPublished { get; set; }
        public bool ISReleased { get; set; }
        public DateTime? ReleasedDate { get; set; }
    }
    public class UnpublishedReportData
    {
        public UnpublishedReportData()
        {
            UnpublishedReportList = new List<PublishedReportModel>();
        }
        public long ACD_ID { get; set; }
        public long TRM_ID { get; set; }
        public long RSM_ID { get; set; }
        public long RPF_ID { get; set; }
        public List<PublishedReportModel> UnpublishedReportList { get; set; }
        public DataTable UnpublishedReportDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RPP_GRD_ID", typeof(string));
                dt.Columns.Add("RPP_SCT_ID", typeof(int));
                dt.Columns.Add("RPP_IsPublish", typeof(bool));
                dt.Columns.Add("RPP_IsReleased", typeof(bool));
                dt.Columns.Add("RPP_Release_Date", typeof(DateTime));

                UnpublishedReportList.ToList().ForEach(x =>
                {
                    DataRow dr = dt.NewRow();
                    dr["RPP_GRD_ID"] = x.GRD_ID;
                    dr["RPP_SCT_ID"] = x.SectionId;
                    dr["RPP_IsPublish"] = x.IsPublished;
                    dr["RPP_IsReleased"] = x.ISReleased;
                    dr["RPP_Release_Date"] = x.ReleasedDate;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
    }
    public class SubjectSpecificCriteria
    {
        public long RSD_ID { get; set; }
        public long TempRSD_ID { get; set; }
        public string RSD_HEADER { get; set; }
        public string RSD_SUB_DESCRIPTION { get; set; }
        public long RDM_ID { get; set; }
        public int RSD_ORDER { get; set; }
        public long SBT_ID { get; set; }
        public string SBT_SHORTNAME { get; set; }
        public string SBT_DESCRIPTION { get; set; }
        public string RSD_SKILLS { get; set; }
        public long RSD_CATEGORY_ID { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SubjectSpecificCriteriaData
    {
        public SubjectSpecificCriteriaData()
        {
            SubjectSpecificCriteriaList = new List<SubjectSpecificCriteria>();
        }
        public long RSM_ID { get; set; }
        public long SBG_ID { get; set; }
        public List<SubjectSpecificCriteria> SubjectSpecificCriteriaList { get; set; }
        public DataTable SubjectSpecificCriteriaDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RSD_ID", typeof(Int64));
                dt.Columns.Add("RDM_ID", typeof(Int64));
                dt.Columns.Add("RSD_HEADER", typeof(string));
                dt.Columns.Add("RSD_SUB_DESCR", typeof(string));
                dt.Columns.Add("RSD_ORDER", typeof(int));
                dt.Columns.Add("RSD_CATEGORY_ID", typeof(Int64));
                dt.Columns.Add("RSD_SUB_SKILL", typeof(string));
                dt.Columns.Add("SBT_ID", typeof(Int64));
                dt.Columns.Add("RSD_DATAMODE", typeof(string));

                SubjectSpecificCriteriaList.ToList().ForEach(item =>
                {
                    string RSD_DATAMODE = string.Empty;
                    if (item.RSD_ID > 0 && !item.IsDeleted)
                        RSD_DATAMODE = "EDIT";
                    else if (item.RSD_ID > 0 && item.IsDeleted)
                        RSD_DATAMODE = "DELETE";
                    else if (item.RSD_ID == 0)
                        RSD_DATAMODE = "ADD";

                    dt.Rows.Add(
                                   item.RSD_ID,
                                   item.RDM_ID,
                                   item.RSD_HEADER,
                                   item.RSD_SUB_DESCRIPTION,
                                   item.RSD_ORDER,
                                   item.RSD_CATEGORY_ID,
                                   item.RSD_SKILLS,
                                   item.SBT_ID,
                                   RSD_DATAMODE
                                );
                });
                return dt;
            }
        }
    }
    public class GetDefaultListById
    {
        public long RDD_ORDER { get; set; }
        public long RDD_RDM_ID { get; set; }
        public long RDD_ID { get; set; }
        public string RDD_DESCR { get; set; }
        public int Index { get; set; }
        private string _DataMode = "EDIT";
        public string DataMode { get => _DataMode; set => _DataMode = value; }
        public long BSU_ID { get; set; }
        public List<PowerPack.Common.Models.ListItem> BankListData { get; set; }
    }
    public class AssessmentDescriptor
    {
        public AssessmentDescriptor()
        {

            DataMode = "EDIT";
        }
        public string RDD_DESCR { get; set; }
        public long RDD_ORDER { get; set; }
        public long RDD_RDM_ID { get; set; }
        public long RDD_ID { get; set; }

        public int Index { get; set; }
        public string DataMode { get; set; }

    }
    public class SubjectCategoryModel
    {
        public SubjectCategoryModel()
        {
            SubjectCategory_Data = new List<SubjectCategoryModel>();
        }
        public long CategoryId { get; set; }
        public string Category_Description { get; set; }
        public int Category_Order { get; set; }
        public string Category_ShortName { get; set; }
        public int Index { get; set; }
        private string _DataMode = "EDIT";
        public string DataMode { get => _DataMode; set => _DataMode = value; }
        public long BSU_ID { get; set; }
        public long ACD_ID { get; set; }
        public string GRD_ID { get; set; }
        public long SBG_ID { get; set; }
        public List<SubjectCategoryModel> SubjectCategory_Data { get; set; }
        public DataTable SubjectCategory_DataDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("SBT_ID", typeof(long));
                dt.Columns.Add("SBT_DESCR", typeof(string));
                dt.Columns.Add("SBT_ORDER", typeof(int));
                dt.Columns.Add("SBT_SHORTNAME", typeof(string));
                dt.Columns.Add("SBT_DATAMODE", typeof(string));

                SubjectCategory_Data.ToList().ForEach(x =>
                {
                    DataRow dr = dt.NewRow();
                    dr["SBT_ID"] = x.CategoryId;
                    dr["SBT_DESCR"] = x.Category_Description;
                    dr["SBT_ORDER"] = x.Category_Order;
                    dr["SBT_SHORTNAME"] = x.Category_ShortName;
                    dr["SBT_DATAMODE"] = x.DataMode;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
    }

    public class DefaultValues
    {
        public long RSM_ID { get; set; }
        public long RSD_ID { get; set; }
        public long RSP_RSM_ID { get; set; }
        public long RSP_RSD_ID { get; set; }
        public string RSP_TEXT { get; set; }
        public string RSD_HEADER { get; set; }
        public string GRD_IDS { get; set; }
        public string SBG_IDS { get; set; }
        public long RDM_ID { get; set; }
    }

    public class CourseContent
    {
        public long RCP_ID { get; set; }
        public long RCP_RSM_ID { get; set; }
        public long RCP_RPF_ID { get; set; }
        public long RCP_RSD_ID { get; set; }
        public long RCP_SBG_ID { get; set; }
        public string RCP_DESCR { get; set; }
        public long RCP_ACD_ID { get; set; }
        public string RCP_GRD_ID { get; set; }
        public string Content_Description { get; set; }
        public string DataMode { get; set; }
    }
    public class CourseContentParameter
    {
        public long RSM_ID { get; set; }
        public long RSD_ID { get; set; }
        public long RPF_ID { get; set; }
        public long SBG_ID { get; set; }
    }
    #endregion

    #region Reflection Setup
    public class ReflectionSetupModel
    {
        public long RFL_ID { get; set; }
        public long ACD_ID { get; set; }
        public long BSU_ID { get; set; }
        public long TRM_ID { get; set; }
        public string GRD_ID { get; set; }
        public long SBG_ID { get; set; }
        public string SubjectDescription { get; set; }
        public string OTC_IDS { get; set; }
        public string RFL_DECRIPTION { get; set; }
        public List<OutComeModel> OutComeModelList { get; set; }
    }
    public class OutComeModel
    {
        public long OTC_ID { get; set; }
        public long ACD_ID { get; set; }
        public long BSU_ID { get; set; }
        public long TRM_ID { get; set; }
        public string GRD_ID { get; set; }
        public long SBG_ID { get; set; }
        public string OTC_DESCRIPTION { get; set; }
    }
    #endregion

    #region Course Selection Setup
    public class CourseSelectionPrerequisite
    {
        public long PrerequisiteId { get; set; }
        public long PrerequisiteAcdId { get; set; }
        public string PrerequisiteGradeId { get; set; }
        public long PrerequisiteSubjectId { get; set; }
        public long PrerequisiteFutureSubjectId { get; set; }
        public int PrerequisiteMinimumPercent { get; set; }
        public string PrerequisiteAcademicYearDesc { get; set; }
        public string PrerequisiteGrade { get; set; }
        public string PrerequisiteSubjectName { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class CouseSelectionValidationType
    {
        public int CourseSelectionValidationId { get; set; }
        public string CourseSelectionValidationDesc { get; set; }
        public string CourseSelectionValidationType { get; set; }
    }

    public class CouserSelectionSubjectCriteria : CourseSelectionSubjects
    {
        public CouserSelectionSubjectCriteria()
        {
            SubjectIds = new List<CourseSelectionSubjects>();
        }
        public int Index { get; set; }
        public long CSM_ID { get; set; }
        public long BucketId { get; set; }
        public int ddlSubjectCriteria { get; set; }
        public string BucketName { get; set; }
        public int DisplayOrder { get; set; }
        public double? MinMarks { get; set; }
        public double? MaxMarks { get; set; }
        public int GroupId { get; set; }
    }

    public class CourseSelectionSubjects
    {
        public long CSD_ID { get; set; }
        public long SubjectId { get; set; }
        public long SubjectGradeId { get; set; }
        public string SubjectGradeDescription { get; set; }
        public string ValidationName { get; set; }
        public string SubjectGradeShortCode { get; set; }
        public long ParentId { get; set; }
        public bool IsPrequisite { get; set; }
        public bool IsActive { get; set; } = true;
        public List<CourseSelectionSubjects> SubjectIds { get; set; }
    }

    public class CourseSelectionDetailsCUD
    {
        public CourseSelectionDetailsCUD()
        {
            CouserSelections = new List<CouserSelectionSubjectCriteria>();
        }

        public long CSM_ID { get; set; }
        public long CSM_ACD_ID { get; set; }
        public long CSM_BSU_ID { get; set; }
        public string CSM_GRD_ID { get; set; }
        public long CSM_STM_ID { get; set; }
        public List<CouserSelectionSubjectCriteria> CouserSelections { get; set; }
        public DataTable CouserSelectionsDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CSD_ID", typeof(long));
                dt.Columns.Add("CSD_ValidationType", typeof(int));
                dt.Columns.Add("CSD_Minimum", typeof(decimal));
                dt.Columns.Add("CSD_Maximum", typeof(decimal));
                dt.Columns.Add("CSD_Description", typeof(string));
                dt.Columns.Add("CSD_SubjectId", typeof(long));
                dt.Columns.Add("CSD_DisplayOrder", typeof(int));
                dt.Columns.Add("IsActive", typeof(bool));
                dt.Columns.Add("CSD_GroupId", typeof(int));
                CouserSelections.ForEach(x =>
                {
                    x.SubjectIds.ForEach(e =>
                    {
                        DataRow dr = dt.NewRow();
                        dr["CSD_ID"] = e.CSD_ID;
                        dr["CSD_ValidationType"] = x.ddlSubjectCriteria;
                        dr["CSD_Minimum"] = x.MinMarks ?? (object)DBNull.Value;
                        dr["CSD_Maximum"] = x.MaxMarks ?? (object)DBNull.Value;
                        dr["CSD_Description"] = x.BucketName;
                        dr["CSD_SubjectId"] = e.SubjectId;
                        dr["CSD_DisplayOrder"] = x.DisplayOrder;
                        dr["IsActive"] = e.IsActive;
                        dr["CSD_GroupId"] = x.Index;
                        dt.Rows.Add(dr);
                    });
                });
                return dt;
            }
        }
    }
    public class CourseSelectionDetailsCUDResponse
    {
        public long CSD_ID { get; set; }
        public long CSM_ID { get; set; }
        public int GROUPID { get; set; }
        public long SBG_ID { get; set; }
    }
    public class CourseSelectedStudent
    {
        [DataTableFieldAttribute("CSD_ID",1, typeof(long))]
        public long CSD_ID { get; set; }
        [DataTableFieldAttribute("StudentId", 2, typeof(long))]
        public long StudentId { get; set; }
        [DataTableFieldAttribute("SubjectId", 3, typeof(long))]
        public long SubjectId { get; set; }
        [DataTableFieldAttribute("SchoolId", 4, typeof(long))]
        public long SchoolId { get; set; }
        [DataTableFieldAttribute("AcademicYearId", 5, typeof(long))]
        public long AcademicYearId { get; set; }
        [DataTableFieldAttribute("NextAcademicYearId", 6, typeof(long))]
        public long NextAcademicYearId { get; set; }
    }
    #endregion
}
