using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMS.API.Models;

namespace SIMS.API.Repositories
{
    public interface IBehaviourSetupRepository
    {
        #region Behaviour Setup
        Task<IEnumerable<BehaviourSetup>> GetSubCategoryList(long CategoryID, long BSU_ID);
        Task<int> SaveSubCategory(BehaviourSetup behaviourSetup, string DATAMODE);
        Task<IEnumerable<CategoryLevel>> GetCategoryLevel(long SubCategoryID);
        #endregion Behaviour Setup

        #region Action Hierarchy
        Task<IEnumerable<Designations>> GetDesignations(long schoolId);
        Task<IEnumerable<DesignationsRouting>> GetDesignationsRoutings(long schoolId,long? designationFrom);
        Task<IEnumerable<DesignationsRouting>> DesignationBySchoolCUD(DesignationsRoutingCUD designationsRouting);
        #endregion

        #region Certificate Schedule
        Task<IEnumerable<CertificateScheduling>> GetCertificateSchedulings(long? CertificateSchedulingId, long? academicYear, long? schoolId);
        Task<long> CertificateSchedulingCUD(CertificateScheduling certificateScheduling);
        #endregion
    }
}
