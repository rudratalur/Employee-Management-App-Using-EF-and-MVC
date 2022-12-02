using EmployeeDepartmentProject.DataAccess.Data;
using EmployeeDepartmentProject.DataAccess.Repository.IRepository;
using EmployeeDepartmentProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartmentProject.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>,IEmployeeRepository
    {
        private readonly EmployeeDepartmentDbContext _db;

        public EmployeeRepository(EmployeeDepartmentDbContext db) : base(db)
        {
            _db = db;   
        }

        public void Update(Employee obj)
        {
            _db.Update(obj);
        }
    }
}
