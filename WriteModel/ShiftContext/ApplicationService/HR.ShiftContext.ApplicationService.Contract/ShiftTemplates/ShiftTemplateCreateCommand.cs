using Framework.Core.ApplicationService;

namespace HR.ShiftContext.ApplicationService.Contract.ShiftTemplates
{
    public class ShiftTemplateCreateCommand : Command
    {
        public string Title { get; set; }
    }
}
