using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.Product.FacadProduct;
using PerfumeLayte.Application.Services.Product.Querises.GetCateguryById;
using PerfumeLayte.Application.Services.Product.Querises.UserPermition;
using PerfumeLayte.Application.Services.User.Commands.AddToCart;
using PerfumeLayte.Application.Services.User.Commands.AddToLike;
using PerfumeLayte.Application.Services.User.Commands.Register;
using PerfumeLayte.Application.Services.User.Commands.SettingUser;
using PerfumeLayte.Application.Services.User.Querises.GetCartActive;
using PerfumeLayte.Application.Services.User.Querises.GetListCart;
using PerfumeLayte.Application.Services.User.Querises.GetUserByMobile;
using PerfumeLayte.Application.Services.User.Querises.GetUsers;
using PerfumeLayte.Application.Services.User.Querises.Login;
using PerfumeLayte.Persistence.Context;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAddToLikeUser, AddToLikeUser>();
    builder.Services.AddScoped<ICartListAndLikeUser, CartListAndLikeUser>();
builder.Services.AddScoped<IGetCartUserActive, GetCartUserActive>();
builder.Services.AddScoped<IDataBaseContext,Context>();
builder.Services.AddScoped<IsettingUser, settingUser>();
builder.Services.AddScoped<IAddToCartUser, AddToCartUser>();
builder.Services.AddScoped<IServisesRegister, ServicesRegister>();
builder.Services.AddScoped<IFacadProduct, FacadProduct>();
builder.Services.AddScoped<IGetUserServiceLogin, GetUserServiceLogin>();
builder.Services.AddScoped<GetCategutyById>();
builder.Services.AddScoped<IUserByMobileDetile, UserByMobileDetile>();
builder.Services.AddScoped<IUserPermition, UserPermition>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var Connection = "Data Source=.;Initial Catalog=companydb;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;Integrated Security=True;";
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(Connection)
    .EnableSensitiveDataLogging();
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Home/LogOut";
    });
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
