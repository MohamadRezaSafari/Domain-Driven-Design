using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Domain;
using HR.EmployeeContext.Domain.Employees.Exceptions.performance;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Employees
{
    public class Performance : EntityBase
    {
        public Performance()
        {

        }
        public Performance(
            DateTime fromDate,
            DateTime toDate,
            long sum,
            Guid employeeId)
        {
            this.EmployeeId = employeeId;
            SetFromDate(fromDate);
            SetToDate(fromDate, toDate);
            SetSum(sum);
        }


        public Guid EmployeeId { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public long Sum { get; set; }
        public ICollection<PerformanceDetail> Details { set; get; } = new HashSet<PerformanceDetail>();

        private void SetFromDate(DateTime fromDate)
        {
            this.FromDate = fromDate;
        }

        private void SetToDate(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
                throw new FromDateIsLongerException();

            this.ToDate = toDate;
        }

        private void SetSum(long sum)
        {
            this.Sum = sum;
        }
    }
}
