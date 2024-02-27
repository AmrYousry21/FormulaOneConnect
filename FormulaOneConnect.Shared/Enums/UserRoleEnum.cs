using System.ComponentModel;

namespace FormulaOneConnect.Shared.Enums;

public enum UserRoleEnum
{
    [Description("Admin")]
    Admin = 1,
    [Description("Member")]
    Member = 2,
}