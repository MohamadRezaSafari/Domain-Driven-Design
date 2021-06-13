using Framework.Domain;
using HR.ShiftContext.Resources;

namespace HR.ShiftContext.Domain.ShiftTemplates.Exceptions
{
    public class ShiftTemplateIdRequiredException : DomainException
    {
        public override string Message => ExceptionResource.ShiftTemplateIdRequiredException;
    }
}
