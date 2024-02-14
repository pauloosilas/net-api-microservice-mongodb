namespace Servicos.api.Livraria.Core
{
    public class MongoSettings
    {
        public MongoSettings(string ConnectionString, string Database)
        {
            this.ConnectionString = ConnectionString;
            this.Database = Database;
        }

        public MongoSettings(){}

        public string ConnectionString{get;set;}
        public string Database{get;set;}
    }
}