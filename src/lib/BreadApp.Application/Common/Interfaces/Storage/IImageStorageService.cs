using System.Threading.Tasks;

namespace BreadApp.Application.Common.Interfaces.Storage
{
    public interface IImageStorageService
    {

        Task<string> StoreImageAsync(string fileName, byte[] imageData);

    }
}
