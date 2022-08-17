using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Service.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace api.Application.Test.Municipio.QuandoRequisitarCreate
{
    public class RetornoBadRequest
    {
        private MunicipiosController _controller;
        [Fact(DisplayName = "É_Possivel_Invocar_a_Controller_Create." )]

        public async Task E_Pssivel_Invocar_Controller_Create()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.Post(It.IsAny<MunicipioDtoCreate>())).ReturnsAsync(
                new MunicipioDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatorio,");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;
            var MunicipioDtoCreate = new MunicipioDtoCreate
            {
                Nome = "São Pulo",
                CodIBGE = 1
            };
            var result = await _controller.Post(MunicipioDtoCreate);
            Assert.True(result is BadRequestObjectResult);

           
            
        }

    }
}
