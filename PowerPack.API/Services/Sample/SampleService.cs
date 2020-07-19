using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PowerPack.Common.Models;

namespace SIMS.API.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepositorycs _ISampleRepositorycs;
        public SampleService(ISampleRepositorycs ISampleRepositorycs)
        {

            _ISampleRepositorycs = ISampleRepositorycs;

        }
        public async Task<int> SaveSampleDetails(SampleDetails SampleDetails, string DATAMODE)
        {
            return await _ISampleRepositorycs.SaveSampleDetails(SampleDetails, DATAMODE);
        }
        public async Task<IEnumerable<SampleDetails>> GetSampleDetails(long BSU_ID)
        {
            return await _ISampleRepositorycs.GetSampleDetails(BSU_ID);
        }
        public async Task<IEnumerable<SampleDetails>> GetSampleDetails(long BSU_ID, long acdId, string isSuperUser, string username) =>
            await _ISampleRepositorycs.GetSampleDetails(BSU_ID, acdId, isSuperUser, username);


    }
}
