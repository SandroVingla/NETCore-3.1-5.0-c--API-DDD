using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Service.User;
using Api.Domain.Repository;

namespace Api.Service.Services
{
  public class LoginService : IloginService
  {
    private IUserRepository _repository;
     public LoginService(IUserRepository repository){
         _repository = repository;
     }

    public async Task<object> FindByLogin(LoginDto user)
    {

        if(user != null && !string.IsNullOrWhiteSpace(user.Email))
        {
            return await _repository.FindByLogin(user.Email);
        }
        else
        {
        return null;
        }
    }
  }
}
