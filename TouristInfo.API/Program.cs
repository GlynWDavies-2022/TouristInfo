// ------------------------------------------------------------------------------------------------
// Application Starting Point
// ------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.StaticFiles;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------------------------------------
// Dependency Injection Container
// ------------------------------------------------------------------------------------------------

builder.Services.AddControllers()
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddProblemDetails(options =>
    options.CustomizeProblemDetails = ctx =>
    {
        ctx.ProblemDetails.Extensions
            .Add("additionalInfo", "Additional info example");
        ctx.ProblemDetails.Extensions
            .Add("server", Environment.MachineName);
    });

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

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