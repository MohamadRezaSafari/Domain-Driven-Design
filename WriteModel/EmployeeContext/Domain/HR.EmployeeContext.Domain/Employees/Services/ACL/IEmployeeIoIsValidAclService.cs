using System;
using Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.Employees.Services.ACL
{
    
    public interface IEmployeeIoIsValidAclService:IACLService
    {
        bool IsValid(long employeeId,DateTime dateTime);
    }
}
