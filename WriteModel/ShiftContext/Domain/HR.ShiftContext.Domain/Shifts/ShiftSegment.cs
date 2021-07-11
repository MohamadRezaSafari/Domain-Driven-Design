using Framework.Domain;
using HR.ShiftContext.Domain.Shifts.Exceptions;
using HR.ShiftContext.Domain.Shifts.Services;
using HR.ShiftContext.Domain.ShiftTemplates.Exceptions;
using System;

namespace HR.ShiftContext.Domain.Shifts
{
    public class ShiftSegment : EntityBase
    {
        private readonly IShiftExists shiftExists;

        protected ShiftSegment()
        {
        }

        public ShiftSegment(Guid shiftId, TimeSpan startTime, double attendanceTime, Guid? nextShiftId, IShiftExists shiftExists)
        {
            this.shiftExists = shiftExists;
            SetShiftId(shiftId);
            SetTime(startTime, attendanceTime);
            NextShiftId = nextShiftId;
        }


        private void SetShiftId(Guid shiftId)
        {
            if(shiftId == null)
                throw new ShiftIdRequiredException();

            if (!shiftExists.Exist(shiftId))
                throw new ShiftExistsException();

            ShiftId = shiftId;
        }
             

        private void SetTime(TimeSpan startTime, double attendanceTime)
        {
            if (startTime == null && attendanceTime == null)
                throw new ShiftTimeRequiredException();

            var calculateEndTimeHour = (new DateTime()).Add(startTime).AddHours(attendanceTime).Hour;
            var endTime = new TimeSpan(0, calculateEndTimeHour, 0, 0);
                       
            StartTime = startTime;
            EndTime = endTime;
        }


        public Guid ShiftId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid? NextShiftId { get; set; }
    }
}
