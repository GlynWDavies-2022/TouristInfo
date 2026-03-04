// ------------------------------------------------------------------------------------------------
// Application Starting Point
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// Service Container
// ------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddOpenApi();

builder.Services.AddProblemDetails(options =>
    options.CustomizeProblemDetails = ctx =>
    {
        ctx.ProblemDetails.Extensions
            .Add("additionalInfo", "Additional info example");
        ctx.ProblemDetails.Extensions
            .Add("server", Environment.MachineName);
    });

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// ------------------------------------------------------------------------------------------------
// Middleware Pipeline
// ------------------------------------------------------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// ------------------------------------------------------------------------------------------------
