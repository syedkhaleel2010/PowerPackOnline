using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolInformation>> GetSchoolList();
        Task<IEnumerable<SchoolInformation>> GetAdminSchoolList();
        Task<SchoolInformation> GetSchoolById(int id);
    }
}
