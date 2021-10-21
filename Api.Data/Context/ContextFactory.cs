using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Api.Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    {
      //Usando para criar as Migrações
      var connectionString = "Server=localhost;Port=3306;Database=dpAPI;Uid=root;Pwd=sandro777";
      var optionBuilder = new DbContextOptionsBuilder<MyContext> ();
      optionBuilder.UseMySql(connectionString);
      return new MyContext (optionBuilder.Options);
      
    }
  }
}
