using Verity.Cash.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddControllers();

builder.Services.AddRouting(c => c.LowercaseUrls  = true);

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerSetup();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
