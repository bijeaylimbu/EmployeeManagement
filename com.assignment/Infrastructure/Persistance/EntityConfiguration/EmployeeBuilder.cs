using com.assignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace com.assignment.Domain.Interfaces;

internal  sealed class EmployeeBuilder: IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employee");
        builder.HasKey(x => x.EmployeeId);
        builder.Property(x => x.EmployeeName)
            .HasColumnName("employee_name")
            .IsRequired();
        builder.Property(x => x.DOB)
            .HasColumnName("dob")
            .IsRequired();
        builder.Property(x => x.Gender)
            .HasColumnName("gender")
            .IsRequired();
        builder.Property(x => x.Salary)
            .HasColumnName("salary")
            .IsRequired();
        builder.Property(x => x.EntryBy)
            .HasColumnName("entry_by")
            .IsRequired();
        builder.Property(x => x.EntryDate)
            .HasColumnName("entry_date")
            .IsRequired();
        builder.HasMany(x => x.EmpQualifications)
            .WithOne(b => b.Employee).HasForeignKey(x => x.EmployeeId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}