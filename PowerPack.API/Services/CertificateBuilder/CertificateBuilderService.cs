using SIMS.API.Models.CertificateBuilder;
using SIMS.API.Repositories.CertificateBuilder.Contracts;
using SIMS.API.Services.CertificateBuilder.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services.CertificateBuilder
{
    public class CertificateBuilderService : ICertificateBuilderService
    {
        private readonly ICertificateBuilderRepository certificateBuilderService;

        public CertificateBuilderService(ICertificateBuilderRepository certificateBuilderService)
        {
            this.certificateBuilderService = certificateBuilderService;
        }

        public async Task<bool> Delete(int id, string deletedBy)
        {
            return await certificateBuilderService.Delete(id, deletedBy);
        }

        public Task<IEnumerable<Template>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Template> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Template> GetTemplateDetail(int? templateId, int? schoolId, string templateType, string period, string userId, bool? isActive, bool? includeTemplateField, int divisionId)
        {
            return await certificateBuilderService.GetTemplateDetail(templateId, schoolId, templateType, period, userId, isActive, includeTemplateField, divisionId);
        }

        public async Task<IEnumerable<TemplateFieldMapping>> GetTemplateFieldData(int templateId, long studentId) =>
            await certificateBuilderService.GetTemplateFieldData(templateId, studentId);

        public async Task<IEnumerable<Template>> GetTemplatesBySchoolId(long schoolId,string userId, bool isActive, string TemplateType, int? status, int divisionId)
        {
            return await certificateBuilderService.GetTemplatesBySchoolId(schoolId, userId, isActive, TemplateType, status, divisionId);
        }

        public async Task<int> Insert(Template entity)
        {
            return await certificateBuilderService.Insert(entity);
        }

        public async Task<bool> SaveCertificateAssignedColumns(IEnumerable<TemplateField> fieldList)
        {
            return await certificateBuilderService.SaveCertificateAssignedColumns(fieldList);
        }

        public async Task<bool> SaveTemplateImageData(Template templateModel)
        {
            return await certificateBuilderService.SaveTemplateImageData(templateModel);
        }

        public async Task<int> Update(Template entityToUpdate)
        {
            return await certificateBuilderService.Update(entityToUpdate);
        }
    }
}
