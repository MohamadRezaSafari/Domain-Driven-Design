using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.EmployeeContract
{
    public class EmptyEmployeeContractUnitIdException:DomainException
    {
        public override string Message => ExceptionResource.EmptyEmployeeContractUnitIdException;
    }
}
