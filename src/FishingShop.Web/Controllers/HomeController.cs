using FishingShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishingShop.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var products = GetProducts();
        return View(products);
    }

    public IActionResult Details(int? id)
    {
        var product = GetProducts().FirstOrDefault(item => item.Id == id);

        if (product is null)
        {
            Response.StatusCode = StatusCodes.Status404NotFound;
            return View("ProductNotFound");
        }

        return View(product);
    }

    private static List<Product> GetProducts()
    {
        return new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Wędka spinningowa 240",
                Description = "Uniwersalna wędka o długości 2,40 m do łowienia na spinning.",
                Price = 149.90m
            },
            new Product
            {
                Id = 2,
                Name = "Kołowrotek 2500",
                Description = "Kołowrotek z przednim hamulcem do lekkiego łowienia spinningowego.",
                Price = 189.00m
            },
            new Product
            {
                Id = 3,
                Name = "Błystka obrotowa nr 2",
                Description = "Obrotowa przynęta o masie 5 g do łowienia okoni i pstrągów.",
                Price = 12.50m
            }
        };
    }
}
