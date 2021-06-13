using HR.ShiftContext.Domain.Shifts.Services;
using HR.ShiftContext.Domain.ShiftTemplates.Services;
using System;
using System.Linq;

namespace HR.ShiftContext.Domain.Services.ShiftTemplates
{
    class ShiftTemplateExists : IShiftTemplateExists
    {
        private readonly IShiftRepository shiftRepository;


        public ShiftTemplateExists(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }

        public bool Exist(Guid shiftTemplateId)
        {
            return shiftRepository.ShiftTemplateExist(shiftTemplateId).Count() > 0;
        }
    }
}
