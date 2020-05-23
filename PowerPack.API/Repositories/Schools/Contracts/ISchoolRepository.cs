using DbConnection;
using PowerPack.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Repositories
{
    public interface ISchoolRepository: IGenericRepository<SchoolInformation>
    {
        Task<IEnumerable<SchoolInformation>> GetSchoolList();
        Task<IEnumerable<SchoolInformation>> GetAdminSchoolList();
    }
}
