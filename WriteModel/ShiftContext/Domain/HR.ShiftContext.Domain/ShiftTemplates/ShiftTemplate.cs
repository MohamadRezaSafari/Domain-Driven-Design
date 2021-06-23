using Framework.Domain;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.ShiftTemplates.Exceptions;
using System;
using System.Collections.Generic;

namespace HR.ShiftContext.Domain.ShiftTemplates
{
    public class ShiftTemplate : EntityBase
    {
        protected ShiftTemplate()
        {
        }

        public ShiftTemplate(string title)
        {
            SetTitle(title);
        }

        private void SetTitle(string title)
        {
            if(String.IsNullOrWhiteSpace(title))
                throw new ShiftTemplateTitleRequiredException();

            Title = title;
        }

        
        public string Title { get; set; }
        //public ICollection<Shift> Shifts { get; set; } = new HashSet<Shift>();
        //public Guid ShiftId { get; set; }
        //public Shift Shift { get; set; }
        //public ICollection<Shift> MyProperty { get; set; }
    }
}
