using System.ComponentModel.DataAnnotations;
namespace PTPMQL_MVC.Models.Entities
{

public class ImportDetail
{
    [Key]
    public int ImportDetailID { get; set; }

    public int ImportReceiptID { get; set; }
    public ImportReceipt? ImportReceipt { get; set; }

    public int DeviceID { get; set; }
    public Device? Device { get; set; }

    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalMoney { get; set; }
}
}