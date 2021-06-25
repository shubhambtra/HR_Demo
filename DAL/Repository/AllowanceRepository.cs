using BLL.Services.Interfaces;
using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class AllowanceRepository : Repository<Allowance>, IAllowanceRepository
    {
        private readonly HrDemoDbContext _dbContext;
        

    
        public AllowanceRepository(HrDemoDbContext context) :
            base(context)
        {
            _dbContext = context;
         
        }

    }
}
