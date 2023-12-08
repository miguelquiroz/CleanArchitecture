using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeatherForecasts.Queries.GetWeatherForecasts
{
    public class GetWeatherForecastRequest : IRequest<IEnumerable<WeatherForecast>>
    {
    }
}
