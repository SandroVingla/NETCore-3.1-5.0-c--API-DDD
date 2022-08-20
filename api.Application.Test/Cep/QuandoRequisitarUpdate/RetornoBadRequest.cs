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

namespace api.Application.Test.Cep.QuandoRequisitarUpdate
{
    public class RetornoBadRequest
    {
        private CepsController _controller;
        [Fact(DisplayName = "É_Possivel_Invocar_a_Controller_Update." )]

        public async Task E_Pssivel_Invocar_Controller_Update()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste rua",
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatorio,");

            var cepDtoUpdate = new CepDtoUpdate
            {
                Logradouro = "Teste rua",
                Cep = "103334444"
            };
            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }

    }
}
