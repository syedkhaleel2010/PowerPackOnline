using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PowerPack.Common.Models;

namespace SIMS.API.Services
{
    public interface IGradeService
    {
        Task<IEnumerable<Grades>> GetGrades();
        Task<IEnumerable<Grades>> GetGradesByACD(int id);
        Task<IEnumerable<Sections>> GetSectionsByGrade(int id);
        Task<IEnumerable<GradesAccess>> GetGradesAccess(string username, string isSuperUser, Int32 acd_id, Int32 bsu_id, int grd_access, Int32 rsm_id, int divisionId);
        Task<IEnumerable<Subjects>> GetSubjectsByGrade(Int32 acd_id, string grd_id, string username = "", string IsSuperUser = "");
        Task<IEnumerable<SubjectGroups>> GetSubjectGroupBySubject(string username, string isSuperUser, Int32 bsu_id, string grd_id, Int32 sbg_id);
        Task<IEnumerable<ListItem>> GetSelectListItems(string listCode, string whereCondition, string whereConditionParamValues);
        Task<IEnumerable<ListItem>> GetAcademicYearLists(string SchoolId, int CurriculumId, bool? IsCurrentCurriculum);
    }
    //public interface ISectionService
    //{
    //    Task<IEnumerable<Sections>> GetSectionsByGrade(int id);
    //}
}
