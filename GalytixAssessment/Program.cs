using GalytixAssessment.Csv;
using GalytixAssessment.Repositories;
using GalytixAssessment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(provider =>
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
