using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto userentity, [FromServices] IloginService service){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if(userentity == null){
                return BadRequest();
            }
            try
            {
              var result = await service.FindByLogin(userentity); 
              if(result != null){
                  return Ok(result);
              }  else{
                  return NotFound();
              }
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
    }
}
