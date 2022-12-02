using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeDepartmentProject.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(20)]
        [Required]
        
        [Display(Name = "EmployeeName")]
        public string? EmployeeName { get; set; }
        [Display(Name ="EmployeeSalary")]
        [Required]
        public float EmployeeSalary { get; set; }

        [Display(Name ="DepartmentId")]
        public virtual int DepartID { get; set; }

        [ForeignKey("DepartID")]
        public virtual Department? Departments { get; set; }
    }
}
