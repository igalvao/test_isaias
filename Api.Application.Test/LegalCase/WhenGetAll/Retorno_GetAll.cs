using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.LegalCase;
using Api.Domain.Interfaces.Services.LegalCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.LegalCase.WhenGetAll
{
    public class Retorno_GetAll
    {
        private LegalCaseController _controller;

        [Fact(DisplayName = "É possível Realizar o Get All.")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<ILegalCaseService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                 new List<LegalCaseDto>
                 {
                    new LegalCaseDto
                    {
                        Id = Guid.NewGuid(),
                        CaseNumber = Faker.Name.FullName(),
                        CourtName = "",
                        RegistrationDate = DateTime.UtcNow
                    },
                    new LegalCaseDto
                    {
                        Id = Guid.NewGuid(),
                        CaseNumber = Faker.Name.FullName(),
                        CourtName = "",
                        RegistrationDate = DateTime.UtcNow
                    }
                 }
            );
            _controller = new LegalCaseController(serviceMock.Object);
            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<LegalCaseDto>;
            Assert.True(resultValue.Count() == 2);
        }
    }
}
