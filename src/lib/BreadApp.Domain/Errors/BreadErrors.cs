using ErrorOr;

namespace BreadApp.Domain.Errors
{
    public static class BreadErrors
    {
        public static readonly Error DuplicateName = Error.Conflict(code: "Bread.Duplicate", description: "Bread Name is already in use");

        public static readonly Error BreadNotFound = Error.NotFound(code: "Bread.NotFound", description: "Bread not found");

    }
}
