using Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contract.Shifts;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.ApplicationService.Shifts
{
    public class ShiftSegmentCreateCommandHandler : ICommandHandler<ShiftSegmentCreateCommand>
    {
        private readonly IShiftRepository shiftRepository;
        private readonly IShiftExists shiftExists;

        public ShiftSegmentCreateCommandHandler(IShiftRepository shiftRepository, IShiftExists shiftExists)
        {
            this.shiftRepository = shiftRepository;
            this.shiftExists = shiftExists;
        }

        public void Execute(ShiftSegmentCreateCommand command)
        {
            var shift = shiftRepository.GetShiftById(command.ShiftId);
            var shiftSegment = new ShiftSegment(shift.Id, command.StartTime, command.AttendanceTime, null, shiftExists);
            shift.AddShiftSegment(shiftSegment);
        }
    }
}
