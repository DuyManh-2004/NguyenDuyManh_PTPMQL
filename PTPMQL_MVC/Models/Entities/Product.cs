using System.ComponentModel.DataAnnotations;

namespace PTPMQL_MVC.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; } = default!;
    }
}