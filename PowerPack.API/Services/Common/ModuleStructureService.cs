using PowerPack.Models;
using SIMS.API.Repositories;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerPack.Common.Models;
using PowerPack.Common.Helpers;

namespace SIMS.API.Services
{
    public class ModuleStructureService : IModuleStructureService
    {
        private readonly IModuleStructureRepository _moduleStructureRepository;

        public ModuleStructureService(IModuleStructureRepository ModuleStructureRepository)
        {
            _moduleStructureRepository = ModuleStructureRepository;
        }

        public async Task<IEnumerable<ModuleStructure>> GetPowerPackModuleStructure(int systemLanguageId,
            int userId, string applicationCode, string traverseDirection, string moduleUrl, string moduleCode, bool excludeParent,
            string excludeModuleCodes, bool? showInMenu)
        {
            return await _moduleStructureRepository.GetPowerPackModuleStructure(systemLanguageId, userId, applicationCode, traverseDirection, moduleUrl, 
                moduleCode, excludeParent, excludeModuleCodes, showInMenu);
        }
    }
}
