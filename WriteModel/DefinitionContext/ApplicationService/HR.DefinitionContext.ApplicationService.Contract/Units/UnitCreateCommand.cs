using Framework.Core.ApplicationService;

namespace HR.DefinitionContext.ApplicationService.Contract.Units
{
    public class UnitCreateCommand: Command
    {
        public string Title { get; set; }
        
    }
}