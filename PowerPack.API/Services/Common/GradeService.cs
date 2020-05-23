using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PowerPack.Common.Models;

namespace SIMS.API.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<IEnumerable<Grades>> GetGrades()
        {
            return await _gradeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Grades>> GetGradesByACD(int id)
        {
            return await _gradeRepository.GetList(id);
        }
        public async Task<IEnumerable<Sections>> GetSectionsByGrade(int id)
        {
            return await _gradeRepository.GetSectionList(id);
        }
        public async Task<IEnumerable<GradesAccess>> GetGradesAccess(string username, string isSuperUser, Int32 acd_id, Int32 bsu_id, int grd_access, Int32 rsm_id, int divisionId)
        {
            return await _gradeRepository.GetGradesAccess(username, isSuperUser, acd_id, bsu_id, grd_access, rsm_id,divisionId);
        }
        public async Task<IEnumerable<Subjects>> GetSubjectsByGrade(Int32 acd_id, string grd_id, string username = "", string IsSuperUser = "")
        {
            return await _gradeRepository.GetSubjectsByGrade(acd_id, grd_id, username, IsSuperUser);
        }
        public async Task<IEnumerable<SubjectGroups>> GetSubjectGroupBySubject(string username, string isSuperUser, Int32 bsu_id, string grd_id, Int32 sbg_id)
        {
            return await _gradeRepository.GetSubjectGroupBySubject(username, isSuperUser, bsu_id, grd_id, sbg_id);
        }

        public async Task<IEnumerable<ListItem>> GetSelectListItems(string listCode, string whereCondition, string whereConditionParamValues)
        {
            return await _gradeRepository.GetSelectListItems(listCode, whereCondition, whereConditionParamValues);
        }

        public async Task<IEnumerable<ListItem>> GetAcademicYearLists(string SchoolId, int CurriculumId, bool? IsCurrentCurriculum)
        {
            return await _gradeRepository.GetAcademicYearLists(SchoolId, CurriculumId, IsCurrentCurriculum);
        }
    }
    //public class SectionService : ISectionService
    //{
    //    private readonly ISectionRepository _sectionRepository;

    //    public SectionService(ISectionRepository SectionRepository)
    //    {
    //        _sectionRepository = SectionRepository;
    //    }


    //    public async Task<IEnumerable<Grades>> GetSectionsByGrade(int id)
    //    {
    //        return await _sectionRepository.GetList(id);
    //    }
    //}
}
