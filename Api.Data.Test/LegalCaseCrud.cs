using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class LegalCaseCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public LegalCaseCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de LegalCase")]
        [Trait("CRUD", "LegalCaseEntity")]
        public async Task E_Possivel_Realizar_CRUD_LegalCase()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                LegalCaseImplementation _repositorio = new LegalCaseImplementation(context);
                LegalCaseEntity _entity = new LegalCaseEntity
                {
                    CourtName = "",
                    Name = Faker.Name.FullName()
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.CourtName, _registroCriado.CourtName);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.CourtName, _registroAtualizado.CourtName);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);

                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.CourtName, _registroSelecionado.CourtName);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);

                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 1);

                var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                var _LegalCasePadrao = await _repositorio.FindByCourtName("courtTest");
                Assert.NotNull(_LegalCasePadrao);
                Assert.Equal("courtTest", _LegalCasePadrao.CourtName);
                Assert.Equal("Administrador", _LegalCasePadrao.Name);

            }
        }
    }
}
