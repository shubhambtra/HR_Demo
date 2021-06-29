using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services.Interfaces;
using Core.Entitites;
using HR_DEMO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HR_DEMO.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IAllowanceService _allowanceService;
        private readonly IEmployeeService _employeeService;
        public string Message { get; set; }
        [BindProperty]
        public EmployeeViewModel EmployeeDetail { get; set; }

       // [BindProperty]
        //public EmployeeViewModel EmployeeViewModel { get; set; }
        public OrderModel(IMapper mapper, IAllowanceService allowanceService, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _allowanceService = allowanceService;
            _employeeService = employeeService;
        }
        public async void OnGet()
        {
            EmployeeDetail = new EmployeeViewModel();
            //var data= await _allowanceService.GetAll();
            EmployeeDetail.Allowance = (await GetSalaryList()).ToList();
            Message = "Hello";

        }

        private async Task<IEnumerable<AllowanceViewModel>> GetSalaryList()
        {


            return _mapper.Map<IEnumerable<Allowance>, IEnumerable<AllowanceViewModel>>(await _allowanceService.GetAll());
        }

        public async Task<IActionResult> OnPost()
        {
            var model = EmployeeDetail;
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                model.EmployeeSalary = model.EmployeeSalary.Where(x => x.ALLOWANCE_AMT != 0).ToList();
                var entity = _mapper.Map<EmployeeViewModel, Employee>(model);
                await _employeeService.Create(entity);
                return RedirectToPage("Order");
            }
            catch (Exception ex)
            {
                //return View("Index");
            }
            return null;
        }
    }
}
