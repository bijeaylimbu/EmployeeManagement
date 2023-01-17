using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using com.assignment.Domain.Models.Enum;

namespace com.assignment.Domain.Models;

public sealed class Employee
{
    public Employee()
    {
        
    }
    public Employee( string employeeName, DateOnly dob, Gender gender, string salary, ICollection<EmpQualification> empQualifications)
    {
      
        EmployeeName = employeeName;
        DOB = dob.ToString("yyyy/MM/dd");
        Gender = gender;
        Salary = salary;
        EntryBy = "admin";
        EntryDate = DateTime.Now.Date.ToString("yyyy/MM/dd");
        EmpQualifications = empQualifications;
    }
    
    [Key]
    public int EmployeeId { get; set; }
    public  string EmployeeName { get; set; }
    public string DOB { get; set; }
    
    public Gender Gender { get; set; }
    public string Salary { get; set; }
    public string EntryBy { get; set; }
    public string EntryDate { get; set; }
    public ICollection<EmpQualification> EmpQualifications { get; set; }
    
}