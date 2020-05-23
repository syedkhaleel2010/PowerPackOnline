using PowerPack.Common.Models;
using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface IDivisionService
    {
        Task<int> SaveDivisionDetails(DivisionDetails DivisionDetails, string DATAMODE);
       
        Task<IEnumerable<DivisionDetails>> GetDivisionDetails(long BSU_ID);
        Task<IEnumerable<DivisionDetails>> GetDivisionDetails(long BSU_ID, long acdId, string isSuperUser, string username);
    }
}
