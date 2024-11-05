using Microsoft.EntityFrameworkCore;
using WebAPI.Context;

var builder = WebApplication.CreateBuilder(args); // Cria a aplicação

builder.Services.AddControllers(); // Adiciona os controllers
builder.Services.AddEndpointsApiExplorer(); // Adiciona o explorador de API
builder.Services.AddSwaggerGen(); // Adiciona o gerador do Swagger

// Início do PostgreSQL
string postgreSQLConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "DefaultConnectionString"; // Define a string de conexão com o banco de dados

builder.Services.AddDbContext<AppDbContext>(options => // Adiciona o contexto do banco de dados
    options.UseNpgsql(postgreSQLConnectionString) // Define o provedor do banco de dados
);
// Fim do PostgreSQL

var app = builder.Build(); // Constrói a aplicação

if (app.Environment.IsDevelopment()) // Permite a visualização da documentação da API
{
    app.UseSwagger(); // Habilita o middleware do Swagger
    app.UseSwaggerUI(); // Habilita o middleware do Swagger UI
}

if (!app.Environment.IsDevelopment()) // Redireciona HTTP para HTTPS
{
    app.UseHttpsRedirection(); // Habilita o middleware de redirecionamento HTTPS
}

app.UseAuthorization(); // Habilita o middleware de autorização

app.MapControllers(); // Mapeia os controllers

app.Run(); // Executa a aplicação
