using Api.Domain.Dtos.LegalCase;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<LegalCaseDto, LegalCaseEntity>()
               .ReverseMap();

            CreateMap<LegalCaseDtoCreateResult, LegalCaseEntity>()
               .ReverseMap();

            CreateMap<LegalCaseDtoUpdateResult, LegalCaseEntity>()
               .ReverseMap();

        }
    }
}
