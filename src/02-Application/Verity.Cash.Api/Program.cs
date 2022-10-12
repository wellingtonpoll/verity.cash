using Verity.Cash.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddControllers();

builder.Services.AddApiVersionConfiguration();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseApiVersionSetup();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
