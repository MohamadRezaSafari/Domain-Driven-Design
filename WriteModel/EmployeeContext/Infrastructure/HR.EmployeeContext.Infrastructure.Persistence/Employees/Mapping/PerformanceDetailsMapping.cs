using System.Data;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees.Mapping
{
    public class PerformanceDetailsMapping : EntityMappingBase<PerformanceDetail>
    {
        public override void Configure(EntityTypeBuilder<PerformanceDetail> builder)
        {
            Initial(builder);
            builder.Property(i => i.PerformanceId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
            builder.Property(i => i.ShiftSegmentId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
            builder.Property(i => i.Sum).IsRequired();
        }
    }
}
