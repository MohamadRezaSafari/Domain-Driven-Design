using Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contract.ShiftTemplates;
using HR.ShiftContext.Domain.Shifts.Services;
using HR.ShiftContext.Domain.ShiftTemplates;

namespace HR.ShiftContext.ApplicationService.ShiftTemplates
{
    public class ShiftTemplateCreateCommandHandler : ICommandHandler<ShiftTemplateCreateCommand>
    {
        private readonly IShiftRepository shiftRepository;

        public ShiftTemplateCreateCommandHandler(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }

        public void Execute(ShiftTemplateCreateCommand command)
        {
            //var shift = new Shift()
            //var shifts = shiftRepository.GetShifts(command.ShiftIds);
            var shiftTemplate = new ShiftTemplate(command.Title);

            //foreach (var shift in shifts)
            //{
            //    shift.ShiftTemplates = shiftTemplate;
            //    shiftAdd(shiftTemplate);
            //}

            

            shiftRepository.ShiftTermplateCreate(shiftTemplate);
        }
    }
}
