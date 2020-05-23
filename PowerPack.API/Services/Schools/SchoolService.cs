using PowerPack.Models;
using SIMS.API.Repositories;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<IEnumerable<SchoolInformation>> GetSchoolList()
        {
            return await _schoolRepository.GetSchoolList();
        }
        public async Task<IEnumerable<SchoolInformation>> GetAdminSchoolList()
        {
            return await _schoolRepository.GetAdminSchoolList();
        }

        public async Task<SchoolInformation> GetSchoolById(int id)
        {
            return await _schoolRepository.GetAsync(id);
        }
    }
}
