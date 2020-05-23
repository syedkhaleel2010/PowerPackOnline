using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface ISchoolSetupsServices
    {
        #region Assessment Term
        Task<string> AssessmentTermCUD(AssessmentTerm assessmentTerm);
        #endregion
        #region Terminology
        Task<IEnumerable<Terminology>> GetTerminologyLable(long academicYearId, long schoolId, int CLM_ID, string LanguageCode, int divisionId);
        Task<string> TerminologyCU(TerminologyCU terminologyCU);
        #endregion

        #region Academic Terms
        Task<IEnumerable<AcademicTerms>> GetAcademicTerms(long BSU_ID, long ACD_ID, long BSU_CLM_ID, int? divisionId);
        Task<string> AcademicTermsCUD(AcademicTerms AcademicTerms);
        #endregion


        #region Grade Display
        Task<IEnumerable<GradeDisplay>> GradeDisplay(long academicYearId, long schoolId);
        Task<string> GradeDisplayU(GradeDisplayU gradeDisplay);
        #endregion
    }
}
