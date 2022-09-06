using System;
using System.Threading.Tasks;

namespace BreadApp.Application.Common.Interfaces.Storage
{
    public interface IImageStorageService
    {

        Task<Guid> StoreImageAsync(byte[] imageData);

    }
}
