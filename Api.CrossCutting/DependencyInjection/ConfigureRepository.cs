using System;
using Api.Data.Context;
using Api.Data.Implementation;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository (IServiceCollection servicecollection){
            servicecollection.AddScoped(typeof (IRepository<>), typeof(BaseRepository<>));
            servicecollection.AddScoped<IUserRepository, UserImplementation>();

            servicecollection.AddScoped<IUfRepository, UfImplementation>();
            servicecollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();
            servicecollection.AddScoped<ICepRepository, CepImplementation>();

            if(Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                servicecollection.AddDbContext<MyContext>(
                    options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                    
                ); 
            }else{
                    servicecollection.AddDbContext<MyContext>(
                    //options => options.UseSqlServer("Server=localhost;Initial Catalog=dpapi;MultipleActiveResultSets=true;User ID=sa;Password=Sandro777")
                    
                    options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"),
                    new MySqlServerVersion(new Version(8,0,21)),
                        mySqlOptions => mySqlOptions
                            .CharSetBehavior(CharSetBehavior,NeverAppend)
                    )
                );

            }

             
        }
    }
}
