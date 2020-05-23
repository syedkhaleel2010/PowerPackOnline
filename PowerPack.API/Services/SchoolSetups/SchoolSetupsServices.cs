using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMS.API.Models;
using SIMS.API.Repositories;

namespace SIMS.API.Services
{
    public class SchoolSetupsServices : ISchoolSetupsServices
    {
        private readonly ISchoolSetupsRepository schoolSetupRepository;

        public SchoolSetupsServices(ISchoolSetupsRepository schoolSetupRepository)
        {
            this.schoolSetupRepository = schoolSetupRepository;
        }

        #region Assessment Term
        public async Task<string> AssessmentTermCUD(AssessmentTerm assessmentTerm)
        {
            return await schoolSetupRepository.AssessmentTermCUD(assessmentTerm);
        }
        #endregion
        #region Terminology
        public async Task<IEnumerable<Terminology>> GetTerminologyLable(long academicYearId, long schoolId, int CLM_ID, string LanguageCode, int divisionId)
        {
            return await schoolSetupRepository.GetTerminologyLable(academicYearId, schoolId, CLM_ID, LanguageCode,divisionId);
        }

        public async Task<string> TerminologyCU(TerminologyCU terminologyCU)
        {
            return await schoolSetupRepository.TerminologyCU(terminologyCU);
        }
        #endregion

        #region Academic Terms
        public async Task<IEnumerable<AcademicTerms>> GetAcademicTerms(long BSU_ID, long ACD_ID, long BSU_CLM_ID, int? divisionId)
        {
            return await schoolSetupRepository.GetAcademicTerms(BSU_ID, ACD_ID, BSU_CLM_ID, divisionId);
        }
        public async Task<string> AcademicTermsCUD(AcademicTerms AcademicTerms)
        {
            return await schoolSetupRepository.AcademicTermsCUD(AcademicTerms);
        }
        #endregion

        #region Grade Display
        public async Task<IEnumerable<GradeDisplay>> GradeDisplay(long academicYearId, long schoolId)
        {
            return await schoolSetupRepository.GradeDisplay(academicYearId, schoolId);
        }

        public async Task<string> GradeDisplayU(GradeDisplayU gradeDisplay)
        {
            return await schoolSetupRepository.GradeDisplayU(gradeDisplay);
        }

        #endregion
    }
}
