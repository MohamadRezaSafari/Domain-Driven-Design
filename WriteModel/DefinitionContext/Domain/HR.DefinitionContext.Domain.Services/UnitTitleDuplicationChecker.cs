using System;
using HR.DefinitionContext.Domain.Units.Services;

namespace HR.DefinitionContext.Domain.Services
{
    public class UnitTitleDuplicationChecker: IUnitTitleDuplicationChecker
    {
        private readonly IUnitRepository _unitRepository;

        public UnitTitleDuplicationChecker(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public bool IsDuplicated(string title)
        {
            return _unitRepository.Any(u => u.Title == title);
        }
    }
}