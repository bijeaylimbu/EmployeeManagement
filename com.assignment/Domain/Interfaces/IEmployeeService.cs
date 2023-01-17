using com.assignment.Application.Requsts;
using com.assignment.Common;
using com.assignment.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace com.assignment.Domain.Interfaces;

public interface IEmployeeService
{
    public Task<ResponseMessage> CreateEmployee(EmployeeRequest request, CancellationToken cancellationToken);
    
     Task<IEnumerable<QualificationList>> GetAllQualificationList( CancellationToken cancellationToken);
     
     Task<IEnumerable<Employee>> GetAllEmployeeList( CancellationToken cancellationToken);
     Task<Employee> GetEmployeeById( int id, CancellationToken cancellationToken);
     
     Task<ResponseMessage> UpdatedEmployee( int id, EmployeeRequest request, CancellationToken cancellationToken);
     
     Task<QualificationList> GetQualificationNameById( int id, CancellationToken cancellationToken);
}