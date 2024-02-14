
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Servicos.api.Livraria.Core.Entities
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id {get;set;}

        DateTime CreatedDate {get;}
    }
}