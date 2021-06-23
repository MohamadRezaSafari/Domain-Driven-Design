using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;

namespace HR.ShiftContext.ApplicationService.Contract.ShiftTemplates
{
    public class ShiftTemplateCreateCommand : Command
    {
        //public List<Shift> ShiftIds { get; set; }
        public List<Guid> ShiftIds { get; set; }
        public long ShiftTamplteId { get; set; }
        public string Title { get; set; }
    }
}
