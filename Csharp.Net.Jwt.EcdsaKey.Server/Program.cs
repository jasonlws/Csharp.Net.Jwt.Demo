using Csharp.Net.Jwt.EcdsaKey.Server.Services;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Load appsettings.json
IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

config["ShowSwagger"] = Environment.GetEnvironmentVariable("ShowSwagger") ?? "false";
config["EcdsaKey"] = File.ReadAllText(config["EcdsaKeyPath"]);
config["Issuer"] = Environment.GetEnvironmentVariable("Issuer") ?? config["Issuer"];
config["Audience"] = Environment.GetEnvironmentVariable("Audience") ?? config["Audience"];
config["TokenExpires"] = Environment.GetEnvironmentVariable("TokenExpires") ?? config["TokenExpires"];

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo {
      Version = "v1",
      Title = "JWT ECDSA Server Demo",
      Description = "<h3>JWT Configuration - Registered claims</h3><b>Issuer</b>: " + config["Issuer"] + "<br /><b>Audience</b>: " + config["Audience"] + "<br /><b>Expiration Time</b>: " + TimeSpan.FromMilliseconds(int.Parse(config["TokenExpires"])).TotalSeconds + " seconds",
      Contact = new OpenApiContact
      {
        Name = "jasonlws",
        Url = new Uri("https://www.jasonlws.com/")
      },
      License = new OpenApiLicense
      {
        Name = "MIT License",
        Url = new Uri("https://raw.githubusercontent.com/jasonlws/Csharp.Net.Jwt.Demo/master/LICENSE")
      }
    });
});

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
