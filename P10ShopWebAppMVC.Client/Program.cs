using Microsoft.EntityFrameworkCore;
using P03WeatherForecastWPF.Client.Services;
using P06Shop.Shared.Services.ProductService;
using P10ShopWebAppMVC.Client.Data;
using System.Globalization;

namespace P10ShopWebAppMVC.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddDbContext<ShopContext>(options =>
            //  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddHttpClient<IProductService, ProductService>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
            });

            var supportedCultures = new[] { new CultureInfo("en-US") };
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            var app = builder.Build();
            app.UseRequestLocalization();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
