using com.assignment.Common;
using com.assignment.Domain.Interfaces;
using com.assignment.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace com.assignment.Infrastructure;

public partial class EmployeeDbContext : DbContext, IUnitOfWork
{
    public EmployeeDbContext()
    {
        
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
        
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmpQualification> EmpQualifications { get; set; }
    public DbSet<QualificationList> QualificationLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeBuilder());
        modelBuilder.ApplyConfiguration(new EmployeeQualificationBuilder());
        modelBuilder.ApplyConfiguration(new QualificationListBuilder());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer()
            .UseSnakeCaseNamingConvention();
    }

    public async Task<ResponseMessage> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await base.SaveChangesAsync(cancellationToken);
            return new ResponseMessage("SUCCESSFUL", StatusCodes.Status200OK);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            return new ResponseMessage(ex.Message, StatusCodes.Status502BadGateway);
        }
    }
}