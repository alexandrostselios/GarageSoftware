using DinkToPdf.Contracts;
using DinkToPdf;
using GarageAPI;
using GarageAPI.Controllers;
using GarageAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using sib_api_v3_sdk.Client;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddMvc().AddControllersAsServices();

/* Send Emails */
builder.Services.AddTransient<IEmailSender, EmailController>();

/* Brevo Email*/
Configuration.Default.ApiKey.Add("api-key", builder.Configuration["BrevoApi:ApiKey"]);

/* Send Emails */

/* Create PDF */
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
/* Create PDF */

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<GarageAPIDbContext>(options => options.UseInMemoryDatabase("CarModelDb"));
builder.Services.AddDbContext<GarageAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GarageAPIDbContext")));

builder.Services.AddCors(p => p.AddPolicy("corspolicy",build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
