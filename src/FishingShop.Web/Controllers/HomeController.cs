using FishingShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishingShop.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var product = new Product
        {
            Name = "Wędka spinningowa 240",
            Description = "Uniwersalna wędka o długości 2,40 m do łowienia na spinning.",
            Price = 149.90m
        };

        return View(product);
    }
}
