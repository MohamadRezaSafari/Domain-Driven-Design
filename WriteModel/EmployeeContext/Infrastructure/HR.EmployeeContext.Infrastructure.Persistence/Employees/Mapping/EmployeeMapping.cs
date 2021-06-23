using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees.Mapping
{
    public class EmployeeMapping : EntityMappingBase<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            Initial(builder);

            builder.Property(i => i.EmployeeId).ValueGeneratedOnAdd().IsRequired();
            builder.Property(i => i.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(i => i.LastName).HasMaxLength(100).IsRequired();
            builder.Property(i => i.IsActive).HasDefaultValue(true);
        }
    }
}
