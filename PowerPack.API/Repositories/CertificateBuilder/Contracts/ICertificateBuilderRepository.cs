using DbConnection;
using SIMS.API.Models.CertificateBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Repositories.CertificateBuilder.Contracts
{
    public interface ICertificateBuilderRepository : IGenericRepository<Template>
    {
        Task<int> Insert(Template entity);
        Task<int> Update(Template entity);
        Task<bool> Delete(int id, string deletedBy);
        Task<IEnumerable<Template>> GetTemplatesBySchoolId(long schoolId, string userId, bool isActive, string TemplateType, int? status, int divisionId);
        Task<Template> GetTemplateDetail(int? templateId, int? schoolId, string templateType, string period, string userId, bool? isActive, bool? includeTemplateField, int divisionId);
        //Task<TemplateField> GetTemplateFieldById(int templateFieldId);
        //Task<IEnumerable<TemplateField>> GetTemplateFieldByTemplateId(int templateId, bool isActive);
        Task<bool> SaveTemplateImageData(Template templateModel);
        Task<bool> SaveCertificateAssignedColumns(IEnumerable<TemplateField> fieldList);
        Task<IEnumerable<TemplateFieldMapping>> GetTemplateFieldData(int templateId, long studentId);
    }
}
