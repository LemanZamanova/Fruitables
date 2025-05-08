using Fruitables.DAL;
using Fruitables.Models;
using Fruitables.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fruitables.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id <= 0)
            {
                return BadRequest();
            }
            Product? product = await _context.Products
                .Include(p => p.ProductImage)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);


            if (product is null)
            {
                return NotFound();
            }


            DetailVM detailVM = new DetailVM
            {
                Product = product,
                RelatedProducts = await
                _context.Products
                .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                .Take(8)
                .Include(p => p.ProductImage.Where(pi => pi.IsPrimary != null))
                .ToListAsync(),
                FeatureProducts = await _context.Products
        .OrderByDescending(p => p.Category)
        .Include(p => p.ProductImage.Where(pi => pi.IsPrimary != null))
        .Take(5)
        .ToListAsync()


            };

            return View(detailVM);




        }
    }
}
