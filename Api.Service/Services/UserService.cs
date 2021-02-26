using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.LegalCase;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.LegalCase;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class LegalCaseService : ILegalCaseService
    {
        private IRepository<LegalCaseEntity> _repository;
        private readonly IMapper _mapper;

        public LegalCaseService(IRepository<LegalCaseEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<LegalCaseDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<LegalCaseDto>(entity);
        }

        public async Task<IEnumerable<LegalCaseDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<LegalCaseDto>>(listEntity);
        }

        public async Task<LegalCaseDtoCreateResult> Post(LegalCaseDtoCreate LegalCase)
        {
            var model = _mapper.Map<LegalCaseModel>(LegalCase);
            var entity = _mapper.Map<LegalCaseEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<LegalCaseDtoCreateResult>(result);
        }

        public async Task<LegalCaseDtoUpdateResult> Put(LegalCaseDtoUpdate LegalCase)
        {
            var model = _mapper.Map<LegalCaseModel>(LegalCase);
            var entity = _mapper.Map<LegalCaseEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<LegalCaseDtoUpdateResult>(result);
        }
    }
}
