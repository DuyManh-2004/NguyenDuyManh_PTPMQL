using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTPMQL_MVC.Models.Entities

{
public class Device
    {
        [Key]
        public int DeviceID { get; set; }

        [Required]
        public string DeviceName { get; set; } = default!;


        public int Quantity { get; set; } = 0;

        [ForeignKey("DeviceCategory")]
        public int CategoryID { get; set; }

        public DeviceCategory? DeviceCategory { get; set; }

        public ICollection<ImportDetail>? ImportDetails { get; set; }
        public ICollection<ExportDetail>? ExportDetails { get; set; }
    }
}