using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NegoSudApi.Services;

namespace NegoSudApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

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
            // TODO : Register all the services
            services.AddScoped<IGrapeService, GrapeService>();
            
            var connectionString = Configuration.GetConnectionString("DefaultNegoSudDbContext");
            
            services.AddDbContext<NegoSudContext>(options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NegoSudContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NegoSudWebAPI");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseHttpLogging();

            app.UseHttpsRedirection();

            app.UseSession();

            app.UseRouting();
            dataContext.Database.EnsureCreated();
        }
    }
}
