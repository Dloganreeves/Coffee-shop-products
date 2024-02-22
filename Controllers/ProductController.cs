using Microsoft.AspNetCore.Mvc;
using Coffee_Shop_Product_List.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_Product_List.Controllers
{
    
    public class ProductController : Controller
    {
        private ProductShopContext dbContext = new ProductShopContext();
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> result = dbContext.Products.ToList();
            return View(result);
        }

        [HttpPost]
        public IActionResult Index(Product c)
        {
            dbContext.Products.Add(c);
            dbContext.SaveChanges();

            List<Product> result = dbContext.Products.ToList();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            Product result = dbContext.Products.FirstOrDefault(c => c.Id == id);
            return View(result);
        }

    }
}
