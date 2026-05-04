using NotificationApp.Interfaces;
using NotificationApp.Models;

namespace NotificationApp.Services
{
    // to send Email Notifications
    internal class EmailNotification : INotification
    {
        public void Send(User user, Notification notification)
        {
            Console.WriteLine("\n--- Email Notification ---");
            Console.WriteLine($"To: {user.Email}");
            Console.WriteLine($"Hello {user.Name},");
            Console.WriteLine(notification.Message);
            Console.WriteLine($"Sent on: {notification.SentDate}");
        }
    }
}