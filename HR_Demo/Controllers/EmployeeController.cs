using AutoMapper;
using BLL.Services.Interfaces;
using Core.Entitites;
using HR_DEMO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HR_DEMO.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAllowanceService _allowanceService;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IMapper mapper, IAllowanceService allowanceService, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _allowanceService = allowanceService;
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {

            var model = new EmployeeViewModel();
           //var data= await _allowanceService.GetAll();
            model.Allowance = (await GetSalaryList()).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Save(EmployeeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
            

                model.EmployeeSalary = model.EmployeeSalary.Where(x => x.ALLOWANCE_AMT != 0).ToList();
                var entity = _mapper.Map<EmployeeViewModel, Employee>(model);
                await _employeeService.Create( entity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }
        private async Task<IEnumerable<AllowanceViewModel>> GetSalaryList()
        {


            return _mapper.Map<IEnumerable<Allowance>, IEnumerable<AllowanceViewModel>>(await _allowanceService.GetAll());
        }
    }
}
