using SIMS.API.Models;
using SIMS.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IDashBoardRepository _dashBoardRepository;
        public DashBoardService(IDashBoardRepository dashBoardRepository)
        {
            _dashBoardRepository = dashBoardRepository;
        }
        public async Task<IEnumerable<Dashboard>> GetDashbardLayoutBySchoolId(long SchoolId)
        {
            return await _dashBoardRepository.GetDashbardLayoutBySchoolId(SchoolId);
        }
        public async Task<IEnumerable<DashBoardLayout>> GetDashBoardWidgetByLayoutId(long layoutId, long SchoolId, long AcademicYearId, string UserRoleIds)
        {
            return await _dashBoardRepository.GetDashBoardWidgetByLayoutId(layoutId, SchoolId, AcademicYearId, UserRoleIds);
        }
        public async Task<StudentMetricsCountAttendance> GetStudentMetricsCountAttendance(long SchoolId)
        {
            return await _dashBoardRepository.GetStudentMetricsCountAttendance(SchoolId);
        }
        public async Task<BudgetPercentagePhysical> GetBudgetPercentagePhysical(long SchoolId)
        {
            return await _dashBoardRepository.GetBudgetPercentagePhysical(SchoolId);
        }
        
        public async Task<StudentMetricsCount> GetStudentMetricsCount(long SchoolId)
        {
            return await _dashBoardRepository.GetStudentMetricsCount(SchoolId);
        }
        public async Task<IEnumerable<FormTutorPoints>> GetFormTutorPoints(long ACD_ID, long OPTION)
        {
            return await _dashBoardRepository.GetFormTutorPoints(ACD_ID, OPTION);
        }

        public async Task<IEnumerable<TotalPositiveNegative>> TotalPositiveNegative(long ACD_ID, long OPTION)
        {
            return await _dashBoardRepository.TotalPositiveNegative(ACD_ID, OPTION);
        }

        public async Task<IEnumerable<FeeAgeing>> FeeAgeing(long SchoolId)
        {
            return await _dashBoardRepository.FeeAgeing(SchoolId);
        }
        public async Task<IEnumerable<GetGradeDetails>> GetGradeDetails(string GRD_ID, long ACD_ID, long SchoolId)
        {
            return await _dashBoardRepository.GetGradeDetails(GRD_ID, ACD_ID, SchoolId);
        }
        

        public async Task<IEnumerable<FeeOutstanding>> FeeOutstanding(long SchoolId, long OPTION)
        {
            return await _dashBoardRepository.FeeOutstanding(SchoolId, OPTION);
        }
        public async Task<IEnumerable<OverallHousePoints>> OverallHousePoints(long ACD_ID, long SchoolId)
        {
            return await _dashBoardRepository.OverallHousePoints(ACD_ID, SchoolId);
        }

        public async Task<IEnumerable<AttendanceSummary>> AttendanceSummary(long ACD_ID, long SchoolId)
        {
            return await _dashBoardRepository.AttendanceSummary(ACD_ID, SchoolId);
        }
        
        public async Task<IEnumerable<ProgressTrackerChart>> ProgressTrackerChart(long ACD_ID)
        {
            return await _dashBoardRepository.ProgressTrackerChart(ACD_ID);
        }

        
        public bool SetDashboardLayout(List<DashBoardLayout> objLayout, long SchoolId, long AcademicYearId, long UserId, string LayoutName)
        {
            return _dashBoardRepository.SetDashboardLayout(objLayout, SchoolId, AcademicYearId, UserId, LayoutName);
        }

        public bool AssignRoleToDashboard(AssignDashboard objAssignDashboard, long UserId)
        {
            return _dashBoardRepository.AssignRoleToDashboard(objAssignDashboard, UserId);
        }

        public async Task<IEnumerable<DashboardWidgetList>> GetAllDashBoardWidget()
        {
            return await _dashBoardRepository.GetAllDashBoardWidget();
        }
    }
}
