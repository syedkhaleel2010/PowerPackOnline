using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Models
{
    #region Made By Dhanaji

    public class SubjectMaster
    {
        public long SubjectId { get; set; }
        public string Subject_Description { get; set; }
        public bool IsLanguage { get; set; }
        public string Subject_ShortCode { get; set; }
        public string Subject_BoardCode { get; set; }
        public long CurriculumId { get; set; }
        public string Curriculum_Description { get; set; }
        public long SyllabusId { get; set; }
    }
    public class SubjectGroup
    {
        public long ACD_ID { get; set; }
        public int GroupId { get; set; }
        public int SubjectGradeId { get; set; }
        public string GradeId { get; set; }
        public int ShiftId { get; set; }
        public int StreamId { get; set; }
        public string Group_Description { get; set; }
        public string Grade_Display { get; set; }
        public string Shift_Description { get; set; }
        public string Stream_Description { get; set; }
        public string SubjectGrade_Description { get; set; }
        public string SubjectGrade_Parent { get; set; }
        public string SubjectGroup_UNTIS { get; set; }
        public string StudentListId { get; set; }
        public string SelectedStudentListId { get; set; }
        public string SelectedStudentListSSD { get; set; }
        public string SelectedStudentListXML { get; set; }
        public string RemovedStudentListXML { get; set; }
        public IEnumerable<SubjectGroupStudent> SubjectGroupStudentList { get; set; }
        public IEnumerable<SubjectGroupStudent> SubjectGroupSelectedStudentList { get; set; }
        public SubjectGroupTeacher SubjectGroupTeacher { get; set; }
        public string Username { get; set; }
        public long SchoolId { get; set; }
        public int SectionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class SubjectGroupTeacherDdl
    {
        public int EMP_ID { get; set; }
        public string EMP_NAME { get; set; }
    }
    public class SubjectGroupTeacher
    {
        public long? TeacherId { get; set; }
        public int? GroupTeacherId { get; set; }
        public string TeacherName { get; set; }
        public string GroupTeacherSchedule { get; set; }
        public string GroupTeacherRoom { get; set; }
        public DateTime? FromDate { get; set; }
    }
    public class SubjectGroupStudent
    {
        public long StudentId { get; set; }
        public long StudentGroupId { get; set; }
        public string StudentNo { get; set; }
        public string Student_Name { get; set; }
        public string Section { get; set; }
        public long SectionId { get; set; }
        public string Option_Description { get; set; }
        public string Religion { get; set; }
    }
    public class SubjectGroupDdl
    {
        public int SGR_ID { get; set; }
        public string SGR_DESCR { get; set; }
    }
    public class BindMandatorySubject
    {
        public int SubjectGrade_Id { get; set; }
        public string SubjectGrade_Description { get; set; }
        public string SubjectGroup_DDL { get; set; }
    }
    public class BindOptionalSubject
    {
        public int OptionId { get; set; }
        public string Option_Description { get; set; }
        public string SubjectGrade_DDL { get; set; }
    }
    public class ChangeGroupData
    {
        public long SSD_ACD_ID { get; set; }
        public string SSD_GRD_ID { get; set; }
        public long SSD_SBG_ID { get; set; }
        public long SSD_SGR_ID { get; set; }
        public long SSD_SCT_ID { get; set; }
        public long SSD_STU_ID { get; set; }
        public bool IS_OPTIONAL { get; set; }
    }
    public class ChangeSelectedStudentGroup
    {
        public long MoveToGroupId { get; set; }
        public string StudentGroupIds { get; set; }
    }
    public class SelectedOptionByStudent
    {
        public int SubjectId { get; set; }
        public int SubjectGradeId { get; set; }
        public int OptionId { get; set; }
        public int GroupId { get; set; }
        public int SSD_STU_ID { get; set; }
    }
    #endregion
    public class SubjectByGradeParent
    {

        public string GradeId { get; set; }

        public int StreamId { get; set; }

        public string Grade_Display { get; set; }

        public string Stream_Description { get; set; }

        public int Grade_Order { get; set; }

    }
    public class SubjectByGradeChild
    {

        public int SubjectGradeId { get; set; }

        public int SubjectId { get; set; }

        public string SubjectGrade_Description { get; set; }

        public string SubjectGrade_ShortCode { get; set; }

        public int SubjectGrade_DepartmentId { get; set; }

        public string Subject_Department_Description { get; set; }

        public bool b_IsOptional { get; set; }

        public string OptionIds { get; set; }

        public string Option_Description { get; set; }

        public int Subject_ParentId { get; set; }

        public bool b_DisplayOnReportCard { get; set; }

        public bool b_DisplayMarks { get; set; }

        public string Subject_Description { get; set; }

        public int Display_Order { get; set; }

        public bool b_TC_Display { get; set; }

        public string SubjectGrade_ParentShortCode { get; set; }

        public bool b_IsCore { get; set; }

        public bool b_AutoGroup { get; set; }

        public bool b_Major { get; set; }

        public string MarkType { get; set; }

        public double Credits { get; set; }

        public double WT { get; set; }

        public string LENG { get; set; }

        public string HRS { get; set; }

        public string GPA { get; set; }
        public int StreamId { get; set; }
        public string GradeId { get; set; }
        public double MinMark { get; set; }
        public bool b_Retest { get; set; }
        public bool b_BrownbookDisplay { get; set; }
        public bool b_Btech { get; set; }
        public bool SBG_Level { get; set; }
        public bool SBG_bATT_CALCULATION { get; set; }
        public bool SBG_bTRANSCRIPT { get; set; }
        public bool SBG_bREPORTCARD { get; set; }
        public bool SBG_bGPA { get; set; }
        public bool SBG_bHonorRoll { get; set; }
        public int SBG_CREDIT_VALUE { get; set; }
        public string SBG_CREDIT_TYPE { get; set; }
    }

    public class ParentSubject : SubjectByGradeChild
    {
        public int ParentId { get; set; }
        public bool IsPrequisite { get; set; }
    }

    public class FromStream
    {
        public int STM_ID { get; set; }
        public string STM_DESCR { get; set; }
    }


    public class ShiftModel
    {
        public int SHF_ID { get; set; }
        public string SHF_DESCR { get; set; }
    }

    public class SubjectByGradeEntry
    {
        /// <summary>
        /// to check if child data is present and depending on that disable/enable copy feature
        /// </summary>
        public bool IsChildGradeIdPresent { get; set; }
        public int FromGradeId { get; set; }
        public int FromStreamId { get; set; }
        public string ShortCode { get; set; } = null;
        public int SubjectId { get; set; }
        public int DepartmentId { get; set; }
        public string Description { get; set; }
        public bool SubjectType { get; set; }
        public string ParentSubject { get; set; }
        public string ParentSubjectDescription { get; set; }
        public string OptionName { get; set; }
        public string OptionNamesJoin { get; set; }
        public string OptionNamesXML { get; set; }
        public double? MinimumMarks { get; set; }
        public bool b_DisplaySubjectInTC { get; set; }
        public bool b_DisplaySubjectInReportCard { get; set; }
        public bool b_DisplayInExcel { get; set; }
        public bool b_BtecSubject { get; set; }
        public bool b_Retest { get; set; }
        public bool b_MarkAsOptional { get; set; }
        public bool b_DisplayMarksInReportCard { get; set; }
        public bool? b_EnterMarks { get; set; }
        public bool AutoGroup { get; set; }
        public int? SubjectGradeId { get; set; }
        public string AcademicYear { get; set; }
        public string Grade { get; set; }
        public string Stream { get; set; }
        public long ACD_ID { get; set; }
        public long BSU_ID { get; set; }
        public string GRD_ID { get; set; }
        public int STM_ID { get; set; }
        public int DisplayOrder { get; set; }
        public bool b_IsCor { get; set; }
        public double Credits { get; set; }
        public double WT { get; set; }
        public string LENG { get; set; }
        public string HRS { get; set; }
        public string GPA { get; set; }
        public SelectList FromGrade { get; set; }
        public SelectList FromStream { get; set; }
        public SelectList SubjectMasters { get; set; }
        public SelectList Department { get; set; }
        public SelectList ParentSubjects { get; set; }
        public SelectList OptionNames { get; set; }
        public List<SubjectByGradeChild> SubjectByGradeChildrens { get; set; }
        public bool SBG_Level { get; set; } = true;
        public bool SBG_bATT_CALCULATION { get; set; }
        public bool SBG_bTRANSCRIPT { get; set; }
        public bool SBG_bREPORTCARD { get; set; }
        public bool SBG_bGPA { get; set; }
        public bool SBG_bHonorRoll { get; set; }
        public int SBG_CREDIT_VALUE { get; set; }
        public string SBG_CREDIT_TYPE { get; set; }
    }
}
