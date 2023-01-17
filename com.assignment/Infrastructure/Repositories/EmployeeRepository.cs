using System.Collections;
using Azure;
using com.assignment.Application.Requsts;
using com.assignment.Application.Responses;
using com.assignment.Domain.Interfaces;
using com.assignment.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace com.assignment.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _context;

    public EmployeeRepository(EmployeeDbContext dbContext)
    {
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public IUnitOfWork UnitOfWork => _context;
    public async Task<Employee?> GetEmployeeById(int id, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.AsNoTracking()
            .Include(x=>x.EmpQualifications)
            .ThenInclude(x=>x.QualificationList)
                .SingleOrDefaultAsync(x =>x.EmployeeId.Equals(id), cancellationToken);
            return employee;
    }
    

    public Employee Add(Employee employee)
    {
        return employee.EmployeeId == default ? _context.Employees.Add(employee).Entity : employee;

    }
    


    public EmpQualification AddEmp(ICollection<EmpQualification> empQualification)
    {
        foreach (var element in empQualification)
        {
            return element.EmployeeId == default ? _context.EmpQualifications.Add(element).Entity : element;
        }

        return null;
    }

    public async Task<IEnumerable<QualificationList>> GetAllQualificationList(CancellationToken cancellationToken)
    {
        try
        {
            var qualificationList = await _context.QualificationLists
                .OrderByDescending(x => x.QId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return qualificationList;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeeList(CancellationToken cancellationToken)
    {
        try
        {
            var employees = await _context.Employees
                .OrderByDescending(x => x.EmployeeId)
                .Include(x=>x.EmpQualifications)
                .AsNoTracking().
                ToListAsync();
            return employees;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Employee Update(Employee employee)
    {
        return _context.Employees.Update(employee).Entity;
    }

    public async Task<QualificationList?> GetQualificationById(int id, CancellationToken cancellationToken)
    {
        var qualification = await _context.QualificationLists.AsNoTracking()
            .SingleOrDefaultAsync(x =>x.QId.Equals(id), cancellationToken);
        return qualification;
    }
}