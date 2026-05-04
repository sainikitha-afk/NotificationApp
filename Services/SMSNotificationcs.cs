using NotificationApp.Interfaces;
using NotificationApp.Models;

namespace NotificationApp.Services
{
    // for sending notifications via SMS
    internal class SMSNotification : INotification
    {
        public void Send(User user, Notification notification)
        {
            Console.WriteLine("\n--- SMS Notification ---");
            Console.WriteLine($"To: {user.Phone}");
            Console.WriteLine(notification.Message);
            Console.WriteLine($"Sent on: {notification.SentDate}");
        }
    }
}