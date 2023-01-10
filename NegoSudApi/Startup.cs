using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NegoSudApi.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NegoSudApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
            services.AddHttpLogging((options) => {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.Request;
            });
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "NegosudWebAPI", Version = "v1" }));
            // Register service
            services.AddScoped<IGrapeService, GrapeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NegosudWebAPI");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseHttpLogging();

            app.UseHttpsRedirection();

            app.UseSession();

            app.UseRouting();
        }
    }
}
