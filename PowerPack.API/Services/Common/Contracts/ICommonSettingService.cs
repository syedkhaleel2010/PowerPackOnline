using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface ICommonSettingService
    {
        long OperationDetailsCU(OperationAudit operationAudit);
    }
}
