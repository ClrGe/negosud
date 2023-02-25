using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NegoSudApi.Services;
using NegoSudApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using NegoSudApi.Data;
using HeimGuard;
using NegoSudApi.Models;

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
        
        // Add Cors
        services.AddCors();
        
        
        services.AddMvc(options => options.EnableEndpointRouting = false)
            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        

        services.AddSession();
        services.AddHttpLogging((options) =>
        {
            options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.Request;
        });

        services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "NegoSudWebAPI", Version = "v1" }));

        services.AddScoped<IBottleService, BottleService>();
        services.AddScoped<IStorageLocationService, StorageLocationService>();
        services.AddScoped<IGetStorageLocationService, GetStorageLocationService>();
        services.AddScoped<IGetBottleService, GetBottleService>();
        services.AddScoped<IGrapeService, GrapeService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IProducerService, ProducerService>();
        services.AddScoped<IRegionService, RegionService>();
        services.AddScoped<IWineLabelService, WineLabelService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<ICustomerOrderService, CustomerOrderService>();
        services.AddScoped<ISupplierOrderService, SupplierOrderService>();
        services.AddScoped<IVatService, VatService>();
        services.AddScoped<SecurePassword>();
        services.AddTransient<IJwtAuthenticationService, JwtAuthenticationService>();


        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    // ValidAudience = Configuration["Jwt:AUdience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"] ?? throw new InvalidOperationException())),
                    ValidateIssuer = true,
                    ValidateLifetime = false,
                    ValidateAudience = false, // set as false now. TODO : check the purpose of this parameter
                    ValidateIssuerSigningKey = true
                };
            });
        services.AddAuthorization();

        services.AddHeimGuard<UserPermissionService>()
        .AutomaticallyCheckPermissions()
        .MapAuthorizationPolicies();


        var connectionString = Configuration.GetConnectionString("NegoSudDbContext") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<NegoSudDbContext>(options =>
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());
        

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NegoSudDbContext dbContext)
    {
        dbContext.Database.Migrate();

        dbContext.SaveChanges();

        // Seed Default Permissions
        List<Permission> dbPermissions = dbContext.Permissions.ToList();
        foreach(var perm in RolePermissions.DefaultEmployeePermissions)
        {
            if(!dbPermissions.Any(p => p.Name == perm))
            {
                Permission newPermission = new Permission()
                {
                    Name = perm,
                };
                dbContext.Permissions.Add(newPermission);
            }
        }

        dbContext.SaveChanges();
        // Seed Default Role
        List<Role> dbRoles = dbContext.Roles.ToList();
        foreach(var role in RolePermissions.Roles)
        {
            if(!dbRoles.Any(r => r.Name == role))
            {
                Role newRole = new Role()
                {
                    Name = role,
                };
                var newDbRole = dbContext.Roles.Add(newRole).Entity;
                if(role == RolePermissions.Customer)
                {                    
                    foreach (var perm in RolePermissions.DefaultCustomerPermissions)
                    {
                        if (!dbContext.PermissionRoles.Any(pr => pr.RoleId == newDbRole.Id && pr.Permission.Name == perm))
                        {
                            PermissionRole newPermissionRole = new PermissionRole()
                            {
                                Role = newDbRole,
                                Permission = dbContext.Permissions.FirstOrDefault(p => p.Name == perm),
                            };
                            dbContext.PermissionRoles.Add(newPermissionRole);
                        }                       
                    }                                       
                }
                else if (role == RolePermissions.Employee)
                {
                    foreach (var perm in RolePermissions.DefaultEmployeePermissions)
                    {
                        if (!dbContext.PermissionRoles.Any(pr => pr.RoleId == newDbRole.Id && pr.Permission.Name == perm))
                        {
                            PermissionRole newPermissionRole = new PermissionRole()
                            {
                                Role = newDbRole,
                                Permission = dbContext.Permissions.FirstOrDefault(p => p.Name == perm),
                            };
                            dbContext.PermissionRoles.Add(newPermissionRole);
                        }
                    }
                }
            }
        }

        dbContext.SaveChanges();
        
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "NegoSudWebAPI");
            c.RoutePrefix = "api/doc";
        });
        // global cors policy
        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials()); // allow credentials    
        app.UseHttpLogging();
        //app.UseHttpsRedirection();
        app.UseSession();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMvc();
    }
}