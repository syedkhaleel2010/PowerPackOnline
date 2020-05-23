using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class Attendance
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
        public string transport_code { get; set; }
        public string transport_descr { get; set; }
        public long STREAM_ID { get; set; }
        public long SHIFT_ID { get; set; }
        public string ATT_SHORTCODE { get; set; }

        public long SectionId { get; set; }

    }
    public class ATTENDENCE_ANALYSIS
    {
        public string CODE { get; set; }
        public string DESCR { get; set; }
        public string Type { get; set; }
        public string Per { get; set; }
    }

    public class AttendenceList
    {
        public DateTime AttDate { get; set; }
        public string STU_ID { get; set; }
        public string code { get; set; }
        public string Descriptions { get; set; }
        public string DayOfWeek { get; set; }
        public int day1 { get; set; }
        public int DayOfWeek1 { get; set; }
    }

    public class RoomAttendance
    {

        public string Student_Name { get; set; }
        public long Student_ID { get; set; }
        public long TimeTableID { get; set; }
        public string Student_Image_url { get; set; }
        public string TransportDesc { get; set; }
        public string TransportCode { get; set; }

        public string STU_NO { get; set; }
        public string Grade { get; set; }
        public string SectionId { get; set; }
        public string Section { get; set; }
        public string DailyAttendance { get; set; }
        public bool IsInReport { get; set; }
        public long IsInReportID { get; set; }
    }

    public class RoomAttendanceHeader
    {
        public string SGR_ID { get; set; }
        public string Subject { get; set; }

        public bool IsActive { get; set; }

        public bool IsOptional { get; set; }

        public int PeriodNo { get; set; }

        public string OptionalHeader { get; set; }
    }

    public class StudentRoomAttendance
    {
        public long logId { get; set; }
        public long DetailId { get; set; }
        public string RoomDate { get; set; }
        public long StudentId { get; set; }
        public long SGR_ID { get; set; }
        public long Subject { get; set; }
        public long PeriodNo { get; set; }
        public bool IsOptional { get; set; }
        public string Status { get; set; }

        public string Remark { get; set; }

        public string Description { get; set; }
        public string OptionalHeader { get; set; }
    }

    public class StudentLogAttendance
    {
        public StudentLogAttendance()
        {
            objStudentLog = new List<StudentRoomAttendance>();
            objStudentAttendance = new List<StudentRoomAttendance>();
        }
        public List<StudentRoomAttendance> objStudentLog { get; set; }
        public List<StudentRoomAttendance> objStudentAttendance { get; set; }

    }




    #region Attendance Permission
    public class AttendancePermission
    {

        public long PermissionId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Grade { get; set; }
        public string Section { get; set; }
        public int AcademicYearId { get; set; }
        public string DisplayOrder { get; set; }
        public string Shift { get; set; }
        public string Stream { get; set; }
        public int StreamId { get; set; }
        public int ShiftId { get; set; }
        public int AuthorizedStaffId { get; set; }
        public string SectionId { get; set; }
        public int DivisionId { get; set; }
    }

    public class StaffDetails
    {
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }


    }

    public class AttendanceStaff
    {
        public int SAD_ID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }
    }
    #endregion


    public class ParameterSetting
    {
        public long APD_ID { get; set; }
        public string APD_BSU_ID { get; set; }
        public long APD_ACD_ID { get; set; }
        public string APD_PARAM_DESCR { get; set; }
        public long APD_APM_ID { get; set; }
        public bool APD_bSHOW { get; set; }
        public bool APD_bPHY_ABS { get; set; }
        public long ARP_ID { get; set; }
        public string ARP_DESCR { get; set; }
        public string ARP_DISP { get; set; }
        public int DivisionId { get; set; }
        public string ReportCategory { get; set; }
    }

    public class GradeDetails
    {
        public int fad_id { get; set; }
        public string FAD_DT { get; set; }

        public DateTime FAD_DATE { get; set; }
        public string FAD_MONTH { get; set; }
        public string Grades { get; set; }
        public string GradesID { get; set; }
        public string FAD_DESCR { get; set; }
        public string FAD_CREATED_BY { get; set; }
        public long FAD_ACD_ID { get; set; }

        public int ACD_BSU_ID { get; set; }
        public string DataMode { get; set; }

    }

    public class GradeAndSection
    {
        public string GRD_ID { get; set; }
        public string GRM_DISPLAY { get; set; }
        public long SCT_ID { get; set; }
        public string SCT_DESCR { get; set; }
        public int DISPLAYORDER { get; set; }
    }

    public class AttendanceType
    {
        public int ATT_ID { get; set; }
        public int ACD_ID { get; set; }
        public string GRD_ID { get; set; }
        public DateTime FROMDT { get; set; }
        public DateTime TODT { get; set; }
        public string ATT_TYPE { get; set; }
        public string ACY_DESCR { get; set; }
        public int ACY_ID { get; set; }

        public int BSU_ID { get; set; }

        public int GRD_ORDER { get; set; }
        public string GRD_DESCR { get; set; }
        public int DivisionId { get; set; }
        public string DataMode { get; set; }

    }
    public class SchoolWeekEnd
    {
        public string WEEKEND1 { get; set; }
        public string WEEKEND2 { get; set; }
    }
    public class AttendanceCalendar
    {
        public AttendanceCalendar()
        {
            SCH_DATE = DateTime.Today;
            SCH_DTFROM = DateTime.Today;
            SCH_DTTO = DateTime.Today;
            SCH_WEEKEND1_WORK = string.Empty;
            SCH_WEEKEND2_WORK = string.Empty;
            SCH_REMARKS = string.Empty;
            SCH_TYPE = string.Empty;
            SchoolWeekEnd = new SchoolWeekEnd();
            selectedSectionList = new List<string>();
        }
        public long SCH_ID { set; get; }
        public DateTime SCH_DATE { set; get; }
        public long SCH_BSU_ID { set; get; }
        public long SCH_ACD_ID { set; get; }
        public DateTime SCH_DTFROM { set; get; }
        public DateTime SCH_DTTO { set; get; }
        public string SCH_REMARKS { set; get; }
        public string SCH_TYPE { set; get; }
        public bool SCH_bGRADEALL { set; get; }
        public string SCH_WEEKEND1_WORK { set; get; }
        public bool SCH_bWEEKEND1_LOG_BOOK { set; get; }
        public string SCH_WEEKEND2_WORK { set; get; }
        public bool SCH_bWEEKEND2_LOG_BOOK { set; get; }
        public SchoolWeekEnd SchoolWeekEnd { get; set; }
        public List<string> selectedSectionList { get; set; }
        public DataTable selectedSectionListDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("GRD_ID", typeof(string));
                dt.Columns.Add("SCT_ID", typeof(Int64));
                selectedSectionList.ToList().ForEach(item =>
                {
                    if (item.Split('_').Count() == 2)
                    {
                        string GRD_ID = item.Split('_')[1];
                        long SCT_ID = Convert.ToInt64(item.Split('_')[0]);
                        dt.Rows.Add(
                                       GRD_ID,
                                       SCT_ID
                                    );
                    }
                });
                return dt;
            }
        }
        public string SelectedGradeSection { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string GradeSectionDisplay { get; set; }
    }
    public class AcademicYearDetail
    {
        public long ACD_ID { set; get; }
        public string ACY_DESCR { set; get; }
        public long ACD_BSU_ID { set; get; }
        public long ACD_CLM_ID { set; get; }
        public DateTime ACD_STARTDT { set; get; }
        public DateTime ACD_ENDDT { set; get; }
        public bool ACD_CURRENT { set; get; }
    }

    public class AutomateAttendance
    {
        public AutomateAttendance()
        {
            FROMDATE = DateTime.Now;
            TODATE = DateTime.Now;
            GradeSectionList = new List<string>();
        }

        public long AAM_ACD_ID { get; set; }
        public long ATD_ID { get; set; }
        public long AAM_ID { get; set; }
        public string AAM_DESCR { get; set; }
        public DateTime FROMDATE { get; set; }
        public DateTime TODATE { get; set; }
        public bool AAM_bACTIVE { get; set; }
        public string APD_PARAM_DESCR { get; set; }
        public long BSU_ID { get; set; }
        public long APD_ID { get; set; }
        public string AAM_SCHEDULE { get; set; }
        public int DivisionId { get; set; }
        public List<string> GradeSectionList { get; set; }
        public DataTable selectedSectionListDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("GRD_ID", typeof(string));
                dt.Columns.Add("SCT_ID", typeof(Int64));
                GradeSectionList.ToList().ForEach(item =>
                {
                    if (item.Split('_').Count() == 2)
                    {
                        string GRD_ID = item.Split('_')[1];
                        long SCT_ID = Convert.ToInt64(item.Split('_')[0]);
                        dt.Rows.Add(
                                       GRD_ID,
                                       SCT_ID
                                    );
                    }
                });
                return dt;
            }
        }
        public string SelectedGradeSection { get; set; }
    }
    public class VerticalAttendanceGroup
    {
        public string AVG_GROUP_NAME { get; set; }
        public string Teachers { get; set; }
        public int StudentCount { get; set; }
        public string DataMode { get; set; }
        public int AVG_ID { get; set; }

        public int ACD_ID { get; set; }
    }
    public class SaveVerticalAttendanceGroupSetting
    {
        public string StudentName { get; set; }
        public string StaffName { get; set; }
        public int ACD_ID { get; set; }
        public int AVG_ID { get; set; }
        public string GroupName { get; set; }

        public string Group_ID { get; set; }
        public string DataMode { get; set; }

        public long STU_ID { get; set; }
        public long STU_NO { get; set; }
        public long EMP_ID { get; set; }

        public DateTime FROMDT { get; set; }

        public string STU_IDList { get; set; }
        public string Emp_IDList { get; set; }


    }

    public class EmployeeVerticalAttendance : SaveVerticalAttendanceGroupSetting
    {
        public long AVT_ID { get; set; }
        public long AVT_AVG_ID { get; set; }
        public long AVT_EMP_ID { get; set; }
        public long AVT_FROMDT { get; set; }
    }
    public class StudentVerticalAttendance : SaveVerticalAttendanceGroupSetting
    {
        public long AVSG_ID { get; set; }
        public long AVSG_AVG_ID { get; set; }
        public long AVSG_ACD_ID { get; set; }
        public long AVSG_STU_ID { get; set; }
    }
    public class VerticalAttendanceGroupSetting : SaveVerticalAttendanceGroupSetting
    {
        public VerticalAttendanceGroupSetting()
        {
            EmployeeVerticalAttendanceGroupSettingList = new List<EmployeeVerticalAttendance>();
            StudentVerticalAttendanceGroupSettingList = new List<StudentVerticalAttendance>();
        }
        public IEnumerable<EmployeeVerticalAttendance> EmployeeVerticalAttendanceGroupSettingList { get; set; }
        public DataTable EmployeeVerticalAttendanceGroupSettingDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AVT_ID", typeof(long));
                dt.Columns.Add("AVSG_ID", typeof(long));
                dt.Columns.Add("STU_EMP_ID", typeof(long));
                dt.Columns.Add("FROMDT", typeof(DateTime));
                dt.Columns.Add("DATAMODE", typeof(string));
                EmployeeVerticalAttendanceGroupSettingList.ToList().ForEach(x =>
                {
                    DataRow dr = dt.NewRow();
                    dr["AVT_ID"] = (object)x.AVT_ID ?? DBNull.Value;
                    dr["AVSG_ID"] = DBNull.Value;
                    dr["STU_EMP_ID"] = (object)x.Emp_IDList ?? DBNull.Value;
                    dr["FROMDT"] = (object)x.FROMDT ?? DBNull.Value;
                    dr["DATAMODE"] = (object)x.DataMode ?? DBNull.Value;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
        public IEnumerable<StudentVerticalAttendance> StudentVerticalAttendanceGroupSettingList { get; set; }
        public DataTable StudentVerticalAttendanceGroupSettingDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AVT_ID", typeof(long));
                dt.Columns.Add("AVSG_ID", typeof(long));
                dt.Columns.Add("STU_EMP_ID", typeof(long));
                dt.Columns.Add("FROMDT", typeof(DateTime));
                dt.Columns.Add("DATAMODE", typeof(string));
                StudentVerticalAttendanceGroupSettingList.ToList().ForEach(x =>
                {
                    DataRow dr = dt.NewRow();
                    dr["AVT_ID"] = DBNull.Value;
                    dr["AVSG_ID"] = (object)x.AVSG_ID ?? DBNull.Value;
                    dr["STU_EMP_ID"] = (object)x.STU_IDList ?? DBNull.Value;
                    dr["FROMDT"] = DBNull.Value;
                    dr["DATAMODE"] = (object)x.DataMode ?? DBNull.Value;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
    }

    #region Daily Attendance
    public class GradeSectionAccess
    {
        public string GradeId { get; set; }
        public string GradeDescription { get; set; }
        public int GradeDisplayOrder { get; set; }
        public long SectionId { get; set; }
        public string SectionDescription { get; set; }
    }
    #endregion

    #region Leave approval permission
    public class LeaveApprovalPermissionModel
    {
        public long AcdId { get; set; }
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public long SchoolId { get; set; }
        public string GradeId { get; set; }
        public string GradeDescription { get; set; }
        public long SalId { get; set; }
        public long SAL_ACD_ID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int SAL_NDAYS { get; set; }
        public int GradeDisplayOrder { get; set; }
        public int DivisionId { get; set; }
    }
    #endregion

    #region Schedule Attendance Email
    public class ScheduleAttendanceEmail
    {
        public ScheduleAttendanceEmail()
        {
            SAE_FROMDT = DateTime.Now;
            SAE_TODT = DateTime.Now;
            SAE_TIME = DateTime.Now.ToString("HH:mm");
        }
        public long SAE_ID { get; set; }
        public long SAE_BSU_ID { get; set; }
        public string SAE_GRD_IDS { get; set; }
        public DateTime SAE_FROMDT { get; set; }
        public DateTime SAE_TODT { get; set; }
        public bool SAE_bENABLED { get; set; }
        public string SAE_TIME { get; set; }
        public string SAE_PARAMETERS { get; set; }
        public string SAE_EMAILCONTENT { get; set; }
        public string SAE_USR_ID { get; set; }
        public bool SAE_ALERT_BOTH_PARENT { get; set; }
        public int DivisionId { get; set; }

    }
    #endregion  Schedule Attendance Email


    #region Attendance Period

    public class AttendacePeriodSetting
    {
        public long AttendancePeriodId { get; set; }
        public int PeriodNo { get; set; }
        public string Weightage { get; set; }
        public string Comment { get; set; }


    }

    #endregion

    public class AttendanceSessionType
    {
        public string AttendanceType { get; set; }
        public string AttendanceDescription { get; set; }

    }

    public class AttendanceBulkUpload
    {
        public AttendanceBulkUpload()
        {
            UploadDataModels = new List<AttendanceBulkUploadDataModel>();
        }
        public List<AttendanceBulkUploadDataModel> UploadDataModels { get; set; }
        public DataTable UploadDataModelsDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ADB_StudentNo", typeof(long));
                dt.Columns.Add("ADB_Date", typeof(string));
                UploadDataModels.ForEach(x =>
                {
                    DataRow dr = dt.NewRow();
                    dr["ADB_StudentNo"] = x.StudentNumber;
                    dr["ADB_Date"] = x.Date.ToString("dd-MMM-yyyy");
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
        public string AttendanceType { get; set; }
        public long BSU_ID { get; set; }
        public long ACD_ID { get; set; }        
        public long APD_ID { get; set; }
        public string Username { get; set; }
    }
    public class AttendanceBulkUploadDataModel
    {
        [Helpers.DataTableField("ADB_StudentNo", 1, typeof(long))]
        public long StudentNumber { get; set; }
        [Helpers.DataTableField("ADB_Date", 2,typeof(DateTime))]
        public DateTime Date { get; set; }
    }
    public class AttendanceBulkUploadValidationModel
    {
        public long ADB_StudentNo { get; set; }
        public long STATUS { get; set; }
    }
}
