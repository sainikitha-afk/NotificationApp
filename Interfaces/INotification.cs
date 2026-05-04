using NotificationApp.Models;

namespace NotificationApp.Interfaces
{
    // common method for all notification types
    internal interface INotification
    {
        // notification type to send a message
        void Send(User user, Notification notification);
    }
}