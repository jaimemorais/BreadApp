using BreadApp.Application.Common.Interfaces.Storage;
using BreadApp.Domain.Errors;
using ErrorOr;
using Humanizer.Bytes;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Image.Commands
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, ErrorOr<Domain.Entities.Image>>
    {

        private readonly IImageStorageService _imageStorageService;

        public UploadImageCommandHandler(IImageStorageService imageStorageService)
        {
            _imageStorageService = imageStorageService;
        }


        public async Task<ErrorOr<Domain.Entities.Image>> Handle(UploadImageCommand uploadImageCommand, CancellationToken cancellationToken)
        {
            if (ByteSize.FromBytes(uploadImageCommand.ImageFile.Length).Megabytes > 2)
            {
                return ImageDomainErrors.ImageBiggerThan2mb;
            }

            using var imageStream = uploadImageCommand.ImageFile.OpenReadStream();
            using var memoryStream = new MemoryStream();
            imageStream.CopyTo(memoryStream);

            Guid imageBlobId = await _imageStorageService.StoreImageAsync(memoryStream.ToArray());

            Domain.Entities.Image image = new Domain.Entities.Image()
            {
                Id = imageBlobId
            };

            return image;
        }


    }

}
