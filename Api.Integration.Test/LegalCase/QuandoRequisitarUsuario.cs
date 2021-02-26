using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.LegalCase;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.LegalCase
{
    public class QuandoRequisitarLegalCase : BaseIntegration
    {
        private string _name { get; set; }
        private string _CourtName { get; set; }

        [Fact]
        public async Task E_Possivel_Realizar_Crud_LegalCase()
        {
            await AdicionarToken();
            _name = Faker.Name.First();
            _CourtName = "";

            var LegalCaseDto = new LegalCaseDtoCreate()
            {
                Name = _name,
                CourtName = _CourtName
            };

            //Post
            var response = await PostJsonAsync(LegalCaseDto, $"{hostApi}LegalCase", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<LegalCaseDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registroPost.Name);
            Assert.Equal(_CourtName, registroPost.CourtName);
            Assert.True(registroPost.Id != default(Guid));

            //Get All
            response = await client.GetAsync($"{hostApi}LegalCase");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<LegalCaseDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(r => r.Id == registroPost.Id).Count() == 1);

            var updateLegalCaseDto = new LegalCaseDtoUpdate()
            {
                Id = registroPost.Id,
                Name = Faker.Name.FullName(),
                CourtName = ""
            };

            //PUT
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateLegalCaseDto),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}LegalCase", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<LegalCaseDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.Name, registroAtualizado.Name);
            Assert.NotEqual(registroPost.CourtName, registroAtualizado.CourtName);

            //GET Id
            response = await client.GetAsync($"{hostApi}LegalCase/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<LegalCaseDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.CaseNumber, registroAtualizado.Name);
            Assert.Equal(registroSelecionado.CourtName, registroAtualizado.CourtName);

            //DELETE
            response = await client.DeleteAsync($"{hostApi}LegalCase/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET ID depois do DELETE
            response = await client.GetAsync($"{hostApi}LegalCase/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }

    }
}
