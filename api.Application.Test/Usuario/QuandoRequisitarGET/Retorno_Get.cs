using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace api.Application.Test.Usuario.QuandoRequisitarGET
{
    public class Retorno_Get
    {
        private UsersController _controller;
        [Fact(DisplayName = "É_Possivel_Invocar_a_Controller_Get." )]

        public async Task E_Pssivel_Invocar_Controller_Get(){

            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

                serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto
                {
                    Id = System.Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                }
            );
            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(nome, resultValue.Name);
            Assert.Equal(email, resultValue.Email);

        }
    }
}
