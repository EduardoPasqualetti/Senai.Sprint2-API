var builder = WebApplication.CreateBuilder(args);

// Adiciona o servico de controller
builder.Services.AddControllers();

var app = builder.Build();

// Adiciona mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
