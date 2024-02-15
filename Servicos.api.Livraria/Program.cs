using Servicos.api.Livraria.Core;
using Servicos.api.Livraria.Core.ContextMongoDb;
using Servicos.api.Livraria.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//************************************************

builder.Services.Configure<MongoSettings>(options =>
{
    builder.Configuration.GetSection("MongoDb").Bind(options);
});

/*builder.Services.Configure<MongoSettings>(
    options => {
        options.ConnectionString = builder.Configuration.GetSection("MongoDb:ConnectionString").Value;
        options.Database = builder.Configuration.GetSection("MongoDb:Database").Value;
    }
);*/

builder.Services.AddSingleton<MongoSettings>();
builder.Services.AddTransient<IAutorContext, AutorContext>();
builder.Services.AddTransient<IAutorRepository, AutorRepository>();

builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsRule", rule => 
    {
        rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
    });
});


//************************************************

var app = builder.Build();
app.UseRouting();
//app.UseHttpsRedirection();
app.UseCors("CorsRule");
app.UseAuthorization();

app.MapControllers();
app.Run();
