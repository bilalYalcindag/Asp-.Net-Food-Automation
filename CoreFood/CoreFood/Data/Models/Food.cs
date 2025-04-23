namespace CoreFood.Data.Models
{
    public class Food
    {
        public int foodID { get; set; }
        public string name { get; set; }
        public string description { get; set;}
        public  double price { get; set;}
        public string  imageURL { get; set;}
        public int stock { get; set;}
        public int categoryID { get; set;}
        public virtual Category Category { get; set; }


    }
}
