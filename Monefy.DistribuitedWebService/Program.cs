using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Monefy.Application.Configuration;
using System.Text;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Serilog.AspNetCore;
using ServiceStack;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });
builder.Services.AddApplication(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

// Configuración de Serilog para el registro de solicitudes HTTP
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error() //Debug()
    .Enrich.FromLogContext()
    .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
.CreateLogger();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog(dispose: true);
});

builder.Host.UseSerilog();

// Configuración de Health Checks
builder.Services.AddHealthChecks()
    .AddSqlServer(connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
        name: "SqlServer",
        failureStatus: HealthStatus.Unhealthy);

builder.Services.AddHealthChecksUI().AddInMemoryStorage();

//Recursos-idioma
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var app = builder.Build();

//idiomas
var supportedCultures = new List<CultureInfo>
{
    new CultureInfo("en"),
    new CultureInfo("es")
};

app.UseRequestLocalization(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

app.UseRouting();



app.MapHealthChecks("/healthCheck", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI();

app.UseSwagger();
app.UseSwaggerUI();

app.UseSerilogRequestLogging(); // Agrega el registro de solicitudes HTTP a Serilog

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.Use((context, next) =>
{
    var lang = context.Request.Query["lang"].ToString();
    if (!string.IsNullOrEmpty(lang) && supportedCultures.Any(c => c.Name == lang))
    {
        var culture = new CultureInfo(lang);
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
    }
    return next();
});

app.UseRequestLocalization(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
app.MapControllers();

app.Run();
