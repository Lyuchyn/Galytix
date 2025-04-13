using FluentValidation;
using GalytixAssessment.Csv;
using GalytixAssessment.Dtos;
using GalytixAssessment.Models;
using GalytixAssessment.Repositories;
using GalytixAssessment.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddValidatorsFromAssemblyContaining<GwpInputDtoValidator>();

builder.Services.AddSingleton<IGwpByCountryDataSet, GwpByCountryDataSet>(provider =>
{
    return CsvDataLoader.LoadCsv("Csv/gwpByCountry.csv");
});
builder.Services.AddScoped<IGwpDataRepository, GwpDataRepository>();
builder.Services.AddScoped<IGwpCalculationService, GwpCalculationService>();

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
