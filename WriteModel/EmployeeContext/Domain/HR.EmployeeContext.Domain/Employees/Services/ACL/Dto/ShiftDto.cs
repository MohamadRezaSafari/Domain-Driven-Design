using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Employees.Services.ACL.Dto
{
    public class ShiftDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<ShiftSegmentDto> ShiftSegments { get; set; } = new HashSet<ShiftSegmentDto>();
    }
}
