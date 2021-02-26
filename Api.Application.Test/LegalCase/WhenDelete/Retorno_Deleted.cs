using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.LegalCase;
using Api.Domain.Interfaces.Services.LegalCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.LegalCase.WhenDelete
{
    public class Retorno_Deleted
    {
        private LegalCaseController _controller;

        [Fact(DisplayName = "É possível Realizar o Deleted.")]
        public async Task E_Possivel_Invocar_a_Controller_Delete()
        {
            var serviceMock = new Mock<ILegalCaseService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                       .ReturnsAsync(true);

            _controller = new LegalCaseController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
        }
    }
}
