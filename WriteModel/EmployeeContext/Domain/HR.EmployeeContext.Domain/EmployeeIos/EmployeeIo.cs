﻿using Framework.Domain;
using HR.EmployeeContext.Domain.EmployeeIos.Exceptions;
using System;
using Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.EmployeeIos
{
    public class EmployeeIo : EntityBase, IAggregateRoot
    {
        protected EmployeeIo()
        {
        }

        public EmployeeIo(Guid employeeId,DateTime dateTime)
        {
            SetEmployeeId(employeeId);
            SetDateTime(dateTime);
        }

        private void SetEmployeeId(Guid employeeId)
        {
            if(employeeId == null)
                throw new EmployeeIdRequiredException();
            EmployeeId = employeeId;
        }

        private void SetDateTime(DateTime dateTime)
        {
            if (dateTime == null)
                throw new DateTimeRequiredException();

            DateTime = dateTime;
        }

        public Guid EmployeeId { get; private set; }
        public DateTime DateTime { get; private set; }
    }
}
