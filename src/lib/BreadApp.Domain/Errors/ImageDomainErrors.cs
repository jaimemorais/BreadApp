using ErrorOr;

namespace BreadApp.Domain.Errors
{
    public static class ImageDomainErrors
    {

        public static readonly Error ImageBiggerThan2mb = Error.Validation(code: "Image.Bigger.Than.2mb", description: "Image should be smaller than 2 megabytes");

    }
}
