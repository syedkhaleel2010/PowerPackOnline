using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMS.API.Models;
using System.Data;

namespace SIMS.API.Repositories
{
    public interface IDivisionRepositorycs
    {
        Task<int> SaveDivisionDetails(DivisionDetails DivisionDetails, string DATAMODE);
        Task<IEnumerable<DivisionDetails>> GetDivisionDetails(long BSU_ID);
        Task<IEnumerable<DivisionDetails>> GetDivisionDetails(long BSU_ID, long acdId, string isSuperUser, string username);
    }
}
