
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Servicos.api.Livraria.Core.Entities
{
    public class Autor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}

        [BsonElement("nome")]
        public string Nome {get;set;}

        [BsonElement("sobrenome")]
        public string Sobrenome{get;set;}

        [BsonElement("graduacaoAcademica")]
        public string GraduacaoAcademica {get; set;}
    }
}