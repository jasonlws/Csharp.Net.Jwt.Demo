using Csharp.Net.Jwt.EcdsaKey.Server.Services;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;

// Load appsettings.json
IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Csharp.Net.Jwt.EcdsaKey.Server", Version = "v1" });
});

config["EcdsaKey"] = File.ReadAllText(Environment.GetEnvironmentVariable("EcdsaKeyPath"));
config["Issuer"] = Environment.GetEnvironmentVariable("Issuer") ?? config["Issuer"];
config["Audience"] = Environment.GetEnvironmentVariable("Audience") ?? config["Audience"];
config["TokenExpires"] = Environment.GetEnvironmentVariable("TokenExpires") ?? config["TokenExpires"];

builder.Configuration.AddConfiguration(config);

builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    IdentityModelEventSource.ShowPII = true;
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
