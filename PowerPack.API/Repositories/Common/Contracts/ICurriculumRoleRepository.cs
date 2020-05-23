using DbConnection;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace SIMS.API.Repositories
{
    public interface ICurriculumRoleRepository
    {
        Task<CurriculumRole> GetUserCurriculumRole(string BSU_ID = "", string UserName="");
        Task<IEnumerable<Curriculum>> GetCurriculum(long BSU_ID, int? CLM_ID);

    }
}
