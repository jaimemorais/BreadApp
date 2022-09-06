using Microsoft.AspNetCore.Http;

namespace BreadApp.Api.Contracts.Image
{
    public record UploadImageRequest(IFormFile ImageFile);



}
