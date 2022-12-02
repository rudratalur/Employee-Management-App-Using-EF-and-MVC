﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartmentProject.Models
{
    public class Department
    {
        [Key]
        public int DepartID { get; set; }
        public string DepartName { get; set; }
    }
}
