var builder = WebApplication.CreateBuilder(args);

// ✅ Add controller support
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS
app.UseHttpsRedirection();

// ✅ Add controller routing
app.UseAuthorization();
app.MapControllers(); // This enables [ApiController] based routes

app.Run();
