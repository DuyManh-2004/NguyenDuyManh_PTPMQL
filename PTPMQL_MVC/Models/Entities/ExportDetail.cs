using System.ComponentModel.DataAnnotations;
namespace PTPMQL_MVC.Models.Entities
{
    public class ExportDetail
{
    [Key]
    public int ExportDetailID { get; set; }

    public int ExportReceiptID { get; set; }
    public ExportReceipt? ExportReceipt { get; set; }

    public int DeviceID { get; set; }
    public Device? Device { get; set; }

    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalMoney { get; set; }
}
}