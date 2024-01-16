using WebshopTDD.Services;
using WebshopTDD.Models;

namespace WebshopTDD.Service
{
    
    public class Services : IService
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductCategoryRelationService _productCategoryService;

        public Services(IProductService productService, ICategoryService categoryService, IProductCategoryRelationService productCategoryService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _productCategoryService = productCategoryService ?? throw new ArgumentNullException(nameof(productCategoryService));
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }

        public IEnumerable<ProductCategoryRelation> GetProductCategoryRelation()
        {
            return _productCategoryService.GetAllRelations();
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            // Implement logic to retrieve products by category
            throw new NotImplementedException();
        }
    }
    }
