using Microsoft.AspNetCore.Mvc;
using WebshopTDD.Models;
using WebshopTDD.Service;

namespace WebshopTDD.Controllers;
    public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IProductCategoryRelationService _productCategoryRelationService;

    public ProductController(
        IProductService productService,
        ICategoryService categoryService,
        IProductCategoryRelationService productCategoryRelationService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _productCategoryRelationService = productCategoryRelationService;
    }

    public IActionResult Index(int? categoryId)
    {
        var productCategoryDetails = new Dictionary<int, Tuple<Product, List<int>>>();
        var products = _productService.GetAllProducts();
        var categories = _categoryService.GetAllCategories();
        var PCRelation = _productCategoryRelationService.GetAllRelations();

        foreach (var relation in PCRelation)
        {
            foreach (var productId in relation.ProductIds)
            {
                if (!productCategoryDetails.ContainsKey(productId))
                {
                    productCategoryDetails[productId] = new Tuple<Product, List<int>>(
                        products.FirstOrDefault(p => p.Id == productId),
                        new List<int>()
                    );
                }

                productCategoryDetails[productId].Item2.AddRange(relation.CategoryIds);
                int a = 1;
                Console.WriteLine($"\nthis is productCategoryDetails {a}\n {productCategoryDetails}");
                a++;
            }
        }
        Console.WriteLine($"\nthis is productCategoryDetails \n {productCategoryDetails}");

        foreach (var kvp in productCategoryDetails)
        {
            var productId = kvp.Key;
            var product = kvp.Value.Item1;
            var categoryIds = kvp.Value.Item2;

            Console.WriteLine($"Product ID: {productId}, Product Name: {product?.Name}, Category IDs: {string.Join(", ", categoryIds)}");
        }

        if (categoryId.HasValue)
        {
            var category = _categoryService.GetCategoryById(categoryId.Value);
            if (category == null)
            {
                // Handle the case when the category is not found
                return NotFound();
            }

            products = _productCategoryRelationService.GetRelationsByCategoryId(categoryId.Value)
                .SelectMany(relation => relation.ProductIds.Select(productId => _productService.GetProductById(productId)))
                .ToList();
        }
        else
        {
            products = _productService.GetAllProducts();
        }

        ViewBag.SelectedCategoryId = categoryId;
        return View(productCategoryDetails.Values.ToList());

        //return View(products);
    }

}


