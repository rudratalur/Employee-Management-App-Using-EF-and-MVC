using EmployeeDepartmentProject.DataAccess.Data;
using EmployeeDepartmentProject.DataAccess.Repository.IRepository;
using EmployeeDepartmentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartmentProject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeDepartmentDbContext _db;
        public UnitOfWork(EmployeeDepartmentDbContext db)
        {
            _db = db;
            Department = new DepartmentRepository(_db);
            Employee = new EmployeeRepository(_db);
            
        }   
        public IDepartmentRepository Department { get; private set; }
        public IEmployeeRepository Employee { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
