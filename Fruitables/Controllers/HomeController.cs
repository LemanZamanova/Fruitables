using Fruitables.Models;
using Fruitables.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Slider> slides = new List<Slider>
            {
                new Slider
                {

                    Title="Terevez",

                    Order=2,
                    Image="images.jpg"
                },
                 new Slider
                  {

                    Title="Meyve",

                    Order=1,
                    Image="hero-img-1.png"
                },
                  new Slider
                    {

                    Title="Qarisiq",

                    Order=4,
                    Image="hero-img-2.jpg"
                },
                   new Slider
                      {

                    Title="Gilemeyve",

                    Order=3,
                    Image="photo_50379.jpg"
                },
            };
            HomeVM homeVM = new HomeVM
            {
                Slides = slides.OrderBy(s => s.Order).Take(4).ToList()

            };

            return View(homeVM);
        }
    }
}
