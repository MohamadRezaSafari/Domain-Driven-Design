using System.Data;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees.Mapping
{
    public class PerformanceMapping:EntityMappingBase<Performance>
    {
        public override void Configure(EntityTypeBuilder<Performance> builder)
        {
            Initial(builder);
            builder.Property(i => i.EmployeeId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
            builder.Property(i => i.FromDate).IsRequired();
            builder.Property(i => i.ToDate).IsRequired();
            builder.Property(i => i.Sum).IsRequired();
        }
    }
}
