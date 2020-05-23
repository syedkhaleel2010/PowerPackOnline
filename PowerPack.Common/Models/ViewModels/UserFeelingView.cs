using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.Models
{
    public class UserFeelingView
    {
        public UserFeelingView()
        {
            FeelingList = new List<UserFeelingView>();
        }
        public int FeelId { get; set; }
        public string FeelingType { get; set; }
        public IEnumerable<UserFeelingView> FeelingList { get; set; }
        public long UserTypeId { get; set; }
        public long UserId { get; set; }
        public string Logo { get; set; }
        public string CurrentStatus { get; set; }
    }
}
