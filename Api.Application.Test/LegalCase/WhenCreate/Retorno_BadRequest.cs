using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.LegalCase;
using Api.Domain.Interfaces.Services.LegalCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.LegalCase.WhenCreate
{
    public class Retorno_BadRequest
    {
        private LegalCaseController _controller;
        [Fact(DisplayName = "É possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ILegalCaseService>();
            var nome = Faker.Name.FullName();
            var CourtName = "";

            serviceMock.Setup(m => m.Post(It.IsAny<LegalCaseDtoCreate>())).ReturnsAsync(
                new LegalCaseDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    CourtName = CourtName,
                    RegistrationDate = DateTime.UtcNow
                }
            );

            _controller = new LegalCaseController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "Required Field");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var LegalCaseDtoCreate = new LegalCaseDtoCreate
            {
                Name = nome,
                CourtName = CourtName,
            };

            var result = await _controller.Post(LegalCaseDtoCreate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
