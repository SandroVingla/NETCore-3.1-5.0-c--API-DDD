using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;



namespace Api.Data.Test
{
    public abstract class BaseTest
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
                O.UseMySql($"Server=localhost;Port=3306;Database={dataBaseName};Uid=root;Pwd=sandro777",
                    new MySqlServerVersion(new Version(8,0,21)),
                            mySqlOptions => mySqlOptions
                                .CharSetBehavior(CharSetBehavior,NeverAppend)
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
