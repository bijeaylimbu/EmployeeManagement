using com.assignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace com.assignment.Domain.Interfaces;


internal  sealed class QualificationListBuilder: IEntityTypeConfiguration<QualificationList>
{
    public void Configure(EntityTypeBuilder<QualificationList> builder)
    {
        builder.ToTable("qualification_list");
        builder.HasKey(x => x.QId);
        builder.Property(x => x.QName)
            .HasColumnName("q_name")
            .IsRequired();
       
        builder.HasMany(x => x.EmpQualification)
            .WithOne(b => b.QualificationList).HasForeignKey(x => x.QId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}