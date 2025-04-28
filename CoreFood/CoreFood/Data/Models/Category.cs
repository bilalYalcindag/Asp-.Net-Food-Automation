using System.ComponentModel.DataAnnotations;

namespace CoreFood.Data.Models
{
    public class Category
    {
        public int categoryID { get; set; }
        [Required(ErrorMessage ="Category Name is Not Empty")]
        [StringLength(20,ErrorMessage ="should only 4-20 characters enter please",MinimumLength =4)]
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
        public bool status { get; set; }
        public List<Food> foods { get; set; }

    }
}
