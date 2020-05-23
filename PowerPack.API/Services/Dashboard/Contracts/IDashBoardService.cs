using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface IDashBoardService
    {
        Task<IEnumerable<Dashboard>> GetDashbardLayoutBySchoolId(long SchoolId);
        Task<IEnumerable<DashBoardLayout>> GetDashBoardWidgetByLayoutId(long layoutId, long SchoolId, long AcademicYearId, string UserRoleIds);
        Task<StudentMetricsCountAttendance> GetStudentMetricsCountAttendance(long SchoolId);

        Task<BudgetPercentagePhysical> GetBudgetPercentagePhysical(long SchoolId);

        Task<StudentMetricsCount> GetStudentMetricsCount(long SchoolId);

        Task<IEnumerable<FormTutorPoints>> GetFormTutorPoints(long ACD_ID, long OPTION);
        Task<IEnumerable<TotalPositiveNegative>> TotalPositiveNegative(long ACD_ID, long OPTION);

        Task<IEnumerable<FeeAgeing>> FeeAgeing(long SchoolId);
        Task<IEnumerable<OverallHousePoints>> OverallHousePoints(long ACD_ID, long SchoolId);
        bool SetDashboardLayout(List<DashBoardLayout> objLayout, long SchoolId, long AcademicYearId, long UserId, string LayoutName);

        Task<IEnumerable<FeeOutstanding>> FeeOutstanding(long SchoolId, long OPTION);
        Task<IEnumerable<GetGradeDetails>> GetGradeDetails(string GRD_ID, long ACD_ID, long SchoolId);
        Task<IEnumerable<AttendanceSummary>> AttendanceSummary(long ACD_ID, long SchoolId);
        
        Task<IEnumerable<ProgressTrackerChart>> ProgressTrackerChart(long ACD_ID);

        bool AssignRoleToDashboard(AssignDashboard objAssignDashboard, long UserId);
        Task<IEnumerable<DashboardWidgetList>> GetAllDashBoardWidget();
    }
}
