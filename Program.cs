using palmHillsapp;
using palmHillsapp.Services;
using palmHillsapp.Interfaces;
using palmHillsapp.Classes;
using Microsoft.AspNetCore.Builder;
using palmHillsapp.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("Logging:EmailSettings"));

builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();


app.UseCors("FrontendPolicy");
app.MapControllers();

app.Run();