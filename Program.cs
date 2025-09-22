var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHealthChecks();

// Agrega la política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Usa la política de CORS antes de UseAuthorization
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
