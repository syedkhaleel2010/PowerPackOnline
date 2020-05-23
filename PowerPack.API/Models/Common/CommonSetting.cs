using PowerPack.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class CommonSetting
    {
    }
    public class OperationAudit
    {
        public long Id { get; set; }
        public UserPrincipal User { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Parameters { get; set; }
        public string Result { get; set; }

    }
}
