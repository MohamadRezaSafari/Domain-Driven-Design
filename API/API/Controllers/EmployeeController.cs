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
      
        private readonly IEmployeeCommandFacade employeeCommandFacade;
        private readonly IEmployeeQueryFacade employeeQueryFacade;

        public EmployeeController( IEmployeeCommandFacade employeeCommandFacade, IEmployeeQueryFacade employeeQueryFacade)
        {
            this.employeeCommandFacade = employeeCommandFacade;
            this.employeeQueryFacade = employeeQueryFacade;
        }


        [HttpGet]
        [Route("GetEmployeeIos")]
        public void GetEmployeeIos()
        {
            employeeQueryFacade.GetEmployeeIos();
        }



        [HttpPost]
        [Route("EmployeeReHire")]
        public void EmployeeReHire(EmployeeReHireCommand command)
        {
            employeeCommandFacade.EmployeeReHire(command);
        }


        [HttpDelete]
        [Route("EmployeeSettlement")]
        public void EmployeeSettlement(EmployeeSettlementCommand command)
        {
            employeeCommandFacade.EmployeeSettlement(command);
        }
        


        [HttpPost]
        [Route("EmployeeIoCreate")]
        public void EmployeeIoCreate([FromBody] EmployeeIOCreateCommand command)
        {
            employeeCommandFacade.CreateEmployeeIO(command);
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

        [HttpPost]
        [Route("EmployeeContract")]
        public void CreateEmployeeContract(EmployeeContractCreateCommand command)
        {
            employeeCommandFacade.ConcludeEmployeeContract(command);
        }
    }
}
