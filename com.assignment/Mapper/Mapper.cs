using AutoMapper;
using com.assignment.Application.Requsts;
using com.assignment.Domain.Models;

namespace com.assignment.Mapper;

public class Mapper: Profile
{
    public Mapper()
    {
        CreateMap<EmployeeRequest, Employee>();
    }
}