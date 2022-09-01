namespace BreadApp.Application.Common.Interfaces.Storage
{
    public interface IImageStorageService
    {

        string StoreImage(byte[] imageData);

    }
}
