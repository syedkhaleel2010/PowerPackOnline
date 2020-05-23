using SIMS.API.Models;
using SIMS.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public class CommonSettingService : ICommonSettingService
    {
        private readonly ICommonSettingRepository commonSetting;

        public CommonSettingService(ICommonSettingRepository commonSetting)
        {
            this.commonSetting = commonSetting;
        }
        public long OperationDetailsCU(OperationAudit operationAudit)
        {
            return commonSetting.OperationDetailsCU(operationAudit);
        }
    }
}
