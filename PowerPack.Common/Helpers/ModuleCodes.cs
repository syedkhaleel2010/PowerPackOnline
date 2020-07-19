using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.Helpers
{

    public enum ModuleCodes
    {

        CalculateAverage,
        ElectiveClassList
    }
    public enum PermissionCodes
    {
        V_Admin,
        V_ErrorLogs,
        U_ErrorLogs
    }
    public enum ConfigurableModuleCodes
    {

       
    }
   

    public enum ApplicationList
    {
        [StringValue("Control Panel")]
        AdminHome,
        [StringValue("SIS")]
        SISHome
    }
}
