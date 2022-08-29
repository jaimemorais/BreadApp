using ErrorOr;

namespace BreadApp.Domain.Errors
{
    public static class BreadDoneDomainErrors
    {

        public static readonly Error NotFound = Error.NotFound(code: "BreadDone.NotFound", description: "Bread not found");

        public static readonly Error DateRequired = Error.NotFound(code: "BreadDone.DateRequired", description: "Date required to add a bread done.");


    }
}
