using Framework.Persistence;
using HR.ShiftContext.Domain.Shifts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.ShiftContext.Infrastructure.Persistence.Shifts.Mapping
{
    public class ShiftSegmentMapping : EntityMappingBase<ShiftSegment>
    {
        public override void Configure(EntityTypeBuilder<ShiftSegment> builder)
        {
            Initial(builder);
                        
            builder.Property(i => i.StartTime).IsRequired();
            builder.Property(i => i.EndTime).IsRequired();
            builder.Property(i => i.NextShiftId).HasColumnType(SqlDbType.UniqueIdentifier.ToString())
                .IsRequired(false);

            builder.HasOne<Shift>()
                .WithMany(i=>i.ShiftSegments)
                .HasForeignKey(i=>i.ShiftId)
                .HasConstraintName("FK_Shift_ShiftSegment");
        }
    }
}
