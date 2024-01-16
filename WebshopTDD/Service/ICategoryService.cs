using WebshopTDD.Models;

namespace WebshopTDD.Service
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void UpdateCategory(Category updatedCategory);
        void DeleteCategory(int categoryId);
        List<Category> GetAllCategories();
        void SaveCategories(List<Category> categories);
        Category GetCategoryById(int categoryId);
        Category GetCategoryById(List<Category> categories, int categoryId);
    }
}