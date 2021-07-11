using Framework.Core.ApplicationService;
using HR.DefinitionContext.ApplicationService.Contract.Units;
using HR.DefinitionContext.Domain.Units;
using HR.DefinitionContext.Domain.Units.Services;

namespace HR.DefinitionContext.ApplicationService.Units
{
    public class UnitCreateCommandHandler: ICommandHandler<UnitCreateCommand>
    {
        private readonly IUnitTitleDuplicationChecker _titleDuplicationChecker;
        private readonly IUnitRepository _unitRepository;

        public UnitCreateCommandHandler(IUnitTitleDuplicationChecker titleDuplicationChecker, IUnitRepository unitRepository)
        {
            _titleDuplicationChecker = titleDuplicationChecker;
            _unitRepository = unitRepository;
        }
        public void Execute(UnitCreateCommand command)
        {
            var unit = new Unit(_titleDuplicationChecker, command.Title);
            _unitRepository.Create(unit);
        }
    }
}