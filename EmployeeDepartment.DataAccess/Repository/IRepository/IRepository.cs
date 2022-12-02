using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAppProjectTrail2;

namespace EmployeeDepartmentProject.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void Add(Controllers.DepartmentController deptObj);
    }
}
