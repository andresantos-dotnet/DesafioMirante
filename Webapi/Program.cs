using Application;
using CrossCutting.DependencyInjection;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Infra.ORM.model;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Desafio Mirante - Andre Santos",
        Version = "v1",
        Description = "Swagger habilitado no .NET 8"
    });
});

ConfigureService.ConfigureDependencies(builder.Services);

////Applications
//builder.Services.AddScoped<IActivityApplication, ActivityApplication>();
////Repositories
//builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
////Contexts
//builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer("Server=SQL9001.site4now.net;Database=db_aa3182_bemnaweb;User Id=db_aa3182_bemnaweb_admin;Password=Mirante@2026;Integrated Security=False;Pooling=true"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.Run();
