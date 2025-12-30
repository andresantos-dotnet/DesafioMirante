using AutoMapper;
using CrossCutting.DependencyInjection;
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

// Registra AutoMapper escaneando todos os assemblies do projeto
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Registra dependências das camadas
ConfigureService.ConfigureDependencies(builder.Services);

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