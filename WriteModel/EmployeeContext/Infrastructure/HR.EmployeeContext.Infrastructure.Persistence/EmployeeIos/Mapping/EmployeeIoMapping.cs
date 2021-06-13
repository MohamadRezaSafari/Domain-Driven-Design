using Framework.Persistence;
using HR.EmployeeContext.Domain.EmployeeIos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Infrastructure.Persistence.EmployeeIos.Mapping
{
    public class EmployeeIoMapping : EntityMappingBase<EmployeeIo>
    {
        public override void Configure(EntityTypeBuilder<EmployeeIo> builder)
        {
            Initial(builder);

            builder.Property(i => i.DateTime).IsRequired();
            builder.Property(i => i.EmployeeId).IsRequired();
        }
    }
}
