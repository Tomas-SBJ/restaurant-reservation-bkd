using System.ComponentModel;

namespace Domain.Enums;

public enum EUserRole
{
    [Description("CLIENT")]
    Client,
    [Description("ADMIN")]
    Admin
}