using System;
using Framework.Domain;
using HR.EmployeeContext.Domain.Employees.Exceptions.ShiftAssignment;

namespace HR.EmployeeContext.Domain.Employees
{
   public class ShiftAssignment : EntityBase
    {
        protected ShiftAssignment()
        {
            
        }
        public ShiftAssignment(long employeeId, DateTime startTime,DateTime? endTime,Guid shiftId)
        {
            SetStartTime(startTime);
            SetEndTime(endTime);
            SetShiftId(shiftId);
            //EmployeeId = employeeId;
        }

        //public long EmployeeId { get; set; }
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public Guid ShiftId { get; private set; }

        private void SetStartTime(DateTime startTime)
        {
            if (startTime == null)
            {
                throw new EmptyStartTimeException();
            }

            StartTime = startTime;
        }

        private void SetEndTime(DateTime? endTime)
        {

            EndTime = endTime ?? default;
        }
        private void SetShiftId(Guid shiftId)
        {
            if (shiftId == null)
            {
                throw new EmptyShiftIdException();
            }
            ShiftId= shiftId;
        }

    }
}
