using AutoMapper;
using CrossCutting.DependencyInjection;
using CrossCutting.Mappings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Desafio Mirante - Andre Santos",
        Version = "v1"
    });
});

// Registra dependências das camadas
ConfigureService.ConfigureDependencies(builder.Services);

// Registra AutoMapper escaneando todos os assemblies do projeto

var config = new MapperConfiguration(cfg =>
{

    cfg.AddProfile(new DtoToEntityProfile());
    cfg.AddProfile(new EntitiyToDtoProfile());
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Ativa Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();