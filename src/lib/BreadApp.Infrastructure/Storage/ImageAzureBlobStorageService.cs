using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BreadApp.Application.Common.Interfaces.Storage;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace BreadApp.Infrastructure.Storage
{
    public class ImageAzureBlobStorageService : IImageStorageService
    {
        const string BREADAPP_PICS_CONTAINER_NAME = "breadapp-pics";

        private readonly IConfiguration _config;

        public ImageAzureBlobStorageService(IConfiguration config)
        {
            _config = config;
        }


        public async Task<string> StoreImageAsync(string fileName, byte[] imageData)
        {
            // az storage account show-connection - string--name < account_name > --resource - group < resource_group >
            string connectionString = _config["BreadAppAzure:BlobStorage:ConnectionString"];

            BlobContainerClient container = new(connectionString, BREADAPP_PICS_CONTAINER_NAME);

            BlobClient blob = container.GetBlobClient(fileName);

            using var data = new MemoryStream(imageData);
            await blob.UploadAsync(data);

            BlobProperties properties = await blob.GetPropertiesAsync();
            if (properties.ContentLength != imageData.Length)
            {
                throw new BreadAppInfraException($"Upload failed for image '{fileName}'");
            }

            // TODO
            return null;
        }
    }
}
