using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTPMQL_MVC.Models.Entities
{
public class DeviceCategory
    {
    [Key]
    public int CategoryID { get; set; }

    [Required]
    public string CategoryName { get; set; } = default!;
    public ICollection<Device>? Devices { get; set; }
    }
}