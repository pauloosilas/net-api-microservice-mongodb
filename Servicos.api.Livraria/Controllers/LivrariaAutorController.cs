
using Microsoft.AspNetCore.Mvc;
using Servicos.api.Livraria.Core.Entities;
using Servicos.api.Livraria.Repository;

namespace Servicos.api.Livraria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrariaAutorController : ControllerBase
    {
        private readonly IMongoRepository<AutorEntity> _autorGenericoRepository;

        public LivrariaAutorController(IMongoRepository<AutorEntity> autorGenericoRepository)
        {
            _autorGenericoRepository = autorGenericoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> Get()
        {
           return Ok(await _autorGenericoRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorEntity>> GetById(string id)
        {
            var autor = await _autorGenericoRepository.GetById(id);
            return Ok(autor);
        }

        [HttpPost]
        public async Task Post(AutorEntity autor)
        {
            await _autorGenericoRepository.InsertDocument(autor);
        }

        [HttpPut("{id}")]
        public async Task Put(string Id, AutorEntity autor)
        {
            autor.Id = Id;
           await _autorGenericoRepository.UpdateDocument(autor);
        }
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _autorGenericoRepository.DeleteById(id);
        }

        [HttpPost("paginationF")]
        public async Task<ActionResult<PaginationEntity<AutorEntity>>> PostPagination(PaginationEntity<AutorEntity> pagination)
        {
            var resultados = await _autorGenericoRepository.PaginationBy(
                        filter => filter.Nome == pagination.Filter,
                        pagination);


             return Ok(resultados);
            
        } 

       [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<AutorEntity>>> PostPaginationByFilter(PaginationEntity<AutorEntity> pagination)
        {
            var resultados = await _autorGenericoRepository.PaginationByFilter(pagination);

             return Ok(resultados);
            
        } 
    }
}