using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NegoSudApi.Services;
using NegoSudApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
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
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IProducerService, ProducerService>();
        services.AddScoped<IRegionService, RegionService>();
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"] ?? throw new InvalidOperationException())),
                ValidateIssuer = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            };
        });

        var connectionString = Configuration.GetConnectionString("DefaultNegoSudDbContext")?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");;

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
        app.UseSession();
        app.UseRouting();
        app.UseAuthentication();
        app.UseMvc();
    }
}