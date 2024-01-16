using WebshopTDD.Models;

namespace WebshopTDD.Service
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void UpdateProduct(Product updatedProduct);
        void DeleteProduct(int productId);
        void SaveProducts(Product product);
        Product GetProductById(int productId);
        List<Product> GetAllProducts();
        List<Product> GetProductById(List<int> productIds);
    }
}