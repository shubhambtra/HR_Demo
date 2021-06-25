using AutoMapper;
using Core.Entitites;
using HR_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_DEMO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
            CreateMap<AllowanceViewModel, Allowance>().ReverseMap();
            CreateMap<EmployeeSalaryViewModel, EmployeeSalary>().ReverseMap();

        }
    }
}
