using CRUD.DbContext;
using CRUD.Models.IdentityEntities;
using CRUD.Repositories;
using CRUD.RepositoryContracts;
using CRUD.ServiceContracts;
using CRUD.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUD.StartupExtentions
{
    public static class ConfugurationExtention
    {
        public static void Configure(this IServiceCollection services,WebApplicationBuilder builder)
        {
            services.AddControllersWithViews();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICountryRepositories, CountryRepository>();
            services.AddScoped<IPersonRepositories, PersonRepository>();
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
                .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();
        }
    }
}
