using HR.ShiftContext.ApplicationService.Contract.Shifts;

namespace HR.ShiftContext.Facade.Contract
{
    public interface IShiftCommandFacade
    {
        void ShiftSegmentCreate(ShiftSegmentCreateCommand command);
        void ShiftCreate(ShiftCreateCommand command);
        void ShiftSegmentInOrder(ShiftSegmentInOrderCommand command);
    }
}
