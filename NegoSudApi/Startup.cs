using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NegoSudApi.Services;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(options => options.EnableEndpointRouting = false);
        services.AddSession();
        services.AddHttpLogging((options) =>
        {
            options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.Request;
        });
        services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "NegoSudWebAPI", Version = "v1" }));

        services.AddScoped<IGrapeService, GrapeService>();
        services.AddScoped<IBottleService, BottleService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IProducerService, ProducerService>();
        services.AddScoped<IRegionService, RegionService>();

        var connectionString = Configuration.GetConnectionString("DefaultNegoSudDbContext");

        services.AddDbContext<NegoSudDbContext>(options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NegoSudDbContext dbContext)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "NegoSudWebAPI");
            c.RoutePrefix = string.Empty;
        });
            
        app.UseHttpLogging();
        app.UseHttpsRedirection();
        app.UseMvc();
        app.UseSession();
        app.UseRouting();
        dbContext.Database.EnsureCreated();
    }
}