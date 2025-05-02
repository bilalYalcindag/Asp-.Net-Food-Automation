using System.ComponentModel.DataAnnotations;

namespace CoreFood.Data.Models
{
    public class Admin
    {
        [Key]
        public int adminID { get; set; }

        [StringLength(20)]
        public string userName { get; set; }

        [StringLength(20)]
        public int password { get; set; }
        public string adminRole { get; set; }
    }
}
