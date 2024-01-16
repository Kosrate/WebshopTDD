using WebshopTDD.Models;

namespace WebshopTDD.Service
{
    public interface IProductCategoryRelationService
    {
        void AddRelation(ProductCategoryRelation relation);
        List<ProductCategoryRelation> GetAllRelations();
        List<ProductCategoryRelation> GetRelationsByProductId(int productId);
        List<ProductCategoryRelation> GetRelationsByCategoryId(int categoryId);
        void UpdateRelation(ProductCategoryRelation updatedRelation);
        void DeleteRelation(ProductCategoryRelation relationToDelete);
        void AddBulkRelations(List<ProductCategoryRelation> relations);
        void DeleteBulkRelations(List<ProductCategoryRelation> relationsToDelete);
    }
}