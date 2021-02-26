using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.LegalCase;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class LegalCaseMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelos")]
        public void E_Possivel_Mapear_os_Modelos()
        {
            var model = new LegalCaseModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                CourtName = "",
                RegistrationDate = DateTime.UtcNow,
            };

            var listaEntity = new List<LegalCaseEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new LegalCaseEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    CourtName = "",
                    RegistrationDate = DateTime.UtcNow,
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<LegalCaseEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.CourtName, model.CourtName);
            Assert.Equal(entity.RegistrationDate, model.RegistrationDate);

            //Entity para Dto
            var LegalCaseDto = Mapper.Map<LegalCaseDto>(entity);
            Assert.Equal(LegalCaseDto.Id, entity.Id);
            Assert.Equal(LegalCaseDto.CaseNumber, entity.Name);
            Assert.Equal(LegalCaseDto.CourtName, entity.CourtName);
            Assert.Equal(LegalCaseDto.RegistrationDate, entity.RegistrationDate);

            var listaDto = Mapper.Map<List<LegalCaseDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].CaseNumber, listaEntity[i].Name);
                Assert.Equal(listaDto[i].CourtName, listaEntity[i].CourtName);
                Assert.Equal(listaDto[i].RegistrationDate, listaEntity[i].RegistrationDate);
            }

            var LegalCaseDtoCreateResult = Mapper.Map<LegalCaseDtoCreateResult>(entity);
            Assert.Equal(LegalCaseDtoCreateResult.Id, entity.Id);
            Assert.Equal(LegalCaseDtoCreateResult.Name, entity.Name);
            Assert.Equal(LegalCaseDtoCreateResult.CourtName, entity.CourtName);
            Assert.Equal(LegalCaseDtoCreateResult.RegistrationDate, entity.RegistrationDate);

            var LegalCaseDtoUpdateResult = Mapper.Map<LegalCaseDtoUpdateResult>(entity);
            Assert.Equal(LegalCaseDtoUpdateResult.Id, entity.Id);
            Assert.Equal(LegalCaseDtoUpdateResult.Name, entity.Name);
            Assert.Equal(LegalCaseDtoUpdateResult.CourtName, entity.CourtName);

            //Dto para Model
            var LegalCaseModel = Mapper.Map<LegalCaseModel>(LegalCaseDto);
            Assert.Equal(LegalCaseModel.Id, LegalCaseDto.Id);
            Assert.Equal(LegalCaseModel.Name, LegalCaseDto.CaseNumber);
            Assert.Equal(LegalCaseModel.CourtName, LegalCaseDto.CourtName);
            Assert.Equal(LegalCaseModel.RegistrationDate, LegalCaseDto.RegistrationDate);

            var LegalCaseDtoCreate = Mapper.Map<LegalCaseDtoCreate>(LegalCaseModel);
            Assert.Equal(LegalCaseDtoCreate.Name, LegalCaseModel.Name);
            Assert.Equal(LegalCaseDtoCreate.CourtName, LegalCaseModel.CourtName);

            var LegalCaseDtoUpdate = Mapper.Map<LegalCaseDtoUpdate>(LegalCaseModel);
            Assert.Equal(LegalCaseDtoUpdate.Id, LegalCaseModel.Id);
            Assert.Equal(LegalCaseDtoUpdate.Name, LegalCaseModel.Name);
            Assert.Equal(LegalCaseDtoUpdate.CourtName, LegalCaseModel.CourtName);

        }
    }
}
