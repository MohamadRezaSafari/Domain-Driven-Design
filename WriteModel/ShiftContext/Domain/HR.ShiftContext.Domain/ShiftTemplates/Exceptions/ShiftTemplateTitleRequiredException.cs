using Framework.Domain;
using HR.ShiftContext.Resources;

namespace HR.ShiftContext.Domain.ShiftTemplates.Exceptions
{
    public class ShiftTemplateTitleRequiredException : DomainException
    {
        public override string Message => ExceptionResource.ShiftTemplateTitleRequiredException;
    }
}
