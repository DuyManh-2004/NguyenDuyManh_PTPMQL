using System.ComponentModel.DataAnnotations;
namespace PTPMQL_MVC.Models.Entities
{
    public class ImportReceipt
{
    [Key]
    public int ImportReceiptID { get; set; }

    public DateTime ImportDate { get; set; }

    public int SupplierID { get; set; }
    public Supplier? Supplier { get; set; }

    public ICollection<ImportDetail>? ImportDetails { get; set; }
}
}
