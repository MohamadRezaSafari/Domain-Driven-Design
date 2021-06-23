using HR.ShiftContext.ApplicationService.Contract.Shifts;
using HR.ShiftContext.ApplicationService.Contract.ShiftTemplates;

namespace HR.ShiftContext.Facade.Contract
{
    public interface IShiftCommandFacade
    {
        void ShiftCreate(ShiftCreateCommand command);
        void ShiftTemplateCreate(ShiftTemplateCreateCommand command);
        void ShiftSetNextShiftId(InOrderShiftCommand command);
    }
}
