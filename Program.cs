using CRUD.DbContext;
using CRUD.Models.IdentityEntities;
using CRUD.Repositories;
using CRUD.RepositoryContracts;
using CRUD.ServiceContracts;
using CRUD.Services;
using CRUD.StartupExtentions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<ICountryService, CountryService>();
//builder.Services.AddScoped<IPersonService,PersonService>();
//builder.Services.AddScoped<ICountryRepositories, CountryRepository>();
//builder.Services.AddScoped<IPersonRepositories, PersonRepository>();




//builder.Services.AddDbContext<ApplicationDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
//});

builder.Services.Configure(builder);

var app = builder.Build();
//app.UseHttpLogging();
Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot",wkhtmltopdfRelativePath:"Rotativa");


app.UseExceptionHandler("/Error");

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});
app.MapControllers();



app.Run();
