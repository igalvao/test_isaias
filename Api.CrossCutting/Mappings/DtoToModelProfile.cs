using Api.Domain.Dtos.LegalCase;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region LegalCase
            CreateMap<LegalCaseModel, LegalCaseDto>()
                .ReverseMap();
            CreateMap<LegalCaseModel, LegalCaseDtoCreate>()
                .ReverseMap();
            CreateMap<LegalCaseModel, LegalCaseDtoUpdate>()
                .ReverseMap();
            #endregion
        }

    }
}
