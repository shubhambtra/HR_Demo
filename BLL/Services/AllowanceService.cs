using BLL.Services.Interfaces;
using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class AllowanceService : Service<Allowance>, IAllowanceService
    {
        private readonly IAllowanceRepository _allowanceRepository;

        public AllowanceService(IAllowanceRepository allowanceRepository) : base(allowanceRepository)
        {
            _allowanceRepository = allowanceRepository;
        }

    }
}
