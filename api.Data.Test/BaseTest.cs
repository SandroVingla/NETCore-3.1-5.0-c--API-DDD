using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace Api.Data.Test
{
    public class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";

        public ServiceProvider ServiceProvider {get; private set;}

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(O =>
                O.UseMySql($"Persist Security Info=True;localhost;DataBase={dataBaseName};User=root;Password=sandro777 "),
                    ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                 context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
              using (var context = ServiceProvider.GetService<MyContext>())
            {
                 context.Database.EnsureDeleted();
            }
        }
        
        
    }
}
