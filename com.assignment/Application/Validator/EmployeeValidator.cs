using System.Reflection.Metadata;
using com.assignment.Common;
using com.assignment.Domain.Models;
using FluentValidation;

namespace com.assignment.Application.Validator;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(model => model.EmployeeId).NotEmpty().WithMessage(Constants.CUSTOMER_ID_CANNOT_BE_NULL);
       
    }
}