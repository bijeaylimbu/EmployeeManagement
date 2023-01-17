using com.assignment.Application.Responses;
using com.assignment.Domain.Models;

namespace com.assignment.Domain.Interfaces;

public interface IEmployeeRepository: IRepository<Employee>
{
    Task<Employee?> GetEmployeeById(int id, CancellationToken cancellationToken);
    Employee Add(Employee employee);

    EmpQualification AddEmp(ICollection< EmpQualification> empQualification);

     Task<IEnumerable<QualificationList>> GetAllQualificationList(CancellationToken cancellationToken);
     
     Task<IEnumerable<Employee>> GetAllEmployeeList(CancellationToken cancellationToken);
     
     Employee Update(Employee employee);
     
     Task<QualificationList?> GetQualificationById(int id, CancellationToken cancellationToken);
     
}