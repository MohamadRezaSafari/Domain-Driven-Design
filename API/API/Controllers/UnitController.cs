using HR.DefinitionContext.ApplicationService.Contract.Units;
using HR.DefinitionContext.Facade.Contract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitCommandFacade _unitCommandFacade;

        public UnitController(IUnitCommandFacade unitCommandFacade)
        {
            _unitCommandFacade = unitCommandFacade;
        }

        [HttpPost]
        [Route("UnitCreate")]
        public void UnitCreate(UnitCreateCommand command)
        {
            _unitCommandFacade.CreateUnit(command);
        }
    }
}