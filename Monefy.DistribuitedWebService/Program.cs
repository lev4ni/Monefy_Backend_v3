using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddApiVersioning(options => {
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
