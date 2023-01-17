
using System.Text.RegularExpressions;
using AutoMapper;
using com.assignment.Application.Requsts;
using com.assignment.Common;
using com.assignment.Domain.Interfaces;
using com.assignment.Domain.Models;

namespace com.assignment.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<ResponseMessage> CreateEmployee(EmployeeRequest request, CancellationToken cancellationToken)
    {
        return await PersistEmployee(request, cancellationToken);
    }

    public async Task<IEnumerable<QualificationList>> GetAllQualificationList(CancellationToken cancellationToken)
    {
        var result = await  _repository.GetAllQualificationList(cancellationToken);
        return result;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeeList(CancellationToken cancellationToken)
    {
        var result = await  _repository.GetAllEmployeeList(cancellationToken);
        return result;
    }

    public async Task<Employee> GetEmployeeById(int id, CancellationToken cancellationToken)
    {
        if (id == null)
        {
            throw new Exception(Constants.ID_CANNOT_BE_NULL);
        }
        var result = await _repository.GetEmployeeById(id, cancellationToken);
        return result;
    }

    public async Task<ResponseMessage> UpdatedEmployee( int id,EmployeeRequest employee, CancellationToken cancellationToken)
    {
        var emp = await _repository.GetEmployeeById(id, cancellationToken);
        if (emp == null)
        {
            return new ResponseMessage(Constants.CANNOT_FIND_EMPLOYEE, StatusCodes.Status502BadGateway);
        }
        else
        {
            if (!Regex.IsMatch(employee.EmployeeName, @"^[a-zA-Z]+$"))
            {
                return new ResponseMessage(Constants.ONLY_CHARACTER_ACCEPTED, StatusCodes.Status502BadGateway);
            }
            if (!employee.Salary.ToString().All(char.IsDigit) )
            {
                return  new ResponseMessage(Constants.ONLY_NUMBER_ACCEPTED, StatusCodes.Status502BadGateway);
            }

            foreach (var mark in employee.EmpQualification)
            {
                if (!mark.Marks.ToString().All(char.IsDigit) )
                {
                    return  new ResponseMessage(Constants.ONLY_NUMBER_ACCEPTED, StatusCodes.Status502BadGateway);
                }
            }
            if (employee.DOB > DateTime.Today)
            {
                return new ResponseMessage(Constants.INVALID_BIRTH_OF_DATE, StatusCodes.Status502BadGateway);
            }
            var dbEmployee =  _repository.Update(new Employee()
            {
                EmployeeName = employee.EmployeeName,
                DOB = employee.DOB.ToString("yyyy/MM/dd"),
                Gender = employee.Gender,
                Salary = employee.Salary,
                EntryBy = "admin",
                EntryDate = DateTime.Now.Date.ToString("yyyy/MM/dd"),
                EmpQualifications = employee.EmpQualification
            });
            var result = await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return new ResponseMessage("successful", StatusCodes.Status200OK);
        }
    }

    public async Task<QualificationList> GetQualificationNameById(int id, CancellationToken cancellationToken)
    {
        var result = await _repository.GetQualificationById(id, cancellationToken);
        return result;
    }

    // public Employee CreateEmployee(Employee request)
    // {
    //     return new Employee(request.EmployeeName,  request.DOB,request.Gender, request.Salary, request.EmpQualifications);
    // }
  

    public async Task<ResponseMessage> PersistEmployee(EmployeeRequest employee,
        CancellationToken cancellationToken)
    {
        if (!Regex.IsMatch(employee.EmployeeName, @"^[a-zA-Z]+$"))
        {
            return new ResponseMessage(Constants.ONLY_CHARACTER_ACCEPTED, StatusCodes.Status502BadGateway);
        }
        if (!employee.Salary.ToString().All(char.IsDigit) )
        {
            return  new ResponseMessage(Constants.ONLY_NUMBER_ACCEPTED, StatusCodes.Status502BadGateway);
        }

        foreach (var mark in employee.EmpQualification)
        {
            if (!mark.Marks.ToString().All(char.IsDigit) )
            {
                return  new ResponseMessage(Constants.ONLY_NUMBER_ACCEPTED, StatusCodes.Status502BadGateway);
            }
        }
        if (employee.DOB > DateTime.Today)
        {
            return new ResponseMessage(Constants.INVALID_BIRTH_OF_DATE, StatusCodes.Status502BadGateway);
        }
        var dbEmployee =  _repository.Add(new Employee()
        {
            EmployeeName = employee.EmployeeName,
            DOB = employee.DOB.ToString("yyyy/MM/dd"),
            Gender = employee.Gender,
            Salary = employee.Salary,
            EntryBy = "admin",
            EntryDate = DateTime.Now.Date.ToString("yyyy/MM/dd"),
            EmpQualifications = employee.EmpQualification
        });
        var result = await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return new ResponseMessage("successful", StatusCodes.Status200OK);
    }
}