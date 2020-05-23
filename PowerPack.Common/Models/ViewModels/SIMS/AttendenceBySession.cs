using PowerPack.Common.ViewModels;
using PowerPack.Models;
using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models
{
    public class AttendenceBySession
    {
        public AttendenceBySession()
        {
            AT_DAY = string.Empty ;
            AT_AM = 0;
            AT_PM = 0;

        }
        public string AT_DAY { get; set; }
        public decimal  AT_AM { get; set; }
        public decimal AT_PM { get; set; }

    }
}
