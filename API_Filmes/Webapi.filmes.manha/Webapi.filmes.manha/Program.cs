using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servico de controller
builder.Services.AddControllers();

// Adiciona kinformacoes sobre a API    
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Manha",
        Description = " API para gerenciamento de filmes - Introducao da sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Eduardo Pasqualetti",
            Url = new Uri("https://github.com/EduardoPasqualetti")
        }
    });

    // Configura o Swagger para usar o arquivo xml gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Finaliza a configuracao do Swagger

// Adiciona mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
