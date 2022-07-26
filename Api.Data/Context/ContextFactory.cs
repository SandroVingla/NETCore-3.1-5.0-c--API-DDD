using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Api.Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    {
      //Usando para criar as Migrações
      //"DB_CONNECTION": "Persist Security Info=True;Server=localhost;Port=3306;DataBase=dbNET5Atualizado;Uid=root;Pwd=sandro777",
      //var connectionString = "Server=localhost;Port=3306;DataBase=dbNET5Atualizado;Uid=root;Pwd=sandro777";

     var connectionString = "Server=localhost;Port=3306;Database=dpAPI4;Uid=root;Pwd=sandro777";
      //var connectionString = "Server=localhost;Initial Catalog=dpapi;MultipleActiveResultSets=true;User ID=sa;Password=Sandro777";
      var optionBuilder = new DbContextOptionsBuilder<MyContext> ();
      optionBuilder.UseMySql(connectionString);
      //optionBuilder.UseSqlServer(connectionString);
      return new MyContext (optionBuilder.Options);
      
    }
  }
}
