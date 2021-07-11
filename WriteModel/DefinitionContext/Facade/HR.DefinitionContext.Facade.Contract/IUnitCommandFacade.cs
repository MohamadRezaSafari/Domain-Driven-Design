using HR.DefinitionContext.ApplicationService.Contract.Units;

namespace HR.DefinitionContext.Facade.Contract
{
    public interface IUnitCommandFacade
    {
        void CreateUnit(UnitCreateCommand command);
    }
}