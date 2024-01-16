using WebshopTDD.Models;

namespace WebshopTDD.Services
{
    public interface IService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ProductCategoryRelation> GetProductCategoryRelation();
        IEnumerable<Product> GetProductsByCategory(int categoryId);
    }
}