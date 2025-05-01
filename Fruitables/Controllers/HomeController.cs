using Fruitables.DAL;
using Fruitables.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fruitables.Controllers
{
    public class HomeController : Controller
    {
        public readonly AppDbContext _context;




        public HomeController(AppDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {

            #region List


            //List<Slider> slides = new List<Slider>
            //{
            //    new Slider
            //    {

            //        Title="Terevez",

            //        Order=2,
            //        Image="images.jpg"
            //    },
            //     new Slider
            //      {

            //        Title="Meyve",

            //        Order=1,
            //        Image="hero-img-1.png"
            //    },
            //      new Slider
            //        {

            //        Title="Qarisiq",

            //        Order=4,
            //        Image="hero-img-2.jpg"
            //    },
            //       new Slider
            //          {

            //        Title="Gilemeyve",

            //        Order=3,
            //        Image="photo_50379.jpg"
            //    },
            //};
            #endregion


            HomeVM homeVM = new HomeVM
            {
                Slides = _context.Slides
                .OrderBy(s => s.Order)
                .Take(4)
                .ToList(),
                Products = _context.Products
                .Take(8)
                .Include(p => p.ProductImage.Where(pi => pi.IsPrimary != null))
                .ToList()

            };

            return View(homeVM);
        }
    }
}
