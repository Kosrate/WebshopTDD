namespace WebshopTDD.Models
{
    public class ProductCategoryRelation
    {
        public List<int> ProductIds { get; set; }
        public List<int> CategoryIds { get; set; }

        public ProductCategoryRelation()
        {
            ProductIds = new List<int>();
            CategoryIds = new List<int> { 101 };
        }
    }
}