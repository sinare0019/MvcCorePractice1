using Microsoft.EntityFrameworkCore;
using Microsoft.Identity;
using Microsoft.Extensions.Configuration;
using MvcCorePractice1.DataLayer;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

//builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//builder.Services.AddControllersWithViews().AddJsonOptions(options => {
//    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
//    options.JsonSerializerOptions.PropertyNamingPolicy = null;
//});
//builder.Services.AddDNTCaptcha(options =>
//               options.UseCookieStorageProvider()
//                   .ShowThousandsSeparators(false)
//           );

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => x.LoginPath = "/Account/Login");
builder.Services.AddDbContext<AppIdentityDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//ست کانتکست مخصوص identity
//builder.Services.AddDbContext<AppIdentityDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
//افزودن تنظیمات احراز هویت همان identity
/*
builder.Services.AddIdentity<IdentityUser, IdentityRole>(option =>
option.Password.RequireNonAlphanumeric = false // نیازی نیست برای انتخاب کلمه عبور حتما از کاراکتر های خاص اضافه شود
).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
*/
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
