﻿using Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contract.Shifts;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.ApplicationService.Shifts
{
    public class ShiftCreateCommandHandler : ICommandHandler<ShiftCreateCommand>
    {
        private readonly IShiftRepository shiftRepository;

        public ShiftCreateCommandHandler(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }

        public void Execute(ShiftCreateCommand command)
        {
            var shift = new Shift(command.Title);
            shiftRepository.ShiftCreate(shift);           
        }
    }
}
