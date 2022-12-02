﻿using EmployeeDepartmentProject.DataAccess.Data;
using EmployeeDepartmentProject.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAppProjectTrail2;

namespace EmployeeDepartmentProject.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeDepartmentDbContext _db;
        internal DbSet<T> dbSet;
        

        public Repository(EmployeeDepartmentDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        //public void Add(T entity)
        //{
        //    _db.Add(entity);
        //}

        public void Add(T entity)
        {
            _db.Add(entity);
        }

        public void Add(Controllers.DepartmentController deptObj)
        {
            throw new NotImplementedException();
        }

        virtual public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
