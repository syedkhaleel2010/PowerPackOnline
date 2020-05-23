using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class BasicDetails
    {
        public BasicDetails() { }
        //public BasicDetails(String _StudentId)
        //{
        //    Student_ID = _StudentId;
        //}
        public string Student_ID { get; set; }
        public string Student_Name { get; set; }
        public string Student_No { get; set; }
        public string Student_Image_url { get; set; }
        public string Student_Grade { get; set; }
        public string Student_Section { get; set; }
        public string Student_Age { get; set; }
        public string Student_Board { get; set; }
        public string Student_BSU_Name { get; set; }
        public string Student_ACD_YEAR { get; set; }

    }
    public class ParentDetails
    {
        public string Parent_Name { get; set; }
        public string Parent_Relation { get; set; }
        public string Parent_Mobile { get; set; }
        public string Parent_Email { get; set; }
        public string Parent_Occupation { get; set; }
        public string Parent_Country { get; set; }
        public string Parent_City { get; set; }
        public string Parent_Nationality { get; set; }
        public string Parent_Emirates { get; set; }
        public string Parent_Address { get; set; }
        public string Parent_Company { get; set; }

    }

    public class MedicalDetails
    {
        public string STU_ALLERGIES { get; set; }
        public string STU_SPMEDICATION { get; set; }
        public string STU_PHYSICAL { get; set; }
        public string STU_HEALTH { get; set; }
        public string STU_THERAPHY { get; set; }
        public string STU_SEN_REMARK { get; set; }
        public string STU_EAL_REMARK { get; set; }
        public string STU_MUSICAL { get; set; }
        public string STU_ENRICH { get; set; }
        public string STU_BEHAVIOUR { get; set; }
        public string STU_SPORTS { get; set; }
        public string STU_Visual_Disability { get; set; }
    }

    public class SiblingDetails
    {
        public string STU_PHOTOPATH { get; set; }
        public string STU_ID { get; set; }
        public string STU_NO { get; set; }
        public string STU_NAME { get; set; }
        public string GRD_DISPLAY { get; set; }
        public string SCT_DESCR { get; set; }
        public string STU_DOB { get; set; }
        public string Age { get; set; }
        public string BSU_NAME { get; set; }
    }
    public class StudentDashboardDetails
    {
        public string BEHAVIOUR_POINT_TOTAL { get; set; }
        public string BEHAVIOUR_POINT_DIFF { get; set; }
        public string ACTIVITIES_TOTAL { get; set; }
        public string ACT_TOTAL_DIFF { get; set; }
        public string Attencence { get; set; }
    }
    public class ActivitiesDetails
    {
        public string ALD_EVENT_NAME { get; set; }
        public string ALD_EVENT_DESCR { get; set; }
        public string PercentageCompletion { get; set; }
        public string Days_Total { get; set; }
    }
    public class AttendanceChart
    {
        public int Order { get; set; }
        public string TMONTH { get; set; }
        public string TOT_ATT { get; set; }
        public string ACD_DESC { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public double PresentPerc { get; set; }
    }
    public class AchievementsDetails
    {

    }
    public class BehaviorDetails
    {
        public long IncidentId { get; set; }
        public DateTime Incident_Date { get; set; }
        public string Incident_Type { get; set; }
        public DateTime Recorded_On { get; set; }
        public string Reported_By { get; set; }
        public string Incident_Time { get; set; }
        public long Reported_ById { get; set; }
        public long Incident_CategoryId { get; set; }
        public long Incident_SubCategoryId { get; set; }
        public string Incident_Remarks { get; set; }
    }
    public class AttendanceDetails
    {

    }
    public class AssessmentDetails
    {
        public string Subjects { get; set; }
        public string Term_1 { get; set; }
        public string Term_2 { get; set; }
        public string Term_3 { get; set; }
        public string Average { get; set; }

    }
    public class TransportDetails
    {
        public string STU_NAME { get; set; }
        public string PICKUPBUSNO { get; set; }
        public string DROPBUSNO { get; set; }
        public string PICKUP_LOCATION { get; set; }
        public string DROPOFF_LOCATION { get; set; }
        public string CONTACTNO { get; set; }
        public string PICKUP_TIME { get; set; }
        public string DROPOFF_TIME { get; set; }
        public string PROVIDER_BSU_NAME { get; set; }
    }
    public class AttendanceChartMain
    {
        public string ACD_YEAR_DESC { get; set; }
        public IEnumerable<AttendanceChart> AttendanceChart { get; set; }
    }
    public class StudentProfile
    {
        public StudentProfile()
        {
            BasicDetails = new List<BasicDetails>();
            ParentDetails = new List<ParentDetails>();
            MedicalDetails = new MedicalDetails();
            SiblingDetails = new List<SiblingDetails>();
            ActivitiesDetails = new List<ActivitiesDetails>();
            AchievementsDetails = new List<AchievementsDetails>();
            BehaviorDetails = new List<BehaviorDetails>();
            AttendanceDetails = new List<AttendanceDetails>();
            AssessmentDetails = new List<AssessmentDetails>();
            TransportDetails = new TransportDetails();
            StudentDashboardDetails = new StudentDashboardDetails();
            AttendanceChartMain = new AttendanceChartMain();
            AttendenceList = new List<AttendenceList>();
        }
        public IEnumerable<BasicDetails> BasicDetails { get; set; }
        public IEnumerable<ParentDetails> ParentDetails { get; set; }
        public MedicalDetails MedicalDetails { get; set; }
        public IEnumerable<SiblingDetails> SiblingDetails { get; set; }
        public IEnumerable<ActivitiesDetails> ActivitiesDetails { get; set; }
        public IEnumerable<AchievementsDetails> AchievementsDetails { get; set; }
        public IEnumerable<BehaviorDetails> BehaviorDetails { get; set; }
        public IEnumerable<AttendanceDetails> AttendanceDetails { get; set; }
        public IEnumerable<AssessmentDetails> AssessmentDetails { get; set; }
        public TransportDetails TransportDetails { get; set; }
        public StudentDashboardDetails StudentDashboardDetails { get; set; }
        public IEnumerable<AttendanceChart> AttendanceChart { get; set; }
        public AttendanceChartMain AttendanceChartMain { get; set; }
        public IEnumerable<AttendenceList> AttendenceList { get; set; }
    }





}
