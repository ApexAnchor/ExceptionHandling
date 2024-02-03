
namespace ExceptionHandling.Domain
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetForecast(string cityName);
    }
}
