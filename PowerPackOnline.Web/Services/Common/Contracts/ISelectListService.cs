using PowerPack.Common.Models;
using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPackOnline.Web.Services
{
    public interface ISelectListService
    {
        IEnumerable<ListItem> GetSelectListItems(string listCode, string whereCondition, object whereConditionParamValues);
        IEnumerable<SubjectListItem> GetSubjectsByUserId(int userId);
    }
}
