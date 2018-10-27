using System.Collections.Generic;
using TesteSWFast.IO.Core.Events;

namespace TesteSWFast.IO.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
