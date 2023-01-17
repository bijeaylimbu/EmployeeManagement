namespace com.assignment.Domain.Models;

public class QualificationList
{
    public  int QId { get; set; }
    public  string QName { get; set; }
    public virtual  ICollection<EmpQualification> EmpQualification { get; set; }
}