using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.LegalCase;
using Api.Domain.Interfaces.Services.LegalCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.LegalCase.WhenUpdate
{
    public class Retorno_BadRequest
    {
        private LegalCaseController _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<ILegalCaseService>();
            var nome = Faker.Name.FullName();
            var CourtName = "";

            serviceMock.Setup(m => m.Put(It.IsAny<LegalCaseDtoUpdate>())).ReturnsAsync(
                new LegalCaseDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    CourtName = CourtName,
                }
            );

            _controller = new LegalCaseController(serviceMock.Object);
            _controller.ModelState.AddModelError("CourtName", "É um campo obrigatorio");

            var LegalCaseDtoUpdate = new LegalCaseDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = nome,
                CourtName = CourtName,
            };

            var result = await _controller.Put(LegalCaseDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
