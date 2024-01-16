using System.Collections;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebshopTDD.Models;

namespace WebshopTDD.Service
{

    public class ProductService : IProductService, IEnumerable<Product>
    {
        private readonly IFileService _fileService;
        private readonly string _productsFilePath;
        private List<Product> _products;

        public ProductService(IFileService fileService, IOptions<ProductServiceOptions> options
            )
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _productsFilePath = options?.Value?.ProductsFilePath ??
                                throw new ArgumentNullException(nameof(options.Value.ProductsFilePath));

        }

        public IEnumerator<Product> GetEnumerator()
        {
            return _products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddProduct(Product product)
        {
            try
            {
                var products = GetAllProducts();
                products.Add(product);
                SaveProducts(products);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ProductServiceException("Error adding product.", ex);
            }
        }

        public Product GetProductById(int productId)
        {
            try
            {
                var products = GetAllProducts();
                return products.SingleOrDefault(p => p.Id == productId);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ProductServiceException("Error retrieving product by ID.", ex);
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                var productsJson = _fileService.ReadAllText(_productsFilePath);
                Console.WriteLine(productsJson);
                Console.WriteLine(_productsFilePath);

                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsJson) ?? new List<Product>();
                Console.WriteLine($"product obj {products}");
                return products;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ProductServiceException("Error getting all products.", ex);
            }
        }

        public void UpdateProduct(Product updatedProduct)
        {
            try
            {
                var products = GetAllProducts();
                var existingProduct = products.FirstOrDefault(p => p.Id == updatedProduct.Id);

                if (existingProduct != null)
                {
                    existingProduct.Name = updatedProduct.Name;
                    existingProduct.PictureUrl = updatedProduct.PictureUrl;
                    SaveProducts(products);
                }
                else
                {
                    throw new ProductServiceException($"Product with ID {updatedProduct.Id} not found for update.");
                }
            }
            catch (Exception ex)
            {
                throw new ProductServiceException("Error updating product.", ex);
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                var products = GetAllProducts();
                var productToRemove = products.FirstOrDefault(p => p.Id == productId);

                if (productToRemove != null)
                {
                    products.Remove(productToRemove);
                    SaveProducts(products);
                }
                else
                {
                    throw new ProductServiceException($"Product with ID {productId} not found for deletion.");
                }
            }
            catch (Exception ex)
            {
                throw new ProductServiceException("Error deleting product.", ex);
            }
        }

        private void SaveProducts(List<Product> products)
        {
            try
            {
                var productsJson = JsonConvert.SerializeObject(products);
                _fileService.WriteAllText(_productsFilePath, productsJson);
            }
            catch (Exception ex)
            {
                throw new ProductServiceException("Error saving products.", ex);
            }
        }

        public void SaveProducts(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductById(List<int> productIds)
        {
            throw new NotImplementedException();
        }
    }
}
