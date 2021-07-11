using System;
using Framework.Core.Domain;

namespace HR.EmployeeContext.Facade.Contract
{
    public interface IEmployeeIoDateTimeValidateAclService:IACLService
    {
        bool IsValidDateTime(long employeeId,DateTime dateTime);
    }
}
