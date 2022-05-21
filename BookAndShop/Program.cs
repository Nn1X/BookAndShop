using BookAndShop.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookAndShop.Data;
using BookAndShop.Areas.Identity;
using DevExpress.Blazor;
using BookAndShop.Extentions;
using BookAndShop.Services.BasketService;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseWebRoot("wwwroot").UseStaticWebAssets();
var connectionString = builder.Configuration.GetConnectionString("BookAndShopContextConnection");builder.Services.AddDbContext<BookAndShopContext>(options =>
    options.UseNpgsql("Host=localhost; Port=5432; User Id=postgres; Password=sa; Database=BookShop")); builder.Services.AddDefaultIdentity<User>(options => { 
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 5;   // ����������� �����
    options.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
    options.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
    options.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
    options.Password.RequireDigit = false; // ��������� �� �����
    }).AddErrorDescriber<RuIdentityErrorDescriber>().AddRoles<IdentityRole>().AddEntityFrameworkStores<BookAndShopContext>();
// Add services to the container.

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql("Host=localhost; Port=5432; User Id=postgres; Password=sa; Database=BookShop"));

builder.Services.AddScoped<TokenProvider>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDevExpressBlazor();

builder.Services.AddScoped<IBasketService, BasketService>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
