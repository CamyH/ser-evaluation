using AudioProcessingService.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.Run();
