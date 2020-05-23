using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PowerPack.Common.Models;

namespace SIMS.API.Services
{
    public class DivisionService : IDivisionService
    {
        private readonly IDivisionRepositorycs _IDivisionRepositorycs;
        public DivisionService(IDivisionRepositorycs IDivisionRepositorycs)
        {

            _IDivisionRepositorycs = IDivisionRepositorycs;

        }
        public async Task<int> SaveDivisionDetails(DivisionDetails DivisionDetails, string DATAMODE)
        {
            return await _IDivisionRepositorycs.SaveDivisionDetails(DivisionDetails, DATAMODE);
        }
        public async Task<IEnumerable<DivisionDetails>> GetDivisionDetails(long BSU_ID)
        {
            return await _IDivisionRepositorycs.GetDivisionDetails(BSU_ID);
        }
        public async Task<IEnumerable<DivisionDetails>> GetDivisionDetails(long BSU_ID, long acdId, string isSuperUser, string username) =>
            await _IDivisionRepositorycs.GetDivisionDetails(BSU_ID, acdId, isSuperUser, username);


    }
}
