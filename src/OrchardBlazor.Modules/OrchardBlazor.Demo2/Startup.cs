using System;
using Microsoft.AspNetCore.Builder;
using OrchardCore.Modules;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardBlazor.Demo2.Data;
using System.Diagnostics.Contracts;

namespace OrchardBlazor.Demo2
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastService>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapBlazorHub("/OrchardBlazor.Demo2/_blazor");
        }


    }
}
