
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace PTPMQL_MVC.Models.Entities
{
public class Student
{
        [Key]
        public string StudentCode { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public int? Age { get; set; }
}
}