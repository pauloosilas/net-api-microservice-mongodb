
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Servicos.api.Livraria.Core;
using Servicos.api.Livraria.Core.Entities;

namespace Servicos.api.Livraria.Repository
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument: IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IOptions<MongoSettings> options) //MongoSettings mongoSettings
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var db = client.GetDatabase(options.Value.Database);

            _collection = db.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute) documentType.GetCustomAttributes(
                        typeof(BsonCollectionAttribute), true).FirstOrDefault()).CollectionName;
        }

        public async Task<IEnumerable<TDocument>> GetAll()
        {
            return await _collection.Find(p => true).ToListAsync();
        }

        public async Task<TDocument> GetById(string Id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task InsertDocument(TDocument document)
        {
           await _collection.InsertOneAsync(document);
        }

        public async Task UpdateDocument(TDocument document)
        {
           var filter = Builders<TDocument>.Filter.Eq(doc=>doc.Id, document.Id);
           await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public async Task DeleteById(string Id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Id);
            await _collection.FindOneAndDeleteAsync(filter);
        }
    }
}