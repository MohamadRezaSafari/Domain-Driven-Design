using Framework.Core.ApplicationService;
using System;

namespace HR.ShiftContext.ApplicationService.Contract.Shifts
{
    public class ShiftCreateCommand : Command
    {
        public string ShiftTamplteTitle { get; set; }
        public string Title { get; set; }
        //public Guid ShiftTemplateId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
