using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTPMQL_MVC.Models.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
        [StringLength(100)]
        public string SupplierName { get; set; } = default!;
        public ICollection<ImportReceipt>? ImportReceipts { get; set; }
    }
}