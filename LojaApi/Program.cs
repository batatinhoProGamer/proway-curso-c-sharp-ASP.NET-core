using FluentValidation;
using LojaApi.DependencyInjections;
using LojaApi.Models.Produto;
using LojaApi.Validators;
using LojaRepositorios.database;
using LojaRepositorios.DependencyInjections;
using LojaServicos.DependencyInjections;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddServicesDependencyInjection()
    .AddRepositoriesDependencyInjection(builder.Configuration)
    .AddApiAutoMapper()
    .AddLojaAuthentication();

builder.Services.AddScoped<IValidator<ProdutoCreateModel>, ProdutoValidator>();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("healthz");

app.UseHttpsRedirection()
    .UseAuthorization()
    .UseSession();

app.MapControllers();

using(var scopo = app.Services.CreateScope())
{
    var contexto = scopo.ServiceProvider.GetService<LojaContexto>();
    if (contexto != null)
    {
        contexto.Database.Migrate();
    }
}

app.Run();
