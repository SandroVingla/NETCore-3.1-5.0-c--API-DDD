using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Newtonsoft.Json;
using Xunit;

namespace api.Integration.Test.Municipio
{
    public class QuandoRequisitarMunicipio : BaseIntegration
    {
        [Fact]

        public async Task E_Possivel_Realizar_CRUD_Municipio()
        {
            await AdicionarToken();

            var municipio = new MunicipioDtoCreate()
            {
                Nome = "São Paulo",
                CodIBGE = 3550308,
                UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            //Post
            var response = await PostJsonAsync(municipio, $"{hostApi}municipios",client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<MunicipioDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("São Paulo", registroPost.Nome);
            Assert.Equal(3550308,registroPost.CodIBGE);
            Assert.True(registroPost.Id != default(Guid));
        


            //GetAll
            response = await client.GetAsync($"{hostApi}municipios");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var JsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<MunicipioDto>>(JsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(r => r.Id == registroPost.Id).Count() == 1);

            var updateMunicipioDto = new MunicipioDtoUpdate()
            {
                Id = registroPost.Id,
                Nome = "Limeira",
                CodIBGE = 3526902,
                UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };


            //Put
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateMunicipioDto),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}Municipios", stringContent);
            JsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<MunicipioDtoUpdateResult>(JsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Limeira", registroAtualizado.Nome);
            Assert.Equal(3526902, registroAtualizado.CodIBGE);


            //Get Id
            response = await client.GetAsync($"{hostApi}municipios/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            JsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<MunicipioDto>(JsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionado.CodIBGE, registroAtualizado.CodIBGE);


            //Get Complete/Id
            response = await client.GetAsync($"{hostApi}municipios/Complete/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            JsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoCompleto = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(JsonResult);
            Assert.NotNull(registroSelecionadoCompleto);
            Assert.Equal(registroSelecionadoCompleto.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionadoCompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoCompleto.Uf);
            Assert.Equal("São Paulo", registroSelecionadoCompleto.Uf.Nome);
            Assert.Equal("SP", registroSelecionadoCompleto.Uf.Sigla);


            //Get ByIBGE/CodIBGE
            response = await client.GetAsync($"{hostApi}municipios/ByIBGE/{registroAtualizado.CodIBGE}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            JsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoIBGECompleto = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(JsonResult);
            Assert.NotNull(registroSelecionadoIBGECompleto);
            Assert.Equal(registroSelecionadoIBGECompleto.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionadoIBGECompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoIBGECompleto.Uf);
            Assert.Equal("São Paulo", registroSelecionadoIBGECompleto.Uf.Nome);
            Assert.Equal("SP", registroSelecionadoIBGECompleto.Uf.Sigla);

            //Delete
            response = await client.DeleteAsync($"{hostApi}Municipios/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET Id depois do Delete

            response = await client.GetAsync($"{hostApi}Municipios/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);


        }
    }
}
