using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface ICurriculumRoleService
    {
        Task<CurriculumRole> GetUserCurriculumRole(string BSU_ID = "", string UserName = "");
        Task<IEnumerable<Curriculum>> GetCurriculum(long BSU_ID, int? CLM_ID);
    }
}
