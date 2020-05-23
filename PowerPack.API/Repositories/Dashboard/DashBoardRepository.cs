using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace SIMS.API.Repositories
{
    public class DashBoardRepository : SqlRepository<DashBoardLayout>, IDashBoardRepository
    {

        private readonly IConfiguration _config;

        public DashBoardRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }
        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<DashBoardLayout>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<DashBoardLayout> GetAsync(int id)
        {
            throw new NotImplementedException();
        }



        public override void InsertAsync(DashBoardLayout entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(DashBoardLayout entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Dashboard>> GetDashbardLayoutBySchoolId(long SchoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@schoolID", SchoolId, DbType.Int64);
                return await conn.QueryAsync<Dashboard>("Admin.GetDashbardLayoutBySchoolId", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<DashBoardLayout>> GetDashBoardWidgetByLayoutId(long layoutId, long SchoolId, long AcademicYearId, string UserRoleIds)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@layoutId", layoutId, DbType.Int64);
                parameters.Add("@SchoolId", SchoolId, DbType.Int64);
                parameters.Add("@AcademicYearId", AcademicYearId, DbType.Int64);
                parameters.Add("@UserRoleIds", UserRoleIds, DbType.String);
                return await conn.QueryAsync<DashBoardLayout>("Admin.GetDashBoardWidgetByLayoutId", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public bool SetDashboardLayout(List<DashBoardLayout> objLayout, long SchoolId, long AcademicYearId, long UserId, string LayoutName)
        {
            var parameters = new DynamicParameters();
            DataTable dt = new DataTable();
            dt.Columns.Add("WidgetId", typeof(long));
            dt.Columns.Add("WidgetDescription", typeof(string));
            dt.Columns.Add("ColumnNumber", typeof(string));
            dt.Columns.Add("RowNumber", typeof(string));

            dt.Columns.Add("SizeX", typeof(string));
            dt.Columns.Add("SizeY", typeof(string));
            dt.Columns.Add("LayoutId", typeof(long));
            dt.Columns.Add("LayoutName", typeof(string));
            dt.Columns.Add("DetailsId", typeof(long));
            foreach (var item in objLayout)
            {
                dt.Rows.Add(item.WidgetId, item.WidgetDescription, item.ColumnNumber, item.RowNumber, item.SizeX, item.SizeY, item.LayoutId, item.LayoutName, item.DetailsId);
            }

            parameters.Add("@schoolId", SchoolId, DbType.Int64);
            parameters.Add("@AcademicYearId", AcademicYearId, DbType.Int64);
            parameters.Add("@UserId", UserId, DbType.Int64);
            parameters.Add("@LayoutName", LayoutName, DbType.String);
            parameters.Add("@tbldashboardLayout", dt, DbType.Object);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("Admin.SetDashboardLayout", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }


        public async Task<BudgetPercentagePhysical> GetBudgetPercentagePhysical(long SchoolId)
        {
            BudgetPercentagePhysical BudgetPercentagePhysical = new BudgetPercentagePhysical();
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", SchoolId, DbType.String);
                var Obj = await conn.QueryMultipleAsync("SIMS.WIDGET_GET_Budget_Percentage_Physical", parameters, null, null, CommandType.StoredProcedure);
                return new BudgetPercentagePhysical
                {
                    Budget = await Obj.ReadAsync<Budget>(),
                    Percentage = await Obj.ReadAsync<Percentage>(),
                    Physical = await Obj.ReadAsync<Physical>()
                };
            }
        }
        public async Task<StudentMetricsCountAttendance> GetStudentMetricsCountAttendance(long SchoolId)
        {
            StudentMetricsCountAttendance StudentMetricsCountAttendance = new StudentMetricsCountAttendance();
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", SchoolId, DbType.String);
                var Obj = await conn.QueryMultipleAsync("SIMS.WIDGET_Student_Metrics_Count_Attendance", parameters, null, null, CommandType.StoredProcedure);
                return new StudentMetricsCountAttendance
                {
                    StaffattendanceList = await Obj.ReadAsync<Staffattendance>(),
                    StudentMetricsList = await Obj.ReadAsync<StudentMetrics>()
                };

                //var Staffattendance = await Obj.ReadAsync<Staffattendance>();
                //var totalStudentCount = await Obj.ReadAsync<StudentMetrics>();
                //StudentMetricsCountAttendance.Staffattendance = Staffattendance;



            }
        }

        public async Task<StudentMetricsCount> GetStudentMetricsCount(long SchoolId)
        {
            StudentMetricsCount obj = new StudentMetricsCount();
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", SchoolId, DbType.String);
                return await conn.QueryFirstOrDefaultAsync<StudentMetricsCount>("SIMS.WIDGET_StudentMetricsCount", parameters, null, null, CommandType.StoredProcedure);

            }
        }
        public async Task<IEnumerable<FormTutorPoints>> GetFormTutorPoints(long ACD_ID, long OPTION)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@OPTION", OPTION, DbType.Int64);
                return await conn.QueryAsync<FormTutorPoints>("SIMS.WIDGET_TutorPoints_Behaviour", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<TotalPositiveNegative>> TotalPositiveNegative(long ACD_ID, long OPTION)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@OPTION", OPTION, DbType.Int64);
                return await conn.QueryAsync<TotalPositiveNegative>("SIMS.WIDGET_TutorPoints_Behaviour", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<GetGradeDetails>> GetGradeDetails(string GRD_ID, long ACD_ID, long SchoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@BSU_ID", SchoolId, DbType.String);
                parameters.Add("@TODT", null, DbType.DateTime);

                return await conn.QueryAsync<GetGradeDetails>("SIMS.WIDGET_GetGRD_Details", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<FeeAgeing>> FeeAgeing(long SchoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", SchoolId, DbType.String);

                return await conn.QueryAsync<FeeAgeing>("SIMS.WIDGET_FeeAgeing", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<FeeOutstanding>> FeeOutstanding(long SchoolId, long OPTION)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", SchoolId, DbType.String);
                parameters.Add("@OPTION", OPTION, DbType.Int64);
                return await conn.QueryAsync<FeeOutstanding>("SIMS.WIDGET_GET_FEE_Outstanding", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<OverallHousePoints>> OverallHousePoints(long ACD_ID, long SchoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@BSU_ID", SchoolId, DbType.String);
                return await conn.QueryAsync<OverallHousePoints>("SIMS.WIDGET_AttendanceSummary", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<AttendanceSummary>> AttendanceSummary(long ACD_ID, long SchoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);
                parameters.Add("@BSU_ID", SchoolId, DbType.String);
                parameters.Add("@TODT", null, DbType.DateTime);
                return await conn.QueryAsync<AttendanceSummary>("SIMS.WIDGET_AttendanceSummary", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<ProgressTrackerChart>> ProgressTrackerChart(long ACD_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ACD_ID", ACD_ID, DbType.Int64);

                return await conn.QueryAsync<ProgressTrackerChart>("SIMS.WIDGET_GET_ProgressTracker", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public bool AssignRoleToDashboard(AssignDashboard objAssignDashboard, long UserId)
        {
            var parameters = new DynamicParameters();
            DataTable dt = new DataTable();
            dt.Columns.Add("LayoutId", typeof(long));
            dt.Columns.Add("UserRoleIds", typeof(string));
            dt.Columns.Add("IsAdminLayout", typeof(bool));
            dt.Columns.Add("IsTeacherLayout", typeof(bool));

            dt.Rows.Add(objAssignDashboard.LayoutId, objAssignDashboard.UserRoleIds, objAssignDashboard.IsAdminLayout, objAssignDashboard.IsTeacherLayout);

            parameters.Add("@tblAssignRoleDashboard", dt, DbType.Object);
            parameters.Add("@UserId", UserId, DbType.Int64);
            parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("Admin.AssignRoleToDashboard", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("output") > 0;
            }
        }

        public async Task<IEnumerable<DashboardWidgetList>> GetAllDashBoardWidget()
        {
            using (var conn = GetOpenConnection())
            {

                return await conn.QueryAsync<DashboardWidgetList>("Admin.GetAllDashBoardWidget", null, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
