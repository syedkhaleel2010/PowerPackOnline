using PowerPack.Common.ViewModels;
using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models
{
    public class AttendenceSessionCode
    {
        public AttendenceSessionCode()
        {
            Code = string.Empty ;
            Desc = string.Empty;
            Sessions = 0;
            Percentage = 0;
        }
        public string Code { get; set; }
        public string Desc { get; set; }
        public Decimal  Sessions { get; set; }
        public Decimal Percentage { get; set; }

    }
}
