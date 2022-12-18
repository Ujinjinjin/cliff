public class WeatherService : IWeatherService
{
	public void DisplayWeatherConditionMessage(int temperature)
	{
		var message = GetWeatherConditionMessage(temperature);
		Console.WriteLine(message);
	}

	private string GetWeatherConditionMessage(int temperature)
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
