using MongoDB.Driver;
using Servicos.api.Livraria.Core.ContextMongoDb;
using Servicos.api.Livraria.Core.Entities;

namespace Servicos.api.Livraria.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly IAutorContext _autorContext;

        public AutorRepository(IAutorContext autorContext)
        {
            _autorContext = autorContext;
        }

        public async Task<IEnumerable<Autor>> GetAutores()
        {   
          return await _autorContext.Autores.Find(p=>true).ToListAsync();
        }
    }
}