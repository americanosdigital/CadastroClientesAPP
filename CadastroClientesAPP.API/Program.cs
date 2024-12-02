using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using CadastroClientesAPP.Domain.Interfaces.IRepositories;
using CadastroClientesAPP.Domain.Interfaces.IServices;
using CadastroClientesAPP.Domain.Services;
using CadastroClientesAPP.Infra.Data.Contexts;
using CadastroClientesAPP.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adicionar controladores
builder.Services.AddControllers();

// Configura��o para exibir os endpoints da API em caixa baixa
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do banco de dados In-Memory
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configurar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Cadastro de Documentos API",
        Description = "API para cadastro de documentos para o Teste Pr�tico da Profits Consulting",
        Contact = new OpenApiContact
        {
            Name = "Wellington Americano",
            Email = "americanosdigital@gmail.com"
        }
    });
});

// Configura��o para que o projeto Angular possa fazer requisi��es para a API
builder.Services.AddCors(
    config => config.AddPolicy("DefaultPolicy", builder => {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    })
);

// Configurando a inje��o de depend�ncia de cada interface do projeto
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

var app = builder.Build();

// Use a pol�tica de CORS
app.UseCors("AllowAllOrigins");

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
