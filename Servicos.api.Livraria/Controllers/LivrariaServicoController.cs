
using Microsoft.AspNetCore.Mvc;
using Servicos.api.Livraria.Core.Entities;
using Servicos.api.Livraria.Repository;

namespace Servicos.api.Livraria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrariaServicoController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMongoRepository<AutorEntity> _autorGenericoRepository;
        public LivrariaServicoController(IAutorRepository autorRepository, IMongoRepository<AutorEntity> autorGenericoRepository)
        {
            _autorRepository = autorRepository;
            _autorGenericoRepository = autorGenericoRepository;
        }

        [HttpGet("autores")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await _autorRepository.GetAutores();
            return Ok(autores);
        }
     
        [HttpGet("autorGenerico")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> GetAutorGenerico()
        {
            var autores = await _autorGenericoRepository.GetAll();
            return Ok(autores);
        }
    }
}