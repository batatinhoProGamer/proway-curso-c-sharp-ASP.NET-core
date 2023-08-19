using FluentValidation;
using LojaApi.Controllers;
using LojaApi.Validators;
using LojaServicos.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddServicesDependencyInjection()
    .AddRepositoriesDependencyInjection(builder.Configuration);

builder.Services.AddScoped<IValidator<ProdutoCreateModel>, ProdutoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
