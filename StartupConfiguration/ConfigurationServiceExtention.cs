using CRUD.DbContext;
using CRUD.Models.IdentityEntities;
using CRUD.Repositories;
using CRUD.RepositoryContracts;
using CRUD.ServiceContracts;
using CRUD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CRUD.Configuration
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add MVC with Views
            services.AddControllersWithViews();

            // Add your services and repositories
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IPersonDeleterService, PersonDeleterService>();
            services.AddScoped<IPersonSetterService, PersonSetterService>();
            services.AddScoped<IPersonGetterService, PersonGetterService>();
            services.AddScoped<ICountryRepositories, CountryRepository>();
            services.AddScoped<IPersonRepositories, PersonRepository>();

            // Configure Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                // Define a fallback policy for authenticated users
                options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                // Define the 'NotAuthorized' policy
                options.AddPolicy("NotAuthorized1", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        return context.User?.Identity?.IsAuthenticated == false;
                    });
                });
            });


            // Configure Cookie Authentication
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "~Account/Login";
                options.LogoutPath = "/Account/Logout"; // Ensure correct paths for logout
            });

            // Configure DbContext with SQL Server connection string
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }

}
