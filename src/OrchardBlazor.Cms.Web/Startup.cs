using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace OrchardBlazor.Cms.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOrchardCms();

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<StaticFileOptions>, BlazorConfigureStaticFilesOptions>());
        }
        
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            app.UseOrchardCore();
        }

        public class BlazorConfigureStaticFilesOptions : IPostConfigureOptions<StaticFileOptions>
        {
            private readonly IWebHostEnvironment _environment;

            public BlazorConfigureStaticFilesOptions(IWebHostEnvironment environment)
            {
                _environment = environment;
            }
            public void PostConfigure(string name, StaticFileOptions options)
            {
                name = name ?? throw new ArgumentNullException(nameof(name));
                options = options ?? throw new ArgumentNullException(nameof(options));

                if (name != Options.DefaultName)
                {
                    return;
                }

                // Basic initialization in case the options weren't initialized by any other component
                options.ContentTypeProvider = options.ContentTypeProvider ?? new FileExtensionContentTypeProvider();
                if (options.FileProvider == null && _environment.WebRootFileProvider == null)
                {
                    throw new InvalidOperationException("Missing FileProvider.");
                }

                options.FileProvider = options.FileProvider ?? _environment.WebRootFileProvider;

                var provider = new ManifestEmbeddedFileProvider(typeof(IServerSideBlazorBuilder).Assembly);

                options.FileProvider = new CompositeFileProvider(provider, options.FileProvider);
            }
        }
    }
}
