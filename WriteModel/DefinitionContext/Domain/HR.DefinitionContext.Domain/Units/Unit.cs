using Framework.Core.Domain;
using Framework.Domain;
using HR.DefinitionContext.Domain.Units.Exceptions.Unit;
using HR.DefinitionContext.Domain.Units.Services;

namespace HR.DefinitionContext.Domain.Units
{
    public class Unit : EntityBase, IAggregateRoot
    {
        protected Unit()
        {

        }

        public Unit(IUnitTitleDuplicationChecker titleDuplicationChecker, string title)
        {
            SetTitle(titleDuplicationChecker, title);
        }

        public string Title { get; private set; }

        private void SetTitle(IUnitTitleDuplicationChecker titleDuplicationChecker,string title)
        {
            var standardTitle = title.Trim();

            if (string.IsNullOrWhiteSpace(standardTitle))
                throw new EmptyUnitTitleException();

            if (titleDuplicationChecker.IsDuplicated(standardTitle))
                throw new DuplicatedUnitTitleException();

            this.Title = standardTitle;
        }
    }
}