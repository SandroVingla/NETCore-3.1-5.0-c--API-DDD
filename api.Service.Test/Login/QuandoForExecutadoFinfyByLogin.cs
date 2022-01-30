using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Service.User;
using Moq;
using Xunit;

namespace api.Service.Test.Login
{
    public class QuandoForExecutadoFinfyByLogin
    {
        private IloginService _service;
        private Mock<IloginService> _serviceMock;

        [Fact(DisplayName = "É possivel executar p metodo FindByLogin.")]
        public async Task E_Possivel_Executar_Metodo_FindByLogin(){
            var email = Faker.Internet.Email();
            var objetoRetorno = new
            {
                Authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                acessToken = Guid.NewGuid(),
                userName = email,
                name = Faker.Name.FullName(),
                message = "Usuário logado com sucesso."
            };

            var loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMock = new Mock<IloginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objetoRetorno);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}
