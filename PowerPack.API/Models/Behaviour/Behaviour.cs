using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Models
{
    public class Behaviour
    {
        public Behaviour() { }
        public Behaviour(int _behaviourId)
        {
            Behaviour_ID = _behaviourId;
        }
        public int Behaviour_ID { get; set; }
        public string Student_ID { get; set; }
        public string Student_Name { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
        public string Recorded_by { get; set; }
        public string Recorded_Date { get; set; }

    }
    public class BehaviourDetails
    {
        public BehaviourDetails() { }
        public BehaviourDetails(int _behaviourId)
        {
            Behaviour_ID = _behaviourId;
        }
        public int Behaviour_ID { get; set; }

        public int Category_ID { get; set; }
        public int SubCategory_ID { get; set; }
        public int Points { get; set; }
        public int Activity_ID { get; set; }
        public int Location_ID { get; set; }
        public DateTime? Incident_Date { get; set; }
        public string Incident_Time { get; set; }
        public string Period { get; set; }
        public string Comments { get; set; }
        public DateTime? Recorded_Date { get; set; }
        public int Status_ID { get; set; }
        public string Recorded_By { get; set; }
        public string DocPath { get; set; }
        public int OtherStaff_ID { get; set; }
        public DateTime? Followup_Date { get; set; }
        public string ReferredTo { get; set; }
        public string FollowupComments { get; set; }

        public string otherStudentEnvolved { get; set; }
        public string WitnessStudentIds { get; set; }
        public string WitnessStaffIds { get; set; }
        public string WitnessStatement { get; set; }

    }

    public class StudentBehaviour
    {

        public int BehaviourId { get; set; }
        public long StudentId { get; set; }
        public string BehaviourType { get; set; }

        public string BehaviourLogo { get; set; }

        public int Behaviourpoint { get; set; }

        public DateTime ModifiedOn { get; set; }
        public int IsActive { get; set; }

        public int CategoryId { get; set; }

        public string BehaviourComment { get; set; }

        public string UploadedFilePath { get; set; }

        public string FileName { get; set; }
        public int FileCount { get; set; }

        public long SchoolId { get; set; }
    }

    public class StudentBehaviourFiles
    {
        public int FileId { get; set; }
        public long StudentId { get; set; }

        public int BehaviourId { get; set; }

        public string FileName { get; set; }
        public string UploadedFilePath { get; set; }

    }

    public class IncidentListModel
    {
        public IncidentListModel()
        {
            IncidentStudentLists = new List<IncidentStudentList>();
            IncidentWitnesses = new List<IncidentWitness>();
        }
        public long IncidentId { get; set; }
        public DateTime Incident_Date { get; set; }
        public string Incident_Type { get; set; }
        public DateTime Recorded_On { get; set; }
        public string Reported_By { get; set; }
        public string Incident_Time { get; set; }
        public long Reported_ById { get; set; }
        public string Incident_Remarks { get; set; }
        public int Incident_CategoryId { get; set; }
        public int Incident_SubCategoryId { get; set; }
        public IEnumerable<IncidentStudentList> IncidentStudentLists { get; set; }
        public IEnumerable<IncidentWitness> IncidentWitnesses { get; set; }
    }

    public class IncidentStudentList
    {
        public long STUDENT_ID { get; set; }
        public string STUDENT_NO { get; set; }
        public string STUDENT_NAME { get; set; }
        public string Student_Image_url { get; set; }
        public string SECTION { get; set; }
        public string GRADE { get; set; }
        public string STREAM { get; set; }
        public string SHIFT { get; set; }
        public string PRIMARY_CONTACT { get; set; }
        public string PARENTEMAIL { get; set; }
        public string PARENTMOBILE { get; set; }
        public string PARENT_NAME { get; set; }
        public string IsConfidential { get; set; }
        public long InvolvedId { get; set; }
        public int FollowupCount { get; set; }
        public long ActionId { get; set; }
    }

    public class ChartModel
    {
        public string GRADE { get; set; }
        public string IncidentType { get; set; }
        public int IncidentCount { get; set; }
    }

    public class IncidentStaffList
    {
        public int EmpId { get; set; }
        public string EmpNo { get; set; }
        public string EmployeeName { get; set; }
    }

    public class IncidentEntry
    {
        public IncidentEntry()
        {
            StudentInvolved = new List<IncidentStudentInvolved>();
            Witness = new List<IncidentWitness>();
        }
        public int BehaviourId { get; set; }
        public int SchoolId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? IncidentDate { get; set; }
        public string IncidentTime { get; set; }
        public IncidentType IncidentType { get; set; }
        public long StaffId { get; set; }
        public string IncidentDesc { get; set; }
        public string DataMode { get; set; }
        public int CategoryId { get; set; }
        public long LevelMapping_ID { get; set; }
        #region Student Involved 
        public List<IncidentStudentInvolved> StudentInvolved { get; set; }
        public DataTable StudentInvolvedDT
        {
            get
            {
                var dt = this.CreateStudentDT();
                StudentInvolved.ForEach(e =>
                {
                    DataRow dr = dt.NewRow();
                    dr["INVOLVED_ID"] = e.InvolvedId;
                    dr["INVOLVED_STUDENT_ID"] = e.InvolvedStudentId;
                    dr["INVOLVED_CONFIDENTIAL"] = Convert.ToInt32(e.IsConfidential);
                    dr["INVOLVED_DATAMODE"] = e.DataMode;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
        private DataTable CreateStudentDT()
        {
            var dt = new DataTable();
            dt.Columns.Add("INVOLVED_ID", typeof(long));
            dt.Columns.Add("INVOLVED_STUDENT_ID", typeof(long));
            dt.Columns.Add("INVOLVED_DATAMODE", typeof(string));
            dt.Columns.Add("INVOLVED_CONFIDENTIAL", typeof(int));
            return dt;
        }
        #endregion

        #region witness Involved 
        public List<IncidentWitness> Witness { get; set; }
        public DataTable WitnessDT
        {
            get
            {
                var dt = this.CreateWitnessDT();
                Witness.ForEach(e =>
                {
                    DataRow dr = dt.NewRow();
                    dr["WITNESS_ID"] = e.WitnessId;
                    dr["WITNESS_INVOLVED_ID"] = e.WitnessInvolvedId;
                    dr["WITNESS_TYPE"] = e.WitnessType.ToString();
                    dr["WITNESS_REMARKS"] = e.WitnessRemark;
                    dr["WITNESS_DATAMODE"] = e.WitnessDatamode;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
        private DataTable CreateWitnessDT()
        {
            var dt = new DataTable();
            dt.Columns.Add("WITNESS_ID", typeof(long));
            dt.Columns.Add("WITNESS_INVOLVED_ID", typeof(long));
            dt.Columns.Add("WITNESS_TYPE", typeof(string));
            dt.Columns.Add("WITNESS_REMARKS", typeof(string));
            dt.Columns.Add("WITNESS_DATAMODE", typeof(string));
            return dt;
        }
        #endregion
    }
    public enum IncidentType { FA = 0, FI = 1 }
    public enum WitnessType { STF = 0, STU = 1 }
    public class IncidentWitness
    {
        private long _iD;
        private long _bM_ID;
        private long _wITNESS_INVOLVED_ID;
        private string _wITNESS_TYPE;
        private string _wITNESS_REMARKS;
        private string _wITNESS_NAME;

        public long WitnessId { get; set; }
        public long IncidentId { get; set; }
        public long WitnessInvolvedId { get; set; }
        public string WitnessInvolvedName { get; set; }
        public WitnessType WitnessType { get; set; }
        public string WitnessRemark { get; set; }
        public string WitnessDatamode { get; set; }
        #region DB Fields
        public long ID { get { return _iD; } set { WitnessId = value; _iD = value; } }
        public long BM_ID { get { return _bM_ID; } set { IncidentId = value; _bM_ID = value; } }
        public long WITNESS_INVOLVED_ID { get { return _wITNESS_INVOLVED_ID; } set { WitnessInvolvedId = value; _wITNESS_INVOLVED_ID = value; } }
        public string WITNESS_NAME { get => _wITNESS_NAME; set { WitnessInvolvedName = value; _wITNESS_NAME = value; } }
        public string WITNESS_TYPE { get { return _wITNESS_TYPE; } set { WitnessType = Enum.Parse<WitnessType>(value, true); _wITNESS_TYPE = value; } }
        public string WITNESS_REMARKS { get { return _wITNESS_REMARKS; } set { WitnessRemark = value; _wITNESS_REMARKS = value; } }
        #endregion
    }
    public class IncidentStudentInvolved
    {
        public long InvolvedId { get; set; }
        public long InvolvedStudentId { get; set; }
        public string DataMode { get; set; }
        public bool IsConfidential { get; set; }
    }

    public class BehaviourAction
    {
        private const string Yes = "Yes";
        private long _actionId;
        private string _b_ParentCalled;
        private string _parent_Remarks;
        private DateTime _parent_Called_Date;
        private string _b_Parent_Interviewed;
        private string _parent_Interview_Remarks;
        private DateTime _parent_Interview_Date;
        private string _b_Notes_On_Planner;
        private DateTime _notes_On_Planner_Date;
        private string _b_Break_Detention;
        private DateTime _break_Detention_Date;
        private string _b_After_School_Detention;
        private DateTime _after_School_Detention_Date;
        private string _b_Suspension;
        private DateTime _suspension_Date;
        private string _b_Ref_Counseller;
        private DateTime _ref_Counseller_Date;
        private DateTime _entry_Date;
        private double _score;

        public bool ParentCalled { get; set; }
        public DateTime? ParentCalledDate { get; set; }
        public string ParentCalledComment { get; set; }
        public bool ParentInterviewed { get; set; }
        public DateTime? ParentInterviewedDate { get; set; }
        public string ParentInterviewedComment { get; set; }
        public bool NotesInStudentPlanner { get; set; }
        public DateTime? NotesInStudentPlannerDate { get; set; }
        public bool BreakDetentionGiven { get; set; }
        public DateTime? BreakDetentionGivenDate { get; set; }
        public bool AfterSchoolDetentionGiven { get; set; }
        public DateTime? AfterSchoolDetentionGivenDate { get; set; }
        public bool Suspension { get; set; }
        public DateTime? SuspensionDate { get; set; }
        public bool ReferredToStudentsCounsellor { get; set; }
        public DateTime? ReferredToStudentsCounsellorDate { get; set; }
        public BasicDetails StudentDetails { get; set; }
        public long IncidentId { get; set; }
        public long StudentId { get; set; }
        public long CategoryId { get; set; }
        public string DataMode { get; set; }

        #region DB Fields
        public long ActionId { get => _actionId; set { _actionId = value; } }
        public string b_ParentCalled { get => _b_ParentCalled; set { ParentCalled = value == Yes; _b_ParentCalled = value; } }
        public string Parent_Remarks { get => _parent_Remarks; set { ParentCalledComment = value; _parent_Remarks = value; } }
        public DateTime Parent_Called_Date { get => _parent_Called_Date; set { ParentCalledDate = CheckNullDateTime(value); _parent_Called_Date = value; } }
        public string b_Parent_Interviewed { get => _b_Parent_Interviewed; set { ParentInterviewed = value == Yes; _b_Parent_Interviewed = value; } }
        public string Parent_Interview_Remarks { get => _parent_Interview_Remarks; set { ParentInterviewedComment = value; _parent_Interview_Remarks = value; } }
        public DateTime Parent_Interview_Date { get => _parent_Interview_Date; set { ParentInterviewedDate = CheckNullDateTime(value); _parent_Interview_Date = value; } }
        public string b_Notes_On_Planner { get => _b_Notes_On_Planner; set { NotesInStudentPlanner = value == Yes; _b_Notes_On_Planner = value; } }
        public DateTime Notes_On_Planner_Date { get => _notes_On_Planner_Date; set { NotesInStudentPlannerDate = CheckNullDateTime(value); _notes_On_Planner_Date = value; } }
        public string b_Break_Detention { get => _b_Break_Detention; set { BreakDetentionGiven = value == Yes; _b_Break_Detention = value; } }
        public DateTime Break_Detention_Date { get => _break_Detention_Date; set { BreakDetentionGivenDate = CheckNullDateTime(value); _break_Detention_Date = value; } }
        public string b_After_School_Detention { get => _b_After_School_Detention; set { AfterSchoolDetentionGiven = value == Yes; _b_After_School_Detention = value; } }
        public DateTime After_School_Detention_Date { get => _after_School_Detention_Date; set { AfterSchoolDetentionGivenDate = CheckNullDateTime(value); _after_School_Detention_Date = value; } }
        public string b_Suspension { get => _b_Suspension; set { Suspension = value == Yes; _b_Suspension = value; } }
        public DateTime Suspension_Date { get => _suspension_Date; set { SuspensionDate = CheckNullDateTime(value); _suspension_Date = value; } }
        public string b_Ref_Counseller { get => _b_Ref_Counseller; set { ReferredToStudentsCounsellor = value == Yes; _b_Ref_Counseller = value; } }
        public DateTime Ref_Counseller_Date { get => _ref_Counseller_Date; set { ReferredToStudentsCounsellorDate = CheckNullDateTime(value); _ref_Counseller_Date = value; } }
        public DateTime Entry_Date { get => _entry_Date; set { _entry_Date = value; } }
        public double Score { get => _score; set { _score = value; } }
        #endregion
        private DateTime? CheckNullDateTime(DateTime date)
        {
            if (date == new DateTime(1900, 1, 1).Date)
                return null;
            else
                return date;
        }
    }
    public class BehaviourActionFollowup
    {
        public long ActionDetailsId { get; set; }
        public long IncidentId { get; set; }
        public long ActionId { get; set; }
        public DateTime ActionDate { get; set; }
        public string Action_Followup_Remarks { get; set; }
        public long Action_FollowupBy_Id { get; set; }
        public long Action_FollowupBy_Designation_Id { get; set; }
        public string Action_FollowupBy_EmpNo { get; set; }
        public string Action_FollowupBy_EmpName { get; set; }
        public string Action_FollowupBy_Designation { get; set; }
        public string Action_FollowupBy_DesignationGroup { get; set; }
        public long Action_CurrentUser_DesignationId { get; set; }
        public string DataMode { get; set; }
    }
    public class FollowUpStaff
    {
        public long EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
    }
    public class FollowUpDesignation
    {
        public long DESIGNATION_ID { get; set; }
        public string DESIGNATION_DESCRIPTION { get; set; }
    }

    public class StudentMeritList
    {

        public int TimeTableID { get; set; }
        public string Student_Name { get; set; }
        public string Student_No { get; set; }
        public string Student_ID { get; set; }
        public string Student_Image_url { get; set; }
        public string Student_Grade { get; set; }
        public string Student_Section { get; set; }
        public string Student_Flag_Status { get; set; }
        public int Behaviourpoint { get; set; }
        public int PositivePoint { get; set; }
        public int NegativePoint { get; set; }
        public long MeritId { get; set; }

        public DateTime? IncidentDate { get; set; }

    }


    public class SubCategories
    {
        public long MeritId { get; set; }
        public long StudentId { get; set; }
        public long CategoryId { get; set; }
        public int CategoryScore { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        public string UploadedPath { get; set; }
        public int MeritUploaded { get; set; }
        public long LevelMapping_ID { get; set; }


    }

    public class StudentBehaviourMerit
    {
        public long MeritId { get; set; }

        public string MeritType { get; set; }

        public string MeritRemarks { get; set; }

        public int MeritCategoryId { get; set; }

        public int MeritSubCategoryId { get; set; }

        public string MeritUpload { get; set; }

        public int MeritUploaded { get; set; }

        public long StudentId { get; set; }

        public string[] StudentIds { get; set; }

        public string[] MeritDemertIds { get; set; }


    }


    public class MeritDemerit
    {
        public MeritDemerit()
        {
            objListOfCategories = new List<CategoryDetails>();
            objMeritDemerit = new StudentBehaviourMerit();
        }
        public StudentBehaviourMerit objMeritDemerit { get; set; }

        public List<CategoryDetails> objListOfCategories { get; set; }


    }

    public class CategoryDetails
    {
        public long StudentId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public long LevelMappingId { get; set; }
    }

    #region Student Point Category
    public class StudentPointCategory
    {
        public string Student_Image_url { get; set; }
        public string Student_Name { get; set; }
        public long Student_No { get; set; }
        public long Student_ID { get; set; }
        public string Student_Grade { get; set; }
        public string Student_Section { get; set; }
        public int Student_Points { get; set; }
        public string Cetificate_Description { get; set; }
        public long Certificate_Id { get; set; }
        public long CertificateType { get; set; }
        public bool IsEmail { get; set; }
        public bool IsPrint { get; set; }
        public bool IsEmailOther { get; set; }
        public string FilePath { get; set; }
        public List<CertificateProcessLog> Certificates { get; set; }
    }
    public class CertificateProcessLog
    {
        [Helpers.DataTableField("CertificateProcessLogId", 1)]
        public long CertificateProcessLogId { get; set; }
        [Helpers.DataTableField("CRB_ACD_ID", 2)]
        public long AcademicYearId { get; set; }
        [Helpers.DataTableField("CRB_BSU_ID", 3)]
        public long SchoolId { get; set; }
        [Helpers.DataTableField("CRB_STU_ID", 4)]
        public long StudentId { get; set; }
        [Helpers.DataTableField("CRB_TemplateId", 5)]
        public long TemplateId { get; set; }
        public string TemplateName { get; set; }
        [Helpers.DataTableField("CRB_ActionType", 6)]
        public int ActionType { get; set; }
        [Helpers.DataTableField("CRB_CreatedBy", 7)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }
    }
    #endregion
}
