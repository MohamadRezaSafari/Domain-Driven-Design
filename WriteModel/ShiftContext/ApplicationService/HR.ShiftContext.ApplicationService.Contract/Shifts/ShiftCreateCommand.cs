using Framework.Core.ApplicationService;
using System;

namespace HR.ShiftContext.ApplicationService.Contract.Shifts
{
    public class ShiftCreateCommand : Command
    {
        public string Title { get; set; }        
    }
}
