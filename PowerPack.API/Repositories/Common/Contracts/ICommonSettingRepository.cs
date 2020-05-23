using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Repositories
{
    public interface ICommonSettingRepository
    {
        long OperationDetailsCU(OperationAudit operationAudit);
    }
}
