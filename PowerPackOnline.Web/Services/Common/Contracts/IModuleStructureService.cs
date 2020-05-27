using PowerPack.Common.Models;
using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPackOnline.Web.Services
{
    public interface IModuleStructureService
    {
        IEnumerable<ModuleStructure> GetPowerPackModuleStructure(int systemLanguageId,
            int userId, string applicationCode, string traverseDirection, string moduleUrl, string moduleCode, bool excludeParent,
            string excludeModuleCodes, bool? showInMenu);
    }
}
