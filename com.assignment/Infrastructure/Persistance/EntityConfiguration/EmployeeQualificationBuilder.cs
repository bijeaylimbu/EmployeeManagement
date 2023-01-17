using com.assignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace com.assignment.Domain.Interfaces;


internal  sealed class EmployeeQualificationBuilder: IEntityTypeConfiguration<EmpQualification>
{
    public void Configure(EntityTypeBuilder<EmpQualification> builder)
    {
        builder.ToTable("emp_qualification");
        builder.HasKey(x => x.EmployeeId);
        builder.Property(x => x.QId)
            .HasColumnName("q_id")
            .IsRequired();
        builder.Property(x => x.Marks)
            .HasColumnName("marks")
            .IsRequired();
    }
}