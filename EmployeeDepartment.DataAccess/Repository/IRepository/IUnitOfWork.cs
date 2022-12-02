﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartmentProject.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
