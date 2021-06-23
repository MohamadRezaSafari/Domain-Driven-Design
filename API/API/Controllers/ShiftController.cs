using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Facade.Contract;
using HR.ShiftContext.ApplicationService.Contract.Shifts;
using HR.ShiftContext.ApplicationService.Contract.ShiftTemplates;
using HR.ShiftContext.Facade.Contract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftCommandFacade shiftCommandFacade;
        private readonly IEmployeeCommandFacade employeeCommandFacade;


        public ShiftController(IShiftCommandFacade shiftCommandFacade, IEmployeeCommandFacade employeeCommandFacade)
        {
            this.shiftCommandFacade = shiftCommandFacade;
            this.employeeCommandFacade = employeeCommandFacade;
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

        [HttpPost]
        [Route("ShiftSetNextShift")]
        public void ShiftSetNextShift(InOrderShiftCommand command)
        {
            shiftCommandFacade.ShiftSetNextShiftId(command);
        }
        

        
    }
}
