Feature: WeatherForecastController

Get weather forecast from the service

@GetWhater
Scenario: Get weather forecast
	When Send HTTP GET request to URL "/WeatherForecast"
	Then The response should not be empty
