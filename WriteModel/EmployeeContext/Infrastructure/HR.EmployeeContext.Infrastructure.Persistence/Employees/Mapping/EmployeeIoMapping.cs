using System.Data;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.EmployeeContext.Infrastructure.Persistence.EmployeeIos.Mapping
{
    public class EmployeeIoMapping : EntityMappingBase<EmployeeIo>
    {
        public override void Configure(EntityTypeBuilder<EmployeeIo> builder)
        {
            Initial(builder);

            builder.Property(i => i.DateTime).IsRequired();
            builder.Property(i => i.EmployeeId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
        }
    }
}
