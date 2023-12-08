
using CleanArchitecture.IntegrationTests.Factory;
using FluentAssertions;

namespace CleanArchitecture.IntegrationTests.StepDefinitions
{
    [Binding]
    public class WeatherForecastControllerStepDefinition : IClassFixture<ApiFactory>
    {
        private ApiFactory _factory;
        private HttpClient _client;
        private string? _result;


        internal WeatherForecastControllerStepDefinition(ApiFactory apiFactory)
        {
            _factory = apiFactory;
            _client = _factory.CreateClient();
        }

        [When(@"Send HTTP GET request to URL ""([^""]*)""")]
        public async Task WhenSendHTTPGETRequestToURL(string p0)
        {
            var response = await _client.GetAsync(p0);
            _result = await response.Content.ReadAsStringAsync();
        }

        [Then(@"The response should not be empty")]
        public void ThenTheResponseShouldNotBeEmpty()
        {
            _result.Should().NotBeNullOrWhiteSpace();
        }

    }
}
