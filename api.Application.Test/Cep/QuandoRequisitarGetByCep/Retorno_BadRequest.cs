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

namespace api.Application.Test.Cep.QuandoRequisitarGetByCep
{
    public class Retorno_BadRequest
    {
        private CepsController _controller;
        [Fact(DisplayName = "É Possivel Realizar Get." )]

        public async Task E_Pssivel_Invocar_Controller_Get()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<String>())).ReturnsAsync(
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste rua"
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatorio,");

            var result = await _controller.Get("13480000");
            Assert.True(result is BadRequestObjectResult);

           
        }
    }
}
