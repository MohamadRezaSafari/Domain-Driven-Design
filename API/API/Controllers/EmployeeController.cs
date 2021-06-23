using HR.EmployeeContext.ApplicationService.Contract.EmployeeIos;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Facade.Contract;
using HR.ReadModel.Context.Models;
using HR.ReadModel.Queries.Contracts.Employees;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeIOCommandFacade employeeIoCommandFacade;
        private readonly IEmployeeCommandFacade employeeCommandFacade;
        private readonly IEmployeeQueryFacade employeeQueryFacade;

        public EmployeeController(IEmployeeIOCommandFacade employeeIoCommandFacade, IEmployeeCommandFacade employeeCommandFacade, IEmployeeQueryFacade employeeQueryFacade)
        {
            this.employeeIoCommandFacade = employeeIoCommandFacade;
            this.employeeCommandFacade = employeeCommandFacade;
            this.employeeQueryFacade = employeeQueryFacade;
        }

        [HttpPost]
        [Route("EmployeeIoCreate")]
        public void EmployeeIoCreate([FromBody] EmployeeIOCreateCommand command)
        {
            employeeIoCommandFacade.CreateEmployeeIO(command);
        }



        [HttpGet]
        [Route("GetAllEmployees")]
        public List<Employee> GetAllEmployees()
        {
            return employeeQueryFacade.GetAllEmployees();
        }


        [HttpPost]
        [Route("EmployeeCreate")]
        public void EmployeeCreate(EmployeeCreateCommand command)
        {
            employeeCommandFacade.CreateEmployee(command);
        }

        [HttpDelete]
        [Route("EmployeeDelete")]
        public void EmployeeDelete(EmployeeDeleteCommand command)
        {
            employeeCommandFacade.DeleteEmployee(command);
        }

        [HttpPut]
        [Route("EmployeeUpdate")]
        public void EmployeeUpdate(EmployeeUpdateCommand command)
        {
            employeeCommandFacade.UpdateEmployee(command);
        }

        [HttpPost]
        [Route("AssignShift")]
        public void AssignShift(ShiftAssignmentCommend command)
        {
            employeeCommandFacade.AssignShift(command);
        }
    }
}
