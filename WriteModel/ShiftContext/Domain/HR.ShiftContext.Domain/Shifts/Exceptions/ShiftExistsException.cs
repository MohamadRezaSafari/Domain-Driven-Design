using Framework.Domain;
using HR.ShiftContext.Resources;

namespace HR.ShiftContext.Domain.ShiftTemplates.Exceptions
{
    public class ShiftExistsException : DomainException
    {
        public override string Message => ExceptionResource.ShiftExistsException;
    }
}
