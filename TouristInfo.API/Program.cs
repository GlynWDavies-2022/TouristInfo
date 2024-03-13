// ------------------------------------------------------------------------------------------------
// Application Starting Point
// ------------------------------------------------------------------------------------------------

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------------------------------------
// Services Container
// ------------------------------------------------------------------------------------------------

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// ------------------------------------------------------------------------------------------------
// Application Starting Point
// ------------------------------------------------------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// ------------------------------------------------------------------------------------------------