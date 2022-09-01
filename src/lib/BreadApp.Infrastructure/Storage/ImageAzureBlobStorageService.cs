using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BreadApp.Application.Common.Interfaces.Storage;
using System.Threading.Tasks;

namespace BreadApp.Infrastructure.Storage
{
    public class ImageAzureBlobStorageService : IImageStorageService
    {
        const string BREADAPP_PICS_CONTAINER_NAME = "breadapp-pics";

        public async Task<string> StoreImageAsync(string fileName, byte[] imageData)
        {

            // ref : https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs/samples/Sample01b_HelloWorldAsync.cs#L21

            // Get a connection string to our Azure Storage account.  You can
            // obtain your connection string from the Azure Portal (click
            // Access Keys under Settings in the Portal Storage account blade)
            // or using the Azure CLI with:
            //
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            //
            // And you can provide the connection string to your application
            // using an environment variable.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, BREADAPP_PICS_CONTAINER_NAME);
            await container.CreateAsync();
            try
            {
                // Get a reference to a blob
                BlobClient blob = container.GetBlobClient(fileName);

                // Upload file data
                await blob.UploadAsync(imageData);

                // Verify we uploaded some content
                BlobProperties properties = await blob.GetPropertiesAsync();
                if (properties.ContentLength != imageData.Length)
                {
                    throw BreadAppInfraException("Upload failed");
                }

            }
            finally
            {
                // Clean up after the test when we're finished
                await container.DeleteAsync();
            }
        }
    }
}
