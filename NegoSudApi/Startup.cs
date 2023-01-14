using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NegoSudApi.Services;
using NegoSudApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using NegoSudApi.Data;

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
        services.AddMvc(options => options.EnableEndpointRouting = false)
            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);;
        services.AddSession();
        services.AddHttpLogging((options) =>
        {
            options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.Request;
        });
        services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "NegoSudWebAPI", Version = "v1" }));

        services.AddScoped<IGrapeService, GrapeService>();
        services.AddScoped<IBottleService, BottleService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IStorageLocationService, StorageLocationService>();
        services.AddScoped<IProducerService, ProducerService>();
        services.AddScoped<IRegionService, RegionService>();
        services.AddScoped<IWineLabelService, WineLabelService>();

            var connectionString = Configuration.GetConnectionString("DefaultNegoSudDbContext");

        services.AddDbContext<NegoSudDbContext>(options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NegoSudDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "NegoSudWebAPI");
            c.RoutePrefix = string.Empty;
        });
            
        app.UseHttpLogging();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSession();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMvc();
    }
}