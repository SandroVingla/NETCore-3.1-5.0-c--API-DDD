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

namespace api.Application.Test.Cep.QuandoRequisitarCreate
{
    public class RetornoBadRequest
    {
        private CepsController _controller;
        [Fact(DisplayName = "É_Possivel_Invocar_a_Controller_Create." )]

        public async Task E_Pssivel_Invocar_Controller_Create()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>())).ReturnsAsync(
                new CepDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste rua",
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatorio,");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;
            var cepDtoCreate = new CepDtoCreate
            {
                Logradouro = "Teste rua",
                Numero = ""
            };
            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is BadRequestObjectResult);

           
            
        }
    }
}
