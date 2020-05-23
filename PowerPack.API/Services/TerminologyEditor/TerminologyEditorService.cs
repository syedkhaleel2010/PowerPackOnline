using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMS.API.Repositories;
using PowerPack.Common.Enums;
using PowerPack.Common.Models;

namespace SIMS.API.Services
{
    public class TerminologyEditorService : ITerminologyEditorService
    {
         private readonly ITerminologyEditorRepository _terminologyEditorRepository;
        public TerminologyEditorService(ITerminologyEditorRepository terminologyEditorRepository)
        {
            _terminologyEditorRepository = terminologyEditorRepository;
        }

        public Task<IEnumerable<TerminologyEditorView>> GetAllTerminologyEditor(long SchoolId)
        {
            return _terminologyEditorRepository.GetTerminologyEditor(null,SchoolId);
        }
        
        public Task<IEnumerable<TerminologyEditorView>> GetTerminologyEditor(int? id, long SchoolId)
        {
            return _terminologyEditorRepository.GetTerminologyEditor(id,SchoolId);
        }

        public bool TerminologyEditorInsert(TerminologyEditorView model)
        {
            return _terminologyEditorRepository.TerminologyEditorCUD(model, TransactionModes.Insert);
        }
        public bool TerminologyEditorUpdate(TerminologyEditorView model)
        {
            return _terminologyEditorRepository.TerminologyEditorCUD(model, TransactionModes.Update);
        }
        public bool TerminologyEditorDelete(TerminologyEditorView model)
        {
            return _terminologyEditorRepository.TerminologyEditorCUD(model, TransactionModes.Delete);
        }
        public bool CheckForTerminology(string term,int id)
        {
            return _terminologyEditorRepository.CheckForTerminology(term,id);
        }
    }
}
