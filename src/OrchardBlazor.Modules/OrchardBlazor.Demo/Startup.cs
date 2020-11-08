using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardBlazor.Demo.Data;
using OrchardCore.Modules;

namespace OrchardBlazor.Demo
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastService>();
        }
        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapBlazorHub("/OrchardBlazor.Demo/_blazor");
        }
    }
}
