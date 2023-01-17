using com.assignment.Application.Requsts;
using com.assignment.Common;
using com.assignment.Domain.Interfaces;
using com.assignment.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace com.assignment.Controllers;



[ApiController]
[Route("employee")]
[Produces("application/json")]
public class EmployeeController: ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }
    [HttpPost]
    public async Task<IActionResult> CreateEmployee( EmployeeRequest request, CancellationToken cancellationToken)
    {
        return  Ok( await _employeeService.CreateEmployee(request, cancellationToken));
    }

    [HttpGet("all-qualification-list")]
    public async Task<IActionResult> GetAllQualificationList(CancellationToken cancellationToken)
    {
        var result = await _employeeService.GetAllQualificationList(cancellationToken);
        return Ok(result);
    }
    [HttpGet("{employeeId}")]
    public async Task<IActionResult> GetEmployeeById(int employeeId, CancellationToken cancellationToken)
    {
        var result = await _employeeService.GetEmployeeById(employeeId,cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("all-employee")]
    public async Task<IActionResult> GetAllEmployeeList(CancellationToken cancellationToken)
    {
        var result = await _employeeService.GetAllEmployeeList(cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRequest request,int id, CancellationToken cancellationToken)
    {
        var result = await _employeeService.UpdatedEmployee( id, request, cancellationToken);
        return  Ok(result);
    }
    
    [HttpGet("qualification/{qId}")]
    public async Task<IActionResult> GetQualificationById(int qId, CancellationToken cancellationToken)
    {
        var result = await _employeeService.GetQualificationNameById(qId,cancellationToken);
        return Ok(result);
    }
}