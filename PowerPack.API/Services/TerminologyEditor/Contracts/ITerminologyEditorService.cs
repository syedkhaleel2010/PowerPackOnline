using PowerPack.Common.Enums;
using PowerPack.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface ITerminologyEditorService
    {
        Task<IEnumerable<TerminologyEditorView>> GetAllTerminologyEditor(long SchoolId);
        Task<IEnumerable<TerminologyEditorView>> GetTerminologyEditor(int? id, long SchoolId);
        bool TerminologyEditorInsert(TerminologyEditorView model);
        bool TerminologyEditorUpdate(TerminologyEditorView model);
        bool TerminologyEditorDelete(TerminologyEditorView model);
        bool CheckForTerminology(string term,int id);
    }
}
