using BTGClientManager.Application.Interfaces;
using BTGClientManager.Application.Services;
using BTGClientManager.Domain.Interfaces;
using BTGClientManager.Infrastructure.Contexts;
using BTGClientManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuração da ConnectionString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton(new DapperContext(connectionString));

// Injeção de dependência
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

// Adicionar controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
