using ExceptionHandling.Domain.DomainExceptions;

namespace ExceptionHandling.Domain
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<WeatherForecast>> GetForecast(string cityName)
        {
            if (cityName == "Bengaluru")
            {
                throw new DomainNotFoundException($"Data not available for {cityName}");
            }
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

            return await Task.FromResult(forecasts);
        }
    }
}
