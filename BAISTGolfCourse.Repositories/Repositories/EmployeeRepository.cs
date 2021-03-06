﻿using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.Repositories.BaseRepository;
using BAISTGolfCourse.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Repositories.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context)
        {
        }
        
    }
}
