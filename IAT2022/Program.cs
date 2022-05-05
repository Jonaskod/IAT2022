using IAT2022.Data;
using IAT2022.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionPostgres = builder.Configuration["ConnectionStrings:Default"];
string connectionSQLite = builder.Configuration["ConnectionStrings:Develop"];

builder.Services.AddDbContext<AppDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("Default"),
    o => o.SetPostgresVersion(new Version(12, 10))));

builder.Services.AddDbContext<LoginDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("Default"),
    o => o.SetPostgresVersion(new Version(12, 10))));

#region SQLite
//builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite(connectionSQLite)); // Hur man ansluter till sqllite databas (DBeaver) Pirater/Hockeyclubar
//builder.Services.AddScoped<IDbRepository, DbRepository>();

//builder.Services.AddDbContext<LoginDbContext>(
//   options => options.UseSqlite(connectionSQLite));
#endregion
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
 .AddEntityFrameworkStores<LoginDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
