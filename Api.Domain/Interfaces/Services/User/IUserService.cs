using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.LegalCase;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.LegalCase
{
    public interface ILegalCaseService
    {
        Task<LegalCaseDto> Get(Guid id);
        Task<IEnumerable<LegalCaseDto>> GetAll();
        Task<LegalCaseDtoCreateResult> Post(LegalCaseDtoCreate LegalCase);
        Task<LegalCaseDtoUpdateResult> Put(LegalCaseDtoUpdate LegalCase);
        Task<bool> Delete(Guid id);
    }
}
