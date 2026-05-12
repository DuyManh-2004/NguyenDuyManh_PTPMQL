using System.ComponentModel.DataAnnotations;
namespace PTPMQL_MVC.Models.Entities
{
    public class ExportReceipt
{
    [Key]
    public int ExportReceiptID { get; set; }

    public DateTime ExportDate { get; set; }

    public ICollection<ExportDetail>? ExportDetails { get; set; }
}
}