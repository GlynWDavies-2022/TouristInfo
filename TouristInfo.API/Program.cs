// ------------------------------------------------------------------------------------------------
// Application Starting Point
// ------------------------------------------------------------------------------------------------

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------------------------------------
// Dependency Injection Container
// ------------------------------------------------------------------------------------------------

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// ------------------------------------------------------------------------------------------------
// Middleware Pipeline
// ------------------------------------------------------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// ------------------------------------------------------------------------------------------------