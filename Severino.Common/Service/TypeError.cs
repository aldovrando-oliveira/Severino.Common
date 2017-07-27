using Severino.Common.Attributes;

namespace Severino.Common.Service
{
    public enum TypeError
    {
        [Description("Unexpected error")]
        UnexpectedError,
        [Description("Not found")]
        NotFound,
        [Description("Invalid property")]
        PropertyInvalid,
        [Description("Conflict")]
        Conflict
    }
}