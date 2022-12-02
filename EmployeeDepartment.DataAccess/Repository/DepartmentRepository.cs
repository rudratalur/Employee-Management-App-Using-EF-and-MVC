using EmployeeDepartmentProject.DataAccess.Data;
using EmployeeDepartmentProject.DataAccess.Repository.IRepository;
using EmployeeDepartmentProject.Models;
using EmployeeDepartmentProject.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartmentProject.DataAccess.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly EmployeeDepartmentDbContext _db;

        public DepartmentRepository(EmployeeDepartmentDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Department obj)
        {
            _db.Update(obj);
        }
    }
}
