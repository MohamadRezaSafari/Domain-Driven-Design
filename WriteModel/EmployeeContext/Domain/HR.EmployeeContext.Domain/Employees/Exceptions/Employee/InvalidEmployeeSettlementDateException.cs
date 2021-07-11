using Framework.Domain;
using HR.EmployeeContext.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.Employee
{
    public class InvalidEmployeeSettlementDateException : DomainException
    {
        public override string Message => ExceptionResource.InvalidEmployeeSettlementDateException;
    }
}
