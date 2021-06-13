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
            var shiftTemplate = new ShiftTemplate(command.Title);

            shiftRepository.ShiftTermplateCreate(shiftTemplate);
        }
    }
}
