using PowerPack.Common.Enums;
using PowerPack.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Repositories
{
    public interface ITerminologyEditorRepository
    {
        Task<IEnumerable<TerminologyEditorView>> GetTerminologyEditor(int? id,long schoolId);
        bool CheckForTerminology(string term,int id);
        bool TerminologyEditorCUD(TerminologyEditorView model, TransactionModes mode);
    }
}
