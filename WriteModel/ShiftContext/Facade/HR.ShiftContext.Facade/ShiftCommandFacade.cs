using Framework.ApplicationService;
using Framework.Core.ApplicationService;
using Framework.Facade;
using HR.ShiftContext.ApplicationService.Contract.Shifts;
using HR.ShiftContext.Facade.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.ShiftContext.Facade
{
    public class ShiftCommandFacade : FacadeCommandBase, IShiftCommandFacade
    {
        public ShiftCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void ShiftSegmentCreate(ShiftSegmentCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void ShiftCreate(ShiftCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }


        public void ShiftSegmentInOrder(ShiftSegmentInOrderCommand command)
        {
            CommandBus.Dispatch(command);
        }

        
    }
}
