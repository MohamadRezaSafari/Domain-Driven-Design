using Framework.Domain;
using HR.ShiftContext.Domain.ShiftTemplates.Exceptions;
using System;

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
    }
}
