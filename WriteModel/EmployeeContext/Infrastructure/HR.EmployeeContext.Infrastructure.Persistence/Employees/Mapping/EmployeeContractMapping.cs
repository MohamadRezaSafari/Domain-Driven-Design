using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees.Mapping
{
    public class EmployeeContractMapping : EntityMappingBase<EmployeeContract>
    {
        public override void Configure(EntityTypeBuilder<EmployeeContract> builder)
        {
            Initial(builder);

            builder.Property(i => i.StartDate).IsRequired();
            builder.Property(i => i.EndDate).IsRequired();
            builder.Property(i => i.UnitId).IsRequired();
        }
    }
}
