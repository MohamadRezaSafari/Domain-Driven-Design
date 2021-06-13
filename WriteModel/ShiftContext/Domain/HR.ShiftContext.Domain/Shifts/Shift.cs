using Framework.Core.Domain;
using Framework.Domain;
using HR.ShiftContext.Domain.Shifts.Exceptions;
using HR.ShiftContext.Domain.ShiftTemplates.Exceptions;
using HR.ShiftContext.Domain.ShiftTemplates.Services;
using System;

namespace HR.ShiftContext.Domain.Shifts
{
    public class Shift : EntityBase, IAggregateRoot
    {
        private readonly IShiftTemplateExists shiftTemplateExists;

        protected Shift() { }

        public Shift(string title, Guid shiftTemplateId, TimeSpan startTime, TimeSpan endTime, int? nextShift, IShiftTemplateExists shiftTemplateExists)
        {
            this.shiftTemplateExists = shiftTemplateExists;

            SetTitle(title);
            SetShiftTemplateId(shiftTemplateId, shiftTemplateExists);
            SetTime(startTime, endTime);
            NextShift = nextShift;            
        }

        private void SetTime(TimeSpan startTime, TimeSpan endTime)
        {
            if(startTime == null && endTime == null)
                throw new ShiftTimeRequiredException();

            if(startTime > endTime)
                throw new InvalidShiftTimeRangeException();

            StartTime = startTime;
            EndTime = endTime;
        }

        private void SetShiftTemplateId(Guid shiftTemplateId, IShiftTemplateExists shiftTemplateExists)
        {
            if(shiftTemplateId == null)
                throw new ShiftTemplateIdRequiredException();

            if(!shiftTemplateExists.Exist(shiftTemplateId))
                throw new ShiftTemplateExistsException();

            ShiftTemplateId = shiftTemplateId;
        }

        private void SetTitle(string title)
        {
            if(String.IsNullOrWhiteSpace(title))
                throw new ShiftTitleRequiredException();

            Title = title;
        }

        public long ShiftId { get; set; }
        public string Title { get; set; }
        public Guid ShiftTemplateId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public long? NextShift { get; set; }
    }
}
