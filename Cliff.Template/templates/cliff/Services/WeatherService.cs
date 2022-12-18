using System.Text;

namespace Cliff.Template.Services;

public class WeatherService : IWeatherService
{
	public void DisplayWeatherConditionMessage(int temperature)
	{
		var weatherConditionMessage = GetWeatherConditionMessage(temperature);
		Console.WriteLine(weatherConditionMessage);
	}

	private string GetWeatherConditionMessage(int temperature)
	{
		var builder = new StringBuilder();

		var temperatureMessage = GetTemperatureMessage(temperature);
		var commentary = GetCommentary(temperature);

		builder.Append(temperatureMessage)
			.Append(Environment.NewLine)
			.Append(commentary);

		return builder.ToString();
	}

	private string GetTemperatureMessage(int temperature)
	{
		return $"Temperature: {temperature}°";
	}

	private string GetCommentary(int temperature)
	{
		return temperature switch
		{
			< -30 => "Brrr... It's freezing outside!",
			< -10 => "It's cold outside, put your hat on.",
			< 0 => "Rather cold outside, innit?",
			< 10 => "Not great, not terrible. Better stay ar home",
			< 25 => "The weather is perfect! Enjoy your day :)",
			< 40 => "What a time to get tanned. Put as much sun-protection as you can",
			_ => "Do you like barbecue? No? Well, I have some bad news..."
		};
	}
}
