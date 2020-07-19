using PowerPack.Common.Models;
using PowerPack.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerPack.API.Services
{
    public interface ISampleService
    {
       // Task<int> SaveSampleDetails(SampleDetails SampleDetails, string DATAMODE);
       
        Task<IEnumerable<SampleDetails>> GetSampleDetails(long BSU_ID);
        Task<IEnumerable<SampleDetails>> GetSampleDetails(long BSU_ID, long acdId, string isSuperUser, string username);
    }
}
