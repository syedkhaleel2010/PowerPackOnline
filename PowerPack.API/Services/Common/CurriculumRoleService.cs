using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMS.API.Models;
using SIMS.API.Repositories;
namespace SIMS.API.Services
{
    public class CurriculumRoleService : ICurriculumRoleService
    {
        private ICurriculumRoleRepository _curriculumRoleRepository;

        public CurriculumRoleService(ICurriculumRoleRepository curriculumRoleRepository)
        {
            _curriculumRoleRepository = curriculumRoleRepository;

        }

        public Task<CurriculumRole> GetUserCurriculumRole(string BSU_ID = "", string UserName = "")
        {
            return _curriculumRoleRepository.GetUserCurriculumRole(BSU_ID,UserName);
        }

        public async Task<IEnumerable<Curriculum>> GetCurriculum(long BSU_ID, int? CLM_ID)
        {
            return await _curriculumRoleRepository.GetCurriculum(BSU_ID, CLM_ID);
        }
    }
}
