using ErrorOr;

namespace BreadApp.Domain.Errors
{
    public static class UserDomainErrors
    {
        public static readonly Error DuplicateEmail = Error.Conflict(code: "User.DuplicateEmail", description: "Email is already in use");

        public static readonly Error FailedLogin = Error.Failure(code: "User.Login", description: "Login failed");

        public static readonly Error UserNotFound = Error.Failure(code: "User.NotFound", description: "User not found");
    }
}
