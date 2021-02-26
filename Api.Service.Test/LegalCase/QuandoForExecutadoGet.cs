using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.LegalCase;
using Api.Domain.Interfaces.Services.LegalCase;
using Moq;
using Xunit;

namespace Api.Service.Test.LegalCase
{
    public class QuandoForExecutadoGet : LegalCaseTestes
    {
        private ILegalCaseService _service;
        private Mock<ILegalCaseService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<ILegalCaseService>();
            _serviceMock.Setup(m => m.Get(IdLegalCase)).ReturnsAsync(LegalCaseDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdLegalCase);
            Assert.NotNull(result);
            Assert.True(result.Id == IdLegalCase);
            Assert.Equal(NomeLegalCase, result.CaseNumber);

            _serviceMock = new Mock<ILegalCaseService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((LegalCaseDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdLegalCase);
            Assert.Null(_record);

        }
    }
}
