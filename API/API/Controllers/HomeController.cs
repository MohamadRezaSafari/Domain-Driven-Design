using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.EmployeeContext.Facade.Contract;
using HR.ReadModel.Context.Models;
using HR.ReadModel.Queries.Contracts.Employees;
using HR.ShiftContext.ApplicationService.Contract.ShiftTemplates;
using HR.ShiftContext.Facade.Contract;
using HR.ShiftContext.ApplicationService.Contract.Shifts;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IEmployeeCommandFacade _employeeCommandFacade;
        private readonly IEmployeeQueryFacade _employeeQueryFacade;

        private readonly IShiftCommandFacade shiftCommandFacade;
        private readonly IEmployeeIsExists _employeeIsExists;


        public HomeController(IEmployeeCommandFacade employeeCommandFacade,
 IEmployeeQueryFacade employeeQueryFacade, IShiftCommandFacade shiftCommandFacade, IEmployeeIsExists employeeIsExists)
        {
            _employeeCommandFacade = employeeCommandFacade;
            _employeeQueryFacade = employeeQueryFacade;
            this.shiftCommandFacade = shiftCommandFacade;
            _employeeIsExists = employeeIsExists;
        }



        [HttpPost]
        [Route("ShiftCreate")]
        public void ShiftCreate(ShiftCreateCommand command)
        {
            shiftCommandFacade.ShiftCreate(command);
        }

        [HttpPost]
        [Route("ShiftTeamplteCreate")]
        public void ShiftTeamplteCreate(ShiftTemplateCreateCommand command)
        {
            shiftCommandFacade.ShiftTemplateCreate(command);
        }


        [HttpGet]
        [Route("GetAllEmployees")]
        public List<Employee> GetAllEmployees()
        {
            var data = _employeeQueryFacade.GetAllEmployees();

            return data;
        }


        [HttpPost]
        [Route("EmployeeCreate")]
        public void EmployeeCreate(EmployeeCreateCommand command)
        {
            _employeeCommandFacade.CreateEmployee(command);
        }

        [HttpPost]
        [Route("EmployeeDelete")]
        public void EmployeeDelete(EmployeeDeleteCommand command)
        {
            _employeeCommandFacade.DeleteEmployee(command);
        }

        [HttpPut]
        [Route("EmployeeUpdate")]
        public void EmployeeUpdate(EmployeeUpdateCommand command)
        {
            _employeeCommandFacade.UpdateEmployee(command);
        }
    }
}
