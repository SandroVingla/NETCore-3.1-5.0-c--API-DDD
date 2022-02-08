using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace api.Application.Test.Usuario.QuandoRequisitarGetAll
{
    public class BadRequest
    {
        
        private UsersController _controller;
        [Fact(DisplayName = "É_Possivel_Invocar_a_Controller_Get." )]

        public async Task E_Pssivel_Invocar_Controller_Get(){

            var serviceMock = new Mock<IUserService>();
        

                serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserDto>
                {
                    new UserDto

                    {
                        Id = System.Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow
                    },
                    
                    new UserDto
                    {
                      
                        Id = System.Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow  
                    }
                

                }
                
            );

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
