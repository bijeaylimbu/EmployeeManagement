using com.assignment.Domain.Models;
using com.assignment.Domain.Models.Enum;

namespace com.assignment.Application.Requsts;

public record EmployeeRequest(string EmployeeName, Gender Gender, DateTime DOB, string Salary, ICollection<EmpQualification> EmpQualification );