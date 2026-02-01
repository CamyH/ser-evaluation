using System.Net;
using AudioProcessingService.Api.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// Add Services
builder.Services.AddServices();

// Add Pipelines
builder.Services.AddPipelines();

// Health Check
builder.Services.AddHealthChecks()
    .AddCheck("healthy", () => HealthCheckResult.Healthy());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }

app.UseHttpsRedirection();

app.UseExceptionHandler(error =>
{
    error.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync("An unexpected error occurred.");
    });
});

app.MapHealthChecks("/api/v1/health");

app.MapControllers();

app.Run();
