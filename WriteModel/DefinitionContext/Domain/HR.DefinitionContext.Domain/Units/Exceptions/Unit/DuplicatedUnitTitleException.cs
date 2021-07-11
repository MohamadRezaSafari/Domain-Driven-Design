using Framework.Domain;
using HR.DefinitionContext.Resources;

namespace HR.DefinitionContext.Domain.Units.Exceptions.Unit
{
    public class DuplicatedUnitTitleException : DomainException
    {
        public override string Message => ExceptionResource.DuplicatedUnitTitleException;
    }
}
