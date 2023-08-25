using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servico de controller
builder.Services.AddControllers();

// Adiciona o servico de Swagger
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
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
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
