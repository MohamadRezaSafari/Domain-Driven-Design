using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Domain;
using HR.EmployeeContext.Domain.Employees.Services.ACL.Dto;

namespace HR.EmployeeContext.Domain.Employees.Services.ACL
{
    public interface IShiftRepositoryACL : IACLService
    {
        List<ShiftSegmentDto> GetShiftSegments(Guid shiftId);
        ShiftDto GetShiftByShiftSegmentId(Guid id);
        List<ShiftSegmentDto> GetShiftByShiftSegmentId(List<Guid> ids);
        List<ShiftDto> GetAllShifts();
    }
}
