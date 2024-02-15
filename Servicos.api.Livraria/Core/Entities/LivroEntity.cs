using MongoDB.Bson.Serialization.Attributes;

namespace Servicos.api.Livraria.Core.Entities;

[BsonCollection("Livro")]
public class LivroEntity : Document
{
    [BsonElement("titulo")]
    public string Titulo {get;set;}

    [BsonElement("descricao")]
    public string Descricao {get;set;}

    [BsonElement("preco")]
    public int Preco {get;set;}

    [BsonElement("dataPublicacao")]
    public DateTime? DataPublicacao {get;set;}
    
    [BsonElement("autor")]
    public AutorEntity Autor {get;set;}

}
