using Fruitables.DAL;
using Microsoft.EntityFrameworkCore;

namespace Fruitables
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer("server=DESKTOP-6SBB04J\\SQLEXPRESS;database=Fruitable;trusted_connection=true;integrated security=true;TrustServerCertificate=true;");
            }


            );
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}"


                );



            app.Run();
        }
    }
}
