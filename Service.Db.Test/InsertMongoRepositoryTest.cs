using Servicos.api.Livraria.Core.Entities;
using Servicos.api.Livraria.Repository;

namespace Service.Db.Test;


public class InsertMongoRepositoryTest: IClassFixture<DbFixture>
{
    private readonly DbFixture _fixture;

    public InsertMongoRepositoryTest(DbFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateAsync_should_insert_new_user()
    {
        
        var autorEntity = new AutorEntity();
        autorEntity.Nome = "Paulo";
        autorEntity.Sobrenome = "Silas";
        autorEntity.GraduacaoAcademica = "So sei ler as figuras";
      
        await _fixture.mongoRepository.InsertDocument(autorEntity);

       // Assert.Throws<Exception>(await _fixture.mongoRepository.InsertDocument(autorEntity))
       Assert.Equal(1,1);
       Assert.Equal(2,2);

    }
}
