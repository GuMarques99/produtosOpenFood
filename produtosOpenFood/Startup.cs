using Microsoft.AspNetCore.Builder;
using MongoDB.Driver;
using produtosOpenFood.Interfaces.Services;
using produtosOpenFood.Services;

namespace Microsoft.AspNetCore.Hosting
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      //Recuperar configurações do MongoDB do arquivo appsettings.json
      string connectionUri = _configuration.GetValue<string>("MongoDB:ConnectionURI");
      string databaseName = _configuration.GetValue<string>("MongoDB:DatabaseName");

      // Configuração da conexão com o MongoDB
      var mongoClient = new MongoClient(connectionUri);
      var database = mongoClient.GetDatabase(databaseName);

      // Registro do banco de dados
      services.AddSingleton(database);


      //Definição dos serviços
      services.AddScoped<IProductService, ProductService>();

    }
  }
}
