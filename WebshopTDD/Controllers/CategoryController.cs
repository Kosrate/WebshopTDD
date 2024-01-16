using Microsoft.AspNetCore.Mvc;
using WebshopTDD.Service;

namespace WebshopTDD.Controllers;
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var categories = _categoryService.GetAllCategories();
        return View(categories);
    }
}