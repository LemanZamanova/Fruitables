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
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

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
