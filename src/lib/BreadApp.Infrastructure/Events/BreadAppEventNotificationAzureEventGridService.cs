using BreadApp.Application.Common.Interfaces.Events;
using System;
using System.Threading.Tasks;

namespace BreadApp.Infrastructure.Events
{

    /// <summary>
    /// Send and event using Azure Event Grid
    /// </summary>
    public class BreadAppEventNotificationAzureEventGridService : IBreadAppEventNotificationService
    {
        public Task NotifyEventAsync(object breadAppEvent)
        {
            throw new NotImplementedException();
        }
    }
}
