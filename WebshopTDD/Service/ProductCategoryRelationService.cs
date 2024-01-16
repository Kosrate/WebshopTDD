using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebshopTDD.Models;

namespace WebshopTDD.Service
{
    public class ProductCategoryRelationService : IProductCategoryRelationService
    {
        private readonly IFileService _fileService;
        private readonly string _productCategoryFilePath;
        private List<ProductCategoryRelation> _relations;

        public ProductCategoryRelationService(IFileService fileService, IOptions<ProductServiceOptions> options)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _productCategoryFilePath = options.Value.ProductCategoryFilePath ??
                                       throw new ArgumentNullException(nameof(options.Value.ProductCategoryFilePath));

            InitializeRelations();
        }

        private void InitializeRelations()
        {
            if (_fileService.Exists(_productCategoryFilePath))
            {
                string fileContent = _fileService.ReadAllText(_productCategoryFilePath);
                _relations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductCategoryRelation>>(fileContent);
            }
            else
            {
                _relations = new List<ProductCategoryRelation>();
                SaveRelationsToFile(); // Create an empty file if it doesn't exist
            }
        }

        private void SaveRelationsToFile()
        {
            string serializedData = JsonConvert.SerializeObject(_relations);
            _fileService.WriteAllText(_productCategoryFilePath, serializedData);
        }

        public ProductCategoryRelationService()
        {
            _relations = new List<ProductCategoryRelation>();
        }

        public void AddRelation(ProductCategoryRelation relation)
        {
            _relations.Add(relation);
        }

        public List<ProductCategoryRelation> GetAllRelations()
        {
            return _relations;
        }

        public List<ProductCategoryRelation> GetRelationsByProductId(int productId)
        {
            return _relations.Where(r => r.ProductIds.Contains(productId)).ToList();
        }

        public List<ProductCategoryRelation> GetRelationsByCategoryId(int categoryId)
        {
            return _relations.Where(r => r.CategoryIds.Contains(categoryId)).ToList();
        }

        public void UpdateRelation(ProductCategoryRelation updatedRelation)
        {
            var existingRelation = _relations.FirstOrDefault(r =>
                r.ProductIds.SequenceEqual(updatedRelation.ProductIds) &&
                r.CategoryIds.SequenceEqual(updatedRelation.CategoryIds));

            if (existingRelation != null)
            {
                _relations.Remove(existingRelation);
                _relations.Add(updatedRelation);
            }
        }

        public void DeleteRelation(ProductCategoryRelation relationToDelete)
        {
            _relations.Remove(relationToDelete);
        }

        public void AddBulkRelations(List<ProductCategoryRelation> relations)
        {
            _relations.AddRange(relations);
        }

        public void DeleteBulkRelations(List<ProductCategoryRelation> relationsToDelete)
        {
            foreach (var relation in relationsToDelete)
            {
                _relations.Remove(relation);
            }
        }
    }
}