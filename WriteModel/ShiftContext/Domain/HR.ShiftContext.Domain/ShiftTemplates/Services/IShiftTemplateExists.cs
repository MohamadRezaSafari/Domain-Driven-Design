using Framework.Core.Domain;
using System;

namespace HR.ShiftContext.Domain.ShiftTemplates.Services
{
    public interface IShiftTemplateExists : IDomainService
    {
        bool Exist(Guid shiftTemplateId);
    }
}
