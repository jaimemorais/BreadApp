using ErrorOr;

namespace BreadApp.Domain.Errors
{
    public static class BreadDoneDomainErrors
    {

        public static readonly Error NotFound = Error.NotFound(code: "BreadDone.NotFound", description: "Bread not found");

        public static readonly Error DateRequired = Error.NotFound(code: "BreadDone.DateRequired", description: "Date required to add a bread done.");

        public static readonly Error UserNotFound = Error.NotFound(code: "BreadDone.UserNotFound", description: "User not found with the email.");

        public static readonly Error RecipeNotFound = Error.NotFound(code: "BreadDone.RecipeNotFound", description: "Recipe not found with the Id.");

    }
}
