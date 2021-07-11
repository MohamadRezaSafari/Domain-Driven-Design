using HR.EmployeeContext.Facade.Contract;
using HR.ShiftContext.ApplicationService.Contract.Shifts;
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
        [Route("ShiftSegmentCreate")]
        public void ShiftSegmentCreate(ShiftSegmentCreateCommand command)
        {
            shiftCommandFacade.ShiftSegmentCreate(command);
        }

        [HttpPost]
        [Route("ShiftCreate")]
        public void ShiftCreate(ShiftCreateCommand command)
        {
            shiftCommandFacade.ShiftCreate(command);
        }


        [HttpPost]
        [Route("ShiftSegmentInOrder")]
        public void ShiftSegmentInOrder(ShiftSegmentInOrderCommand command)
        {
            shiftCommandFacade.ShiftSegmentInOrder(command);
        }



    }
}
