using System;
using Framework.Domain;
using HR.EmployeeContext.Domain.Employees.Exceptions.ShiftAssignment;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Employees
{
   public class ShiftAssignment : EntityBase
    {
        protected ShiftAssignment()
        {            
        }

        public ShiftAssignment(IEmployeeRepository employeeRepository, long employeeId, DateTime startDate,DateTime? endDate,Guid? shiftSegmentId)
        {
            SetStartDate(employeeRepository,employeeId, startDate);
            SetEndDate(endDate);
            SetShiftSegmentId(shiftSegmentId);
        }
        
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; set; }
        public Guid? ShiftSegmentId { get; private set; }


        private void SetStartDate(IEmployeeRepository employeeRepository,long employeeId,DateTime startTime)
        {
            var lastShiftAssiged=employeeRepository.GetLastShiftAssignmentByEmployeeId(employeeId);
            if (lastShiftAssiged!=null && lastShiftAssiged.StartDate > startTime)
                throw new StartTimeIsLowException();

            if (startTime == null)
                throw new EmptyStartTimeException();

            StartDate = startTime;
        }


        private void SetEndDate(DateTime? endTime)
        {
            EndDate = (DateTime?)null;
        }


        private void SetShiftSegmentId(Guid? shiftSegmentId)
        {

            if (shiftSegmentId == null)
                throw new EmptyShiftIdException();

            ShiftSegmentId = shiftSegmentId;
        }
    }
}
