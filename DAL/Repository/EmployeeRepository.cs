using BLL.Services.Interfaces;
using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly HrDemoDbContext _dbContext;
        

    
        public EmployeeRepository(HrDemoDbContext context) :
            base(context)
        {
            _dbContext = context;
         
        }

    }
}
