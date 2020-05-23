using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Services
{
    public class BehaviourSetupService : IBehaviourSetupService
    {
        private readonly IBehaviourSetupRepository behaviourSetupRepository;

        public BehaviourSetupService(IBehaviourSetupRepository behaviourSetupRepository)
        {
            this.behaviourSetupRepository = behaviourSetupRepository;
        }
        #region Behaviour Setup
        public async Task<IEnumerable<BehaviourSetup>> GetSubCategoryList(long CategoryID, long BSU_ID)
        {
            return await behaviourSetupRepository.GetSubCategoryList(CategoryID, BSU_ID);
        }
        public async Task<IEnumerable<CategoryLevel>> GetCategoryLevel(long SubCategoryID)
        {
            return await behaviourSetupRepository.GetCategoryLevel(SubCategoryID);
        }
        public async Task<int> SaveSubCategory(BehaviourSetup behaviourSetup, string DATAMODE)
        {
            return await behaviourSetupRepository.SaveSubCategory(behaviourSetup, DATAMODE);
        }
        #endregion Behaviour Setup

        #region Action Hierarchy
        public async Task<IEnumerable<Designations>> GetDesignations(long schoolId)
        {
            return await behaviourSetupRepository.GetDesignations(schoolId);
        }

        public async Task<IEnumerable<DesignationsRouting>> GetDesignationsRoutings(long schoolId, long? designationFrom)
        {
            return await behaviourSetupRepository.GetDesignationsRoutings(schoolId, designationFrom);
        }

        public async Task<IEnumerable<DesignationsRouting>> DesignationBySchoolCUD(DesignationsRoutingCUD designationsRouting)
        {
            return await behaviourSetupRepository.DesignationBySchoolCUD(designationsRouting);
        }
        #endregion

        #region Certificate Schedule
        public async Task<IEnumerable<CertificateScheduling>> GetCertificateSchedulings(long? CertificateSchedulingId, long? academicYear, long? schoolId)
        {
            return await behaviourSetupRepository.GetCertificateSchedulings(CertificateSchedulingId, academicYear, schoolId);
        }

        public async Task<long> CertificateSchedulingCUD(CertificateScheduling certificateScheduling)
        {
            return await behaviourSetupRepository.CertificateSchedulingCUD(certificateScheduling);
        }
        #endregion
    }
}
