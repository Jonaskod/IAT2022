using IAT2022.Data;
using IAT2022.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionPostgres = builder.Configuration["ConnectionStrings:Default"];
string connectionSQLite = builder.Configuration["ConnectionStrings:Develop"];
string EmailApi = builder.Configuration["MailApiKey"];

//builder.Services.AddDbContext<AppDbContext>(
//    o => o.UseMySql(builder.Configuration.GetConnectionString("Default"), ServerVersion.AutoDetect("Default")));



//builder.Services.AddDbContext<LoginDbContext>(
//    o => o.UseMySql(builder.Configuration.GetConnectionString("Default"), ServerVersion.AutoDetect("Default")));

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(
    o => o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionPostgres)));

builder.Services.AddDbContext<LoginDbContext>(
    o => o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});


#region SQLite
//builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite(connectionSQLite)); //
//builder.Services.AddScoped<IDbRepository, DbRepository>();

//builder.Services.AddDbContext<LoginDbContext>(
//   options => options.UseSqlite(connectionSQLite));
#endregion

builder.Services.AddScoped<IDbRepository, DbRepository>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
 .AddEntityFrameworkStores<LoginDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = true;

});

    builder.Services.Configure<CookiePolicyOptions>(options =>
    {
        // This lambda determines whether user consent for non-essential 
        // cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        // requires using Microsoft.AspNetCore.Http;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
