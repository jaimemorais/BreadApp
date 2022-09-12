using System.Threading.Tasks;

namespace BreadApp.Application.Common.Interfaces.Events
{
    public interface IBreadAppEventNotificationService
    {
        Task NotifyEventAsync(object breadAppEvent);
    }
}
