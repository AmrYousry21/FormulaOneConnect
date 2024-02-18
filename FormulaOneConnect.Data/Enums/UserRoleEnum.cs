
using System.ComponentModel;

namespace FormulaOneConnect.Data.Enums;

public enum UserRoleEnum
{
    [Description("Admin")]
    Admin = 1,
    [Description("Agent")]
    Agent = 2,
    [Description("Lead")]
    Lead = 3
}
