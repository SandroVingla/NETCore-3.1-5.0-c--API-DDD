using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;


namespace api.Integration.Test.Usuario
{
    public class QuandoRequisitarUsuario : BaseIntegration
    {
        private string _name {get; set;}
        private string _email {get; set;}

        [Fact]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            await AdicionarToken();
            _name = Faker.Name.FullName();
            _email = Faker.Internet.Email();

            var userDto = new UserDtoCreate()
            {
                Name = _name,
                Email = _email
            };

            //Post

            var response = await PostJsonAsync(userDto, $"{hostApi}users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registroPost.Name);
            Assert.Equal(_email, registroPost.Email);
            Assert.False(registroPost.Id == default(Guid));


            //GetAll
            response = await client.DeleteAsync($"{hostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count()>0);
            Assert.True(listaFromJson.Where(r => r.Id == registroPost.Id).Count()== 1);


            //Put
            var updateUserDto = new UserDtoUpdate()
            {
                Id = registroPost.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateUserDto),
                                    Encoding.UTF8, "application/Json");

            response = await client.PutAsync($"{hostApi}users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var resgistroAtualizado = JsonConvert.DeserializeObject<UserDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.Name, resgistroAtualizado.Name);
            Assert.NotEqual(registroPost.Email, resgistroAtualizado.Email);


            //Get ID
            response = await client.GetAsync($"{hostApi}users/{resgistroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var resgistroSelecionado = JsonConvert.DeserializeObject<UserDto>(jsonResult);
            Assert.NotNull(resgistroSelecionado);
            Assert.Equal(resgistroSelecionado.Name, resgistroAtualizado.Name);
            Assert.Equal(resgistroSelecionado.Email, resgistroAtualizado.Email);

            //delete
            response = await client.DeleteAsync($"{hostApi}users/{resgistroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET Id depois do delete
            response = await client.DeleteAsync($"{hostApi}users/{resgistroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            

            

        }
    }
}
