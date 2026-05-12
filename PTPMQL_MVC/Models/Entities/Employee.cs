using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTPMQL_MVC.Models.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "ID không được để trống")]
        public string EmployeeId { get; set;} = default! ;
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên từ 3-100 ký tự")]
        public string FullName { get; set;} = default! ;
        
        [Required(ErrorMessage = "Địa chỉ không được để trống")]

        public string Address { get; set;} = default! ;
        
        [Required(ErrorMessage = "Tuổi không được để trống")]
        [Range(1, 100, ErrorMessage = "Tuổi phải từ 1 đến 100")]
        public int Age {get; set;}
        
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email {get; set;} = default! ; 
           
    }
}