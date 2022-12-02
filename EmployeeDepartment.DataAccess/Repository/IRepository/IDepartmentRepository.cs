using EmployeeDepartmentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppProjectTrail2;

namespace EmployeeDepartmentProject.DataAccess.Repository.IRepository
{
    public interface IDepartmentRepository :IRepository<Department>
    {
        void Update(Department obj);
    }
}
