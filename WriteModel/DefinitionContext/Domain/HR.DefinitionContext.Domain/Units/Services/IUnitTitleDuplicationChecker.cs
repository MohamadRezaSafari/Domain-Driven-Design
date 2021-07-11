using System;
using Framework.Core.Domain;

namespace HR.DefinitionContext.Domain.Units.Services
{
    public interface IUnitTitleDuplicationChecker: IDomainService
    {
        bool IsDuplicated(string title);
    }
}