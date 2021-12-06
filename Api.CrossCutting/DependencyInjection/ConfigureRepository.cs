using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository (IServiceCollection servicecollection){
            servicecollection.AddScoped(typeof (IRepository<>), typeof(BaseRepository<>));

             servicecollection.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Database=dpAPI;Uid=root;Pwd=sandro777")
            );
        }
    }
}