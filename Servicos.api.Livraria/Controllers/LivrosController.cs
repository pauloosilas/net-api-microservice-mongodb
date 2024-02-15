using Microsoft.AspNetCore.Mvc;
using Servicos.api.Livraria.Core.Entities;
using Servicos.api.Livraria.Repository;

namespace Servicos.api.Livraria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly IMongoRepository<LivroEntity> _livroRepository;

    public LivrosController(IMongoRepository<LivroEntity> livroRepository)
    {
        _livroRepository = livroRepository;
    }

    [HttpPost]
    public async Task Post(LivroEntity livro){
        await _livroRepository.InsertDocument(livro);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LivroEntity>>> Get()
    {
        return Ok(await _livroRepository.GetAll());
    }

    [HttpPost("pagination")]
    public async Task<ActionResult<PaginationEntity<LivroEntity>>> PostPagination(PaginationEntity<LivroEntity> pagination){
        var resultados = await _livroRepository.PaginationByFilter(pagination);
        return Ok(resultados);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LivroEntity>> GetById(string id)
    {
        var livro = await _livroRepository.GetById(id);
        return Ok(livro);
    }

}
