using System;
using System.Collections.Generic;
using Api.Domain.Dtos.LegalCase;

namespace Api.Service.Test.LegalCase
{
    public class LegalCaseTestes
    {
        public static string NomeLegalCase { get; set; }
        public static string CourtNameLegalCase { get; set; }
        public static string NomeLegalCaseAlterado { get; set; }
        public static string CourtNameLegalCaseAlterado { get; set; }
        public static Guid IdLegalCase { get; set; }

        public List<LegalCaseDto> listaLegalCaseDto = new List<LegalCaseDto>();
        public LegalCaseDto LegalCaseDto;
        public LegalCaseDtoCreate LegalCaseDtoCreate;
        public LegalCaseDtoCreateResult LegalCaseDtoCreateResult;
        public LegalCaseDtoUpdate LegalCaseDtoUpdate;
        public LegalCaseDtoUpdateResult LegalCaseDtoUpdateResult;

        public LegalCaseTestes()
        {
            IdLegalCase = Guid.NewGuid();
            NomeLegalCase = Faker.Name.FullName();
            CourtNameLegalCase = "";
            NomeLegalCaseAlterado = Faker.Name.FullName();
            CourtNameLegalCaseAlterado = "";

            for (int i = 0; i < 10; i++)
            {
                var dto = new LegalCaseDto()
                {
                    Id = Guid.NewGuid(),
                    CaseNumber = Faker.Name.FullName(),
                    CourtName = ""
                };
                listaLegalCaseDto.Add(dto);
            }

            LegalCaseDto = new LegalCaseDto
            {
                Id = IdLegalCase,
                CaseNumber = NomeLegalCase,
                CourtName = CourtNameLegalCase
            };

            LegalCaseDtoCreate = new LegalCaseDtoCreate
            {
                Name = NomeLegalCase,
                CourtName = CourtNameLegalCase
            };


            LegalCaseDtoCreateResult = new LegalCaseDtoCreateResult
            {
                Id = IdLegalCase,
                Name = NomeLegalCase,
                CourtName = CourtNameLegalCase,
                RegistrationDate = DateTime.UtcNow
            };

            LegalCaseDtoUpdate = new LegalCaseDtoUpdate
            {
                Id = IdLegalCase,
                Name = NomeLegalCaseAlterado,
                CourtName = CourtNameLegalCaseAlterado
            };

            LegalCaseDtoUpdateResult = new LegalCaseDtoUpdateResult
            {
                Id = IdLegalCase,
                Name = NomeLegalCaseAlterado,
                CourtName = CourtNameLegalCaseAlterado,
            };

        }
    }
}
