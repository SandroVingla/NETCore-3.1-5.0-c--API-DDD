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

namespace api.Application.Test.Municipio.QuandoRequisitarUpdate
{
    public class Retorno_Ok
    {
        private MunicipiosController _controller;
        [Fact(DisplayName = "É_Possivel_Invocar_a_Controller_Update." )]

        public async Task E_Pssivel_Invocar_Controller_Update()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.Put(It.IsAny<MunicipioDtoUpdate>())).ReturnsAsync(
                new MunicipioDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);

            var MunicipioDtoUpdate = new MunicipioDtoUpdate
            {
                Nome = "São Pulo",
                CodIBGE = 1
            };
            var result = await _controller.Put(MunicipioDtoUpdate);
            Assert.True(result is OkObjectResult);

           
            
        }

    }
}
