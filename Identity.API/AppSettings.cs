using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API
{
    public class AppSettings
    {

        public string  ConnectionString { get; set; }
        public string MvcClient { get; set; }
        public string PowerPackUrl { get; set; }
        public string HseUrl { get; set; }

        public bool UseCustomizationData { get; set; }
    }
}
