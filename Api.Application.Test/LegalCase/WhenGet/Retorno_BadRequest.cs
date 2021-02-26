using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.LegalCase;
using Api.Domain.Interfaces.Services.LegalCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.LegalCase.WhenGet
{
    public class Retorno_BadRequest
    {
        private LegalCaseController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<ILegalCaseService>();
            var nome = Faker.Name.FullName();
            var CourtName = "";

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                 new LegalCaseDto
                 {
                     Id = Guid.NewGuid(),
                     CaseNumber = nome,
                     CourtName = CourtName,
                     RegistrationDate = DateTime.UtcNow
                 }
            );

            _controller = new LegalCaseController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
