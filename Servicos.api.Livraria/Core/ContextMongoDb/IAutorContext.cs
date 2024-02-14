using MongoDB.Driver;
using Servicos.api.Livraria.Core.Entities;

namespace Servicos.api.Livraria.Core.ContextMongoDb
{
    public interface IAutorContext
    {
        IMongoCollection<Autor> Autores {get;}
    }
}