using Exercise3_RestApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Register the in-memory repo
builder.Services
       .AddSingleton<IProductRepository, InMemoryProductRepository>()
       .AddControllers();

var app = builder.Build();
app.MapControllers();

// Listen on port 5100
app.Run("http://localhost:5100");