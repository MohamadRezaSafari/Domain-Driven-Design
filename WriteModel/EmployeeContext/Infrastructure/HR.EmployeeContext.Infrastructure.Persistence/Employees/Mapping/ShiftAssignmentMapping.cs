using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees.Mapping
{
    public class ShiftAssignmentMapping : EntityMappingBase<ShiftAssignment>
    {
        public override void Configure(EntityTypeBuilder<ShiftAssignment> builder)
        {
            Initial(builder);

            builder.Property(i => i.StartDate).IsRequired();
            builder.Property(i => i.EndDate).HasDefaultValue(null);
            builder.Property(i => i.ShiftSegmentId).IsRequired(false);
        }
    }
}
