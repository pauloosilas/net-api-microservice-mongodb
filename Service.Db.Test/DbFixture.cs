
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Servicos.api.Livraria.Core;
using Servicos.api.Livraria.Core.Entities;
using Servicos.api.Livraria.Repository;

namespace Service.Db.Test;

public class DbFixture : IDisposable
{
   public IMongoRepository<AutorEntity> mongoRepository {get;}
   public MongoSettings mongoSettings {get;}

   private IConfigurationRoot teste;
   public DbFixture()
   {
      string connection = "mongodb://localhost:27017";
      string database = $"LivrariaMongoDb_{Guid.NewGuid()}";


      this.mongoSettings = new MongoSettings(connection, database);
      IOptions<MongoSettings> options = Options.Create(mongoSettings);
      this.mongoRepository = new MongoRepository<AutorEntity>(options);


   /*   var builder = new ConfigurationBuilder().
         SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json")
         .Build();

      teste = builder;
   */

   }
  
    public void Dispose()
    {
        var client = new MongoClient(this.mongoSettings.ConnectionString);
        client.DropDatabase(this.mongoSettings.Database);
    }
}