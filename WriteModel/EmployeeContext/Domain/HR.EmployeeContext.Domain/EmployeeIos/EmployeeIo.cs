using Framework.Domain;
using HR.EmployeeContext.Domain.EmployeeIos.Exceptions;
using System;

namespace HR.EmployeeContext.Domain.EmployeeIos
{
    public class EmployeeIo : EntityBase
    {
        protected EmployeeIo()
        {
        }

        public EmployeeIo(long employeeId, DateTime dateTime)
        {
            SetEmployeeId(employeeId);
            SetDateTime(dateTime);
        }

        private void SetEmployeeId(long employeeId)
        {
            if(employeeId == null)
                throw new EmployeeIdRequiredException();
        }

        private void SetDateTime(DateTime dateTime)
        {
            if(dateTime == null)
                throw new DateTimeRequiredException();

            // TODO :: Shift Check

            DateTime = dateTime;
        }

        public long EmployeeId { get; private set; }
        public DateTime DateTime { get; private set; }
    }
}
