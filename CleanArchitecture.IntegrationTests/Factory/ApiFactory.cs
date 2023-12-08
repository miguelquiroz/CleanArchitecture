using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.IntegrationTests.Factory
{
    internal class ApiFactory : WebApplicationFactory<Program>
    {
        private readonly string _environment;

        public ApiFactory()
        {
            _environment = "Development";
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment(_environment);

            // Add mock/test services to the builder here or remove service
            //builder.ConfigureServices(services =>
            //{
            //    var service = services.FirstOrDefault(d => d.ServiceType == typeof(Service));
            //    services.Remove(service);
            //});

            var app = builder.Build();

            return base.CreateHost(builder);
        }
    }
}
