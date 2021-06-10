using Microsoft.AspNetCore.Mvc;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Facade.Contract;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IEmployeeCommandFacade _employeeCommandFacade;

        public HomeController(IEmployeeCommandFacade employeeCommandFacade)
        {
            _employeeCommandFacade = employeeCommandFacade;
        }
        
        [HttpPost]
        [Route("EmployeeCreate")]
        public void EmployeeCreate(EmployeeCreateCommand command)
        {
            _employeeCommandFacade.CreateEmployee(command);
        }
    }
}
