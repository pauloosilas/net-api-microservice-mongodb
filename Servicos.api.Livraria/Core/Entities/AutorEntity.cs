
using MongoDB.Bson.Serialization.Attributes;

namespace Servicos.api.Livraria.Core.Entities
{
    [BsonCollection("Autor")]
    public class AutorEntity:Document
    {
        [BsonElement("nome")]
        public string Nome {get;set;}

        [BsonElement("sobrenome")]
        public string Sobrenome {get;set;}

        [BsonElement("graduacaoAcademica")]
        public string GraduacaoAcademica {get;set;}
    }
}