using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.LegalCase;
using Moq;
using Xunit;

namespace Api.Service.Test.LegalCase
{
    public class QuandoForExecutadoCreate : LegalCaseTestes
    {
        private ILegalCaseService _service;
        private Mock<ILegalCaseService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<ILegalCaseService>();
            _serviceMock.Setup(m => m.Post(LegalCaseDtoCreate)).ReturnsAsync(LegalCaseDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(LegalCaseDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeLegalCase, result.Name);
            Assert.Equal(CourtNameLegalCase, result.CourtName);
        }
    }
}
