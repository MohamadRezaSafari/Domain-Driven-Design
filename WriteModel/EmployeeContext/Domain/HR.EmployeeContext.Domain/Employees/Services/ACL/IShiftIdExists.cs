using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.Employees.Services.ACL
{
    public interface IShiftIdExists : IACLService
    {
        bool IsExistShiftId(Guid shiftId);
    }
}
