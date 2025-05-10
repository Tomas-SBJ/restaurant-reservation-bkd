using System.ComponentModel;

namespace Domain.Enums;

public enum EErrorType
{
    [Description("CONFLICT_ERROR")]
    ConflictError,
    [Description("VALIDATION_ERROR")]
    ValidationError
}