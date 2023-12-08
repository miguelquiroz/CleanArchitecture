using CleanArchitecture.Application;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

//Configuration
var configbuilder = new ConfigurationBuilder()
               .SetBasePath(Environment.CurrentDirectory)
               //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

IConfiguration config = configbuilder.Build();
builder.Services.AddSingleton<IConfiguration>(config);


// Add services to the container.
builder.Services.ConfigureApplication();
builder.Services.ConfigureInfrastructure(config);

//Trace services
builder.Services.AddProblemDetails();
builder.Services.AddLogging(opt =>
{
    opt.AddDebug();
    opt.AddConsole();

});
//builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Exception manager
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.ContentType = "application/problem+json";
        if (context.RequestServices.GetService<IProblemDetailsService>() is { } problemDetailsService)
        {
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exceptionType = exceptionHandlerFeature?.Error;
            if (exceptionType is not null)
            {
                (string Title, string Detail, int StatusCode) details = exceptionType switch
                {
                    CustomValidationException customException =>
                    (
                        exceptionType.GetType().Name,
                        exceptionType.Message,
                        context.Response.StatusCode = (int)customException.StatusCode
                    ),
                    _ =>
                    (
                        exceptionType.GetType().Name,
                        exceptionType.Message,
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError
                    )
                };
                var problem = new ProblemDetailsContext
                {
                    HttpContext = context,
                    ProblemDetails =
                    {
                        Title = details.Title,
                        Detail = details.Detail,
                        Status = details.StatusCode
                    }
                };

                if (app.Environment.IsDevelopment())
                {
                    problem.ProblemDetails.Extensions.Add("exception", exceptionHandlerFeature?.Error.ToString());
                }

                await problemDetailsService.WriteAsync(problem);
            }
        }
    });
});

app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
