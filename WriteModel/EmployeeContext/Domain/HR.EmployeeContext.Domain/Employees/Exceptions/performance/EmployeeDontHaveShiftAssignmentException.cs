using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.performance
{
    public class EmployeeDontHaveEmployeeContractException : DomainException
    {
        public override string Message => ExceptionResource.EmployeeDontHaveEmployeeContract;
    }
}
