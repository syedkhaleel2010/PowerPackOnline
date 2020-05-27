using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Models
{
    public class Dashboard
    {
        public long Id { get; set; }
        public string layoutName { get; set; }
        public long SchoolId { get; set; }

        public long AcademicYearId { get; set; }
        public DateTime Date { get; set; }
        public long CreatedBy { get; set; }

        public bool IsSchool { get; set; }

        public bool IsAdmin { get; set; }

        public string UserRoleIds { get; set; }

    }
    public class DashBoardLayout
    {
        public long WidgetId { get; set; }
        public string WidgetDescription { get; set; }
        public string ColumnNumber { get; set; }
        public string RowNumber { get; set; }
        public string SizeX { get; set; }
        public string SizeY { get; set; }
        public long LayoutId { get; set; }
        public string LayoutName { get; set; }
        public long DetailsId { get; set; }

        public int Priority { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSchool { get; set; }
    }
    public class AssignDashboard
    {
        public long LayoutId { get; set; }
        public string UserRoleIds { get; set; }
        public bool IsAdminLayout { get; set; }
        public bool IsTeacherLayout { get; set; }
    }
    public class DashboardWidgetList
    {
        public long WidgetId { get; set; }
        public string WidgetDescription { get; set; }
        public string WidgetShortDescription { get; set; }

        public string WidgetFontAwesome { get; set; }

    }
    public class StudentMetricsCount
    {

        public string StudentStrengthatthebeginningofthemonth { get; set; }
        public string Additionsduringthemonthtilldate { get; set; }
        public string CanceledAdmissionsduringthemonthtilldate { get; set; }
        public string Deletionsduringthemonthtilldate { get; set; }
        public string StudentStrengthasoftoday { get; set; }

        public string FutureDatedAdmissions { get; set; }

    }
    public class StudentMetricsCountAttendance
    {
        public StudentMetricsCountAttendance()
        {
            StaffattendanceList = new List<Staffattendance>();
            StudentMetricsList = new List<StudentMetrics>();
        }
        public IEnumerable<Staffattendance> StaffattendanceList { get; set; }

        public IEnumerable<StudentMetrics> StudentMetricsList { get; set; }
    }

    public class BudgetPercentagePhysical
    {
        public BudgetPercentagePhysical()
        {
            Budget = new List<Budget>();
            Percentage = new List<Percentage>();
            Physical = new List<Physical>();
        }
        public IEnumerable<Budget> Budget { get; set; }

        public IEnumerable<Percentage> Percentage { get; set; }
        public IEnumerable<Physical> Physical { get; set; }
    }
    public class Budget
    {
        public string X { get; set; }
    }
    public class Percentage
    {
        public string X { get; set; }
    }
    public class Physical
    {
        public string X { get; set; }
    }
    public class Staffattendance
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int PRESENT { get; set; }

        public int ABSENT { get; set; }


    }
    public class StudentMetrics
    {
        public string Name { get; set; }
        public string Value { get; set; }

    }
    public class TotalPositiveNegative
    {
        public string X { get; set; }

        public string Y { get; set; }
    }
    public class FeeOutstanding
    {
        public string X { get; set; }

        public string Y { get; set; }

        public string Z { get; set; }
    }
    public class FeeAgeing
    {
        public string X { get; set; }

        public string Y { get; set; }

        public string Z { get; set; }
    }
    public class FormTutorPoints
    {
        public string HOUSE { get; set; }

        public string DIVISIONNAME { get; set; }

        public string SCORE { get; set; }

    }
    public class OverallHousePoints
    {
        public string X { get; set; }

        public string Y { get; set; }

        public string CSS { get; set; }

    }
    public class ProgressTrackerChart
    {
        public string Grade { get; set; }
        public string TERM { get; set; }
        public int TSM_ORDER { get; set; }
        public int ATTAINMENT_PERC { get; set; }
    }
    public class AttendanceSummary
    {
        public string GROUP_NAME { get; set; }
        public string GRD_ID { get; set; }
        public string GRD_DES { get; set; }

        public int TOT_STR { get; set; }

        public int TOT_MARKSTR { get; set; }
        public int TOT_PRS { get; set; }

        public int TOT_ABS { get; set; }


        public int TOT_PERC { get; set; }

    }

    public class GetGradeDetails
    {
        public string GRD_ID { get; set; }
        public string GRD_DES { get; set; }

        public int STU_SCT_ID { get; set; }

        public string SCT_DES { get; set; }

        public int STU_STRENGTH { get; set; }

        public int TOT_PRS { get; set; }
        public int ABS { get; set; }
        public int tot_mark { get; set; }

        public decimal PERC { get; set; }

    }
}
