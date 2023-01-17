using System.Runtime.Serialization;

namespace com.assignment.Domain.Models.Enum;

public enum Gender
{
    [EnumMember(Value = "MALE")]
    MALE=0,
    [EnumMember(Value = "FEMALE")]
    FEMALE=1,
    [EnumMember(Value = "THIRD_GENDER")]
    THIRD_GENDER=3
}