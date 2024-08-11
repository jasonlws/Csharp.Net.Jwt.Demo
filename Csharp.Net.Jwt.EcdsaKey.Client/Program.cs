using Csharp.Net.Jwt.EcdsaKey.Client.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

config["ShowSwagger"] = Environment.GetEnvironmentVariable("ShowSwagger") ?? "false";
config["EcdsaKey"] = File.ReadAllText(config["EcdsaKeyPath"]);
List<string> issuers = Environment.GetEnvironmentVariable("Issuers") == null ? config["Issuers"].Split(";").ToList() : Environment.GetEnvironmentVariable("Issuers").Split(";").ToList();
List<string> audiences = Environment.GetEnvironmentVariable("Audiences") == null ? config["Audiences"].Split(";").ToList() : Environment.GetEnvironmentVariable("Audiences").Split(";").ToList();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo {
      Version = "v1",
      Title = "JWT ECDSA Client Demo",
      Description = "<h3>JWT Configuration - Registered claims</h3><b>Verify Issuer(s)</b>: " + String.Join(", ", issuers) + "<br /><b>Verify Audience(s)</b>: " + String.Join(", ", audiences),
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
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below. Example: 'Bearer jasonlwsjasonlwsjasonlws'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});

builder.Configuration.AddConfiguration(config);

builder.Services.AddScoped<ITokenService, TokenService>();

// Adding Authentication
var ecdsa = ECDsa.Create();
ecdsa.ImportFromPem(config["EcdsaKey"]);
builder.Services.AddAuthentication(
        options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuers = issuers,
                ValidAudiences = audiences,
                IssuerSigningKey = new ECDsaSecurityKey(ecdsa),
                ClockSkew = TimeSpan.Zero
            };
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
