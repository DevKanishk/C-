using OnlineStore.ApplicationCore;
using OnlineStore.ApplicationCore.Interface;
using OnlineStore.ApplicationCore.Services;
using OnlineStore.Infrastructure.Data;
using OnlineStore.Infrastructure.Identity;
using OnlineStore.Web.Interfaces;
using OnlineStore.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace OnlineStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddTransient<ICatalogService, CatalogService>();

            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.Configure<CatalogSettings>(builder.Configuration.GetSection("Catalog"));

            builder.Services.AddSingleton<IUriComposer>(sp =>
            {
                var catalogSettings = sp.GetRequiredService<IOptions<CatalogSettings>>().Value;
                return new UriComposer(catalogSettings);
            });

            builder.Services.AddDbContext<CatalogDbContext>(options =>
            {
                options.UseInMemoryDatabase("OnlineStore.Catalog");
            });

            // IMPORTANT: Added OrderDbContext
            builder.Services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseInMemoryDatabase("OnlineStore.Order");
            });

            // IMPORTANT: Added BasketDbContext
            builder.Services.AddDbContext<BasketDbContext>(options =>
            {
                options.UseInMemoryDatabase("OnlineStore.Basket");
            });

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseInMemoryDatabase("OnlineStore.Identity");
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSession();

            // IMPORTANT: Add this before UseAuthorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Catalog}/{action=Index}/{id?}")
                .WithStaticAssets();

            CatalogContextSeed.SeedAsync(app,
                app.Services.GetRequiredService<ILoggerFactory>())
                .Wait();

            AppIdentityDbContextSeed.SeedAsync(app.Services).GetAwaiter().GetResult();

            app.Run();
        }
    }
}