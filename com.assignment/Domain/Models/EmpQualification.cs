using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace com.assignment.Domain.Models;

public class EmpQualification
{

 public EmpQualification(  int employeeId,int qId, string marks)
 {
  EmployeeId = employeeId;
  QId = qId;
  Marks = marks;

 }
 
 public   int EmployeeId { get; set; }
 public int QId { get; set; }
 public string Marks { get; set; }
 
 public  virtual  Employee Employee { get; set; }
 public  virtual  QualificationList QualificationList { get; set; }
 
}