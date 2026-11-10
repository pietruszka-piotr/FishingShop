using FishingShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishingShop.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var products = new List<Product>
        {
            new Product
            {
                Name = "Wędka spinningowa 240",
                Description = "Uniwersalna wędka o długości 2,40 m do łowienia na spinning.",
                Price = 149.90m
            },
            new Product
            {
                Name = "Kołowrotek 2500",
                Description = "Kołowrotek z przednim hamulcem do lekkiego łowienia spinningowego.",
                Price = 189.00m
            },
            new Product
            {
                Name = "Błystka obrotowa nr 2",
                Description = "Obrotowa przynęta o masie 5 g do łowienia okoni i pstrągów.",
                Price = 12.50m
            }
        };

        return View(products);
    }
}
