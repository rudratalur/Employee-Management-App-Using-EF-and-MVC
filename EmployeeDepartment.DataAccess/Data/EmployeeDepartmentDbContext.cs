using EmployeeDepartmentProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartmentProject.DataAccess.Data
{
    public class EmployeeDepartmentDbContext : DbContext
    {
        public EmployeeDepartmentDbContext(DbContextOptions<EmployeeDepartmentDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


    }
}
