using Api.Domain.Interfaces.Service.Cep;
using Api.Domain.Interfaces.Service.Municipio;
using Api.Domain.Interfaces.Service.Uf;
using Api.Domain.Interfaces.Service.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection){
            serviceCollection.AddTransient<IUserService, UserService> ();
            serviceCollection.AddTransient<IloginService, LoginService> ();


            serviceCollection.AddTransient<IUfService, UfService> ();
            serviceCollection.AddTransient<IMunicipioService, MunicipioService> ();
            serviceCollection.AddTransient<ICepService, CepService> ();
        }
    }
}
