using Cafe.BL.Services;
using Cafe.DAL.Contexts;
using Cafe.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cafe.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            string? connectionStr = builder.Configuration.GetConnectionString("default");
            builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(connectionStr));

            builder.Services.AddIdentity<AppUser, AppRole>()
                            .AddEntityFrameworkStores<AppDbContext>()
                            .AddDefaultTokenProviders();

            builder.Services.AddScoped<ChefService>();
            builder.Services.AddScoped<AccountService>();
                
            var app = builder.Build();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
                name:"default",
                pattern: "{controller=Home}/{action=Index}"
                );

            app.Run();
        }
    }
}
