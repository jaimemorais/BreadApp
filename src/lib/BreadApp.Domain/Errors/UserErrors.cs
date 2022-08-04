using ErrorOr;

namespace BreadApp.Domain.Errors
{
    public static class UserErrors
    {
        public static readonly Error DuplicateEmail = Error.Conflict(code: "User.DuplicateEmail", description: "Email is already in use");

        public static readonly Error FailedLogin = Error.Failure(code: "User.Login", description: "Login failed");
    }
}
