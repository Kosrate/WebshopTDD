namespace WebshopTDD.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<int>? Subcategories { get; set; }

        public Category()
        {
            Subcategories = new List<int>();
        }
    }
}