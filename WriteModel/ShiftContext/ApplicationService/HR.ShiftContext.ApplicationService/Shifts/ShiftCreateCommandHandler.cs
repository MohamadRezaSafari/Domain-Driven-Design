using Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contract.Shifts;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;
using HR.ShiftContext.Domain.ShiftTemplates.Services;

namespace HR.ShiftContext.ApplicationService.Shifts
{
    public class ShiftCreateCommandHandler : ICommandHandler<ShiftCreateCommand>
    {
        private readonly IShiftRepository shiftRepository;
        private readonly IShiftTemplateExists shiftTemplateExists;

        public ShiftCreateCommandHandler(IShiftRepository shiftRepository, IShiftTemplateExists shiftTemplateExists)
        {
            this.shiftRepository = shiftRepository;
            this.shiftTemplateExists = shiftTemplateExists;
        }

        public void Execute(ShiftCreateCommand command)
        {
            var shift = new Shift(command.Title, command.ShiftTemplateId, command.StartTime, command.EndTime, null, shiftTemplateExists);

            shiftRepository.ShiftCreate(shift);
        }
    }
}
