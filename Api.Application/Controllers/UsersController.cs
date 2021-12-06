using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers{

[Route("api/[comtroller]")]
[ApiController]


    public class UsersController : ControllerBase
    {
        private IUserService _service;

        public UsersController (IUserService service){
            _service = service;

        }
       [HttpGet]

       public async Task<ActionResult> GetAll() {
           if(!ModelState.IsValid) {

               return BadRequest(ModelState);
           }

           try
           {
             return Ok (await _service.GetAll ());   
           }
           catch (ArgumentException e) {
               return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
           }
       }
    }
}
