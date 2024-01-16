using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebshopTDD.Services;
using WebshopTDD.Models;

namespace WebshopTDD.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index(int? categoryId)
        {
            // Filter products by category if categoryId is provided
            var products = categoryId.HasValue
                ? _service.GetProductsByCategory(categoryId.Value)
                : _service.GetAllProducts();

            return View(products);
        }

        public IActionResult Indexa()
        {
            return View();
        }
    }
}
