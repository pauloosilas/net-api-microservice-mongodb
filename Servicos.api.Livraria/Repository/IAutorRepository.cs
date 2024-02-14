using Servicos.api.Livraria.Core.Entities;

namespace Servicos.api.Livraria.Repository
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAutores();
      
    }
}