using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NewsEdge.DataAccess.Models;
using NewsEdge.DataAccess.Models.Context;
using NewsEdge.DataAccess.Models.Identity;
using NewsEdge.DataAccess.Repositories.CategoryRepository;
using NewsEdge.DataAccess.Repositories.NewsCategoryRepository;
using NewsEdge.DataAccess.Repositories.NewsCommentRepository;
using NewsEdge.DataAccess.Repositories.NewsInSectionRepository;
using NewsEdge.DataAccess.Repositories.NewsRepositories;
using NewsEdge.DataAccess.Repositories.NewsSectionRepository;
using NewsEdge.DataAccess.Repositories.NewsTagRepository;
using NewsEdge.DataAccess.Repositories.NewsViewRepository;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


services.AddControllersWithViews();
services.AddRazorPages();
services.AddServerSideBlazor();

services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

services.AddDbContext<NewsEdgeContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("Default"), options =>
    {
        options.MigrationsAssembly("NewsEdge.Web");
    });
});

services.AddIdentity<NewsEdgeUser, IdentityRole<long>>(opt =>
{
    opt.SignIn.RequireConfirmedEmail = false;
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<NewsEdgeContext>()
.AddDefaultTokenProviders()
.AddErrorDescriber<PersianIdentityErrorDescriber>();

services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, opt =>
{
    opt.LoginPath = "/Login";
    opt.LogoutPath = "/LogOut";
    opt.ExpireTimeSpan = TimeSpan.FromDays(8);
});

services.AddScoped<INewsRepository, EFNewsRepository>();
services.AddScoped<ICategoryRepository, EFCategoryRepository>();
services.AddScoped<INewsCategoryRepository, EFNewsCategoryRepository>();
services.AddScoped<INewsTagRepository, EFNewsTagRepository>();
services.AddScoped<INewsViewRepository, EFNewsViewRepository>();
services.AddScoped<ICommentRepository, EFCommentRepository>();
services.AddScoped<INewsSectionRepository, EFNewsSectionRepository>();
services.AddScoped<INewsInSectionRepository, EFNewsInSectionRepository>();


var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});
app.UseStatusCodePagesWithRedirects("/Errors/NotFound");

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute("admin", "Admin", "/Admin/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();


NewsEdgeSeedData.SeedData(app.Services);

app.Run();
