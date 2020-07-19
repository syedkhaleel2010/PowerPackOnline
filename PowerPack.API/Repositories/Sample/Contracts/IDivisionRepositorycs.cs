using PowerPack.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerPack.API.Models;
using System.Data;

namespace PowerPack.API.Repositories
{
    public interface ISampleRepositorycs
    {
        Task<int> SaveSampleDetails(SampleDetails SampleDetails, string DATAMODE);
        Task<IEnumerable<SampleDetails>> GetSampleDetails(long BSU_ID);
        Task<IEnumerable<SampleDetails>> GetSampleDetails(long BSU_ID, long acdId, string isSuperUser, string username);
    }
}
