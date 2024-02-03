using ExceptionHandling.Api.NewApproach;
using ExceptionHandling.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddExceptionHandler<ExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(option => { }); // This is a bug. Microsoft will fix this in next version
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
