using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Service.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace api.Application.Test.Cep.QuandoRequisitarGet
{
    public class Retorno_BadRequest
    {
        private CepsController _controller;
        [Fact(DisplayName = "É Possivel Realizar Get." )]

        public async Task E_Pssivel_Invocar_Controller_GetAll()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste rua",
                
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatorio,");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);

           
        }
    }
}
