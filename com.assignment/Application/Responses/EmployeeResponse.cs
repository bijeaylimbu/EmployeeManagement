using System.Net;
using com.assignment.Common;

namespace com.assignment.Application.Responses;

public class EmployeeResponse
{
    public string Data { get; set; }
    public IList<ResponseMessage> Messages { get; set; } = new List<ResponseMessage>();
    public int Status { get; set; } = (int)HttpStatusCode.OK;
}