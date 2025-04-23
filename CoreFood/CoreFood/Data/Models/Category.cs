namespace CoreFood.Data.Models
{
    public class Category
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }

        public List<Food> foods { get; set; }

    }
}
